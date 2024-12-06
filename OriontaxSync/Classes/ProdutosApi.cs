using OriontaxSync.libs;
using OriontaxSync.libs.DAOSVR;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {ConfigReader.GetConfigValue("Sistema", "token")}");

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

                    int i = 1;
                    foreach (ProdutosApi prod in produtosApi)
                    {
                        try
                        {
                            if (i == 3) break;
                            string title = $"Ajustando produto {i} de {produtosApi.Count}\r\n";
                            lblInfo.Text = title + "Atualizando produto";
                            await Task.Delay(10);
                            ClasseImpostoDAO classeImpostoDAO = new ClasseImpostoDAO();
                            ClasseImpostoDAO ret =  classeImpostoDAO.GetClasseImposto(prod);

                            string json = JsonSerializer.Serialize(ret, new JsonSerializerOptions { WriteIndented = true });
                            Console.WriteLine(json);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao processar produto {i}: {ex.Message}");
                            continue;
                        }
                        finally
                        {
                            i++;
                        }
                    }

                    lblInfo.Text = "Finalizado...";
                    await Task.Delay(100);
                    // Mostrar o resultado
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
                    List<ProdutosApi> produtosApi = new List<ProdutosApi>();
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {ConfigReader.GetConfigValue("Sistema", "token")}");

                    lblInfo.Text = "Consultando produtos no banco...";
                    await Task.Delay(100);
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    List<ProdutosBanco> produtos = produtoDAO.GetProdctsToSend();

                    lblInfo.Text = $"Localizado {produtos.Count} produtos...";
                    await Task.Delay(100);

                    lblInfo.Text = "Tratando produtos...";
                    await Task.Delay(100);

                    foreach (var produtoBanco in produtos)
                    {
                        ProdutosApi prodApi = new ProdutosApi
                        {
                            Codigo = produtoBanco.Codigo,
                            CodigoBarras = produtoBanco.Ean,
                            Ncm = produtoBanco.Ncm,
                            Descricao = produtoBanco.Descricao,
                            Cest = produtoBanco.Cest,
                            Cfop = produtoBanco.Cfop,
                            IcmsCst = produtoBanco.CstCsosn,
                            IcmsAliquota = produtoBanco.IcmsAliq,
                            IcmsAliquotaReduzida = produtoBanco.RedIcms,
                            RedBcDe = "0.0", // Valor padrão
                            RedBcPara = "100", // Valor padrão
                            CBenef = string.Empty, // Valor padrão
                            Protege = 0, // Valor padrão
                            PisCst = produtoBanco.PisCofinsCst,
                            PisAliquota = produtoBanco.PisPerc,
                            CofinsCst = produtoBanco.PisCofinsCst,
                            CofinsAliquota = produtoBanco.CofinsPerc,
                            NaturezaReceita = "101" // Valor padrão
                        };

                        produtosApi.Add(prodApi);
                    }

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
