using OriontaxSync.libs;
using OriontaxSync.libs.DAOSVR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OriontaxSync.Classes
{
    internal class ProdutosApi
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("codigo_barras")]
        public string CodigoBarras { get; set; }

        [JsonPropertyName("ncm")]
        public string Ncm { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("cest")]
        public string Cest { get; set; }

        [JsonPropertyName("cfop")]
        public int Cfop { get; set; }

        [JsonPropertyName("icms_cst")]
        public int IcmsCst { get; set; }

        [JsonPropertyName("icms_aliquota")]
        public decimal? IcmsAliquota { get; set; }

        [JsonPropertyName("icms_aliquota_reduzida")]
        public decimal? IcmsAliquotaReduzida { get; set; }

        [JsonPropertyName("redbcde")]
        public object RedBcDe { get; set; }

        [JsonPropertyName("redbcpara")]
        public object RedBcPara { get; set; }

        [JsonPropertyName("cbenef")]
        public string CBenef { get; set; }

        [JsonPropertyName("protege")]
        public int Protege { get; set; }

        [JsonPropertyName("pis_cst")]
        public string PisCst { get; set; }

        [JsonPropertyName("pis_aliquota")]
        public decimal PisAliquota { get; set; }

        [JsonPropertyName("cofins_cst")]
        public string CofinsCst { get; set; }

        [JsonPropertyName("cofins_aliquota")]
        public decimal CofinsAliquota { get; set; }

        [JsonPropertyName("natureza_receita")]
        public string NaturezaReceita { get; set; }

        public static async Task TratarProdutosRecebidos(Label lblInfo, bool temAlerta = false)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    lblInfo.Text = "";
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {Funcoes.Decrypt(ConfigReader.GetConfigValue("token"))}");
                    List<ProdutosApi>prodNotFound = new List<ProdutosApi>();

                    lblInfo.Text = "Chamando Api da Oriontax...";
                    await Task.Delay(100);
                    // Fazer a requisição GET
                    HttpResponseMessage response = await client.GetAsync($"{ConfigReader.base_url}/receber/");
                    lblInfo.Text = "Recebendo Resposta...";
                    await Task.Delay(100);
                    // Garantir que a requisição foi bem-sucedida
                    response.EnsureSuccessStatusCode();

                    // Ler o conteúdo como string
                    string responseData = await response.Content.ReadAsStringAsync();
                    lblInfo.Text = "Lendo produtos";
                    await Task.Delay(100);

                    List<ProdutosApi> produtosApi = JsonSerializer.Deserialize<List<ProdutosApi>>(responseData);
                    foreach (var produto in produtosApi)
                    {
                        // Converter os valores para decimal, se possível
                        produto.RedBcDe = Funcoes.ConvertToDecimal(produto.RedBcDe);
                        produto.RedBcPara = Funcoes.ConvertToDecimal(produto.RedBcPara);
                    }

                    lblInfo.Text = $"Recebido {produtosApi.Count} produtos.";
                    await Task.Delay(100);

                    int i = 0;
                    int notFound = 0;
                    foreach (ProdutosApi prod in produtosApi)
                    {
                        try
                        {
                            i++;
                            ProdutoDAO produtoDAO = new ProdutoDAO();
                            DataRowCollection retProd = produtoDAO.GetQuery($"Codigo = '{prod.Codigo}' OR Codigo_fabricante1 = '{prod.Codigo}' OR Codigo_fabricante1 = '{prod.CodigoBarras}'").ReadAsCollection();

                            if (retProd.Count == 0) continue;

                            string title = $"Ajustando produto {i} de {produtosApi.Count}\r\n";
                            lblInfo.Text = title + "Atualizando produto";
                            await Task.Delay(10);
                            ClasseImpostoDAO classeImpostoDAO = new ClasseImpostoDAO();
                            ClasseImpostoBanco retClasse = classeImpostoDAO.GetClasseImposto(prod);

                            if(retClasse == null)
                            {
                                notFound++;
                                prodNotFound.Add(prod);
                                continue;
                            }

                            produtoDAO.AtualizaRecebidoProduto(retProd[0]["Codigo"].ToString(), prod, retClasse);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao processar produto {i}: {ex.Message}");
                            continue;
                        }
                        
                    }

                    if(prodNotFound.Count > 0)
                    {
                        Mail mail = new Mail();
                        lblInfo.Text = $"Enviando email de classes não encontradas";
                        await Task.Delay(10);
                        mail.SendEmailHtml("Classes não encontradas", TemplateMail.TableTemplate("Não foi possível encontrar classe de imposto com os seguintes atributos", prodNotFound));
                    }

                    lblInfo.Text = "Finalizado...";
                    await Task.Delay(10);

                }
            }
            catch (HttpRequestException ex)
            {
                lblInfo.Text = "";
                if (temAlerta) Funcoes.ErrorMessage(ex.Message);
                Logger.Log(ex.Message, "Erro");
            }
            catch (Exception ex)
            {
                lblInfo.Text = "";
                if (temAlerta) Funcoes.ErrorMessage(ex.Message);
                Logger.Log(ex.Message, "Erro");
            }
        }

        public static async Task TratarProdutosEnviados(Label lblInfo, bool temAlerta = false)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    lblInfo.Text = "";
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {Funcoes.Decrypt(ConfigReader.GetConfigValue("token"))}");

                    lblInfo.Text = "Consultando produtos no banco...";
                    await Task.Delay(100);
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    List<ProdutosBanco> produtos = produtoDAO.GetProdctsToSend();

                    lblInfo.Text = $"Localizado {produtos.Count} produtos...";
                    await Task.Delay(100);

                    lblInfo.Text = "Tratando produtos...";
                    await Task.Delay(100);

                    List<ProdutosApi> produtosApi = produtos.Select(row => new ProdutosApi
                    {
                        Codigo = row.Codigo,
                        CodigoBarras = row.Ean,
                        Ncm = row.Ncm,
                        Descricao = row.Descricao,
                        Cest = row.Cest,
                        Cfop = row.Cfop,
                        IcmsCst = row.CstCsosn,
                        IcmsAliquota = row.IcmsAliq,
                        IcmsAliquotaReduzida = row.RedIcms,
                        RedBcDe = "0.0", // Valor padrão
                        RedBcPara = "100", // Valor padrão
                        CBenef = string.Empty, // Valor padrão
                        Protege = 0, // Valor padrão
                        PisCst = row.PisCofinsCst,
                        PisAliquota = row.PisPerc,
                        CofinsCst = row.PisCofinsCst,
                        CofinsAliquota = row.CofinsPerc,
                        NaturezaReceita = "101" // Valor padrão
                    }).ToList();

                    // Serializar a lista de produtos para JSON
                    string jsonProdutos = JsonSerializer.Serialize(produtosApi);

                    lblInfo.Text = "Enviando produtos para a API...";
                    await Task.Delay(100);

                    // Configurar o conteúdo da requisição
                    StringContent content = new StringContent(jsonProdutos, Encoding.UTF8, "application/json");

                    // Fazer a requisição GET
                    HttpResponseMessage response = await client.PostAsync($"{ConfigReader.base_url}/enviar/", content);

                    // Garantir que a requisição foi bem-sucedida
                    response.EnsureSuccessStatusCode();
                    lblInfo.Text = "Finalizado!";

                    if (temAlerta) Funcoes.ChamaAlerta("Produtos enviados com sucesso");

                }
            }
            catch (HttpRequestException ex)
            {
                lblInfo.Text = "";
                if (temAlerta) Funcoes.ErrorMessage(ex.Message);
                Logger.Log(ex.Message, "Erro");
            }
            catch (Exception ex)
            {
                lblInfo.Text = "";
                if (temAlerta) Funcoes.ErrorMessage(ex.Message);
                Logger.Log(ex.Message, "Erro");
            }
        }
    }
}
