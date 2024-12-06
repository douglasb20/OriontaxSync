using OriontaxSync.libs;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace OriontaxSync.Classes
{
    internal class ProdutosBanco
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("codigo1")]
        public string Codigo1 { get; set; }

        [JsonPropertyName("ean")]
        public string Ean { get; set; }

        [JsonPropertyName("ncm")]
        public string Ncm { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("cest")]
        public string Cest { get; set; }

        [JsonPropertyName("cfop")]
        public int Cfop { get; set; }

        [JsonPropertyName("cst_csosn")]
        public int CstCsosn { get; set; }

        [JsonPropertyName("icms_aliq")]
        public decimal IcmsAliq { get; set; }

        [JsonPropertyName("red_icms")]
        public decimal RedIcms { get; set; }

        [JsonPropertyName("pis_cofins_cst")]
        public string PisCofinsCst { get; set; }

        [JsonPropertyName("pis_perc")]
        public decimal PisPerc { get; set; }

        [JsonPropertyName("cofins_perc")]
        public decimal CofinsPerc { get; set; }

        [JsonPropertyName("cod_classe")]
        public int CodClasse { get; set; }

        [JsonPropertyName("classe_imposto")]
        public string ClasseImposto { get; set; }

        [JsonPropertyName("ide")]
        public Guid Ide { get; set; }
    }
}
