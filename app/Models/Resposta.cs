using System;

namespace app.Models
{
    public class Resposta
    {
        public int Id { get; set; }
        public int PerguntaId { get; set; }
        public string Texto { get; set; }
        public DateTime DataInserção { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}