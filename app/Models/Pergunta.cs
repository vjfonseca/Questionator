using System;
using System.Collections.Generic;

namespace app.Models
{
    public class Pergunta
    {
        public string Texto { get; set; }
        public int Id { get; set; }
        public int IdQuestionario { get; set; }
        public List<Resposta> Respostas { get; set; } = new List<Resposta>();
        public DateTime DataInserção { get; set; }
    }
}