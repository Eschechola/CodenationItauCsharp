using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Answer
    {
        [JsonProperty("numero_casas")]
        public int NumeroCasas { get; set; }
        public string Token { get; set; }
        public string Cifrado { get; set; }
        public string Decifrado { get; set; }
        [JsonProperty("resumo_criptografico")]
        public string ResumoCriptografico { get; set; }
    }
}
