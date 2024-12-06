using System;
using System.Text.Json.Serialization;

namespace OriontaxSync.Classes
{
    internal class ClasseImpostoBanco
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
    }
}
