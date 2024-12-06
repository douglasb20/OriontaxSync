using OriontaxSync.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Forms;

namespace OriontaxSync.libs.DAOSVR
{
    internal class ClasseImpostoDAO : DefaultModel
    {
        [JsonPropertyName("codigo")]
        public int Codigo { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("data_alteracao")]
        public string DataAlteracao { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("ide")]
        public Guid Ide { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("save_web")]
        public bool SaveWeb { get; set; }

        public ClasseImpostoDAO()
        {
            this.tabela = "classeimposto";
        }

        public ClasseImpostoDAO GetClasseImposto(ProdutosApi produtoApi)
        {
            try
            {

                string query =  "SELECT codigo, id, nome, ide FROM ClasseImposto WHERE status = 0" +
                                " AND ide IN (SELECT ClasseImposto__Ide FROM ClasseImpostoOperacao" +
                                " WHERE CONVERT(INT, IcmsCst) = @IcmsCst" +
                                " AND Cfop__Codigo = @Cfop" +
                                " AND IcmsPerc = @IcmsAliquota" +
                                " AND PisCofinsTipo = @PisCst" +
                                " AND PisPerc = @PisAliquota" +
                                " AND CofinsPerc = @CofinsAliquota" +
                                (produtoApi.IcmsCst == 20 ?
                                    " AND IcmsPercDeson = @IcmsPercDeson AND IcmsPercRedBc = @IcmsPercRedBc" : "") +
                                " AND Operacao__Codigo = 500" +
                                " GROUP BY ClasseImposto__Ide)";

                string FormatDecimal(decimal? value)
                {
                    return value?.ToString(CultureInfo.InvariantCulture) ?? "0.0";
                }

                // Criando o comando SQL com parâmetros
                query = query.Replace("@IcmsCst", produtoApi.IcmsCst.ToString())
                             .Replace("@Cfop", produtoApi.Cfop.ToString())
                             .Replace("@IcmsAliquota", FormatDecimal(produtoApi.IcmsAliquota))
                             .Replace("@PisCst", produtoApi.PisCst)
                             .Replace("@PisAliquota", FormatDecimal(produtoApi.PisAliquota))
                             .Replace("@CofinsAliquota", FormatDecimal(produtoApi.CofinsAliquota));

                // Verificando a condição específica para IcmsCst = 20
                if (produtoApi.IcmsCst == 20)
                {
                    query = query.Replace("@IcmsPercDeson", (produtoApi.IcmsAliquota - produtoApi.IcmsAliquotaReduzida).ToString())
                                 .Replace("@IcmsPercRedBc", FormatDecimal((decimal?)produtoApi.RedBcDe));
                }

                DataTable resp = this.ExecuteQuery(query);

                if (resp.Rows.Count == 0) return null;
                // TODO: Validar valor vindo do RedBcDe
                List<ClasseImpostoDAO> classe = resp.AsEnumerable()
                .Select(row => new ClasseImpostoDAO
                {
                    Codigo = row.Field<int>("codigo"),
                    Nome = row.Field<string>("nome"),
                    Ide = row.Field<Guid>("ide"),
                    Id = row.Field<int>("id"),
                })
                .ToList();

                return classe.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
