using System;

namespace app.Models
{
    // 
    public class Resposta
    {
// : Resposta, Data de cadastro, Localização Atual - LAT e LONG
        public string Texto { get; set; }
        public DateTime DataInserção { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}