using System;
using System.Collections.Generic;

namespace app.Models
{
    public class Questionario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }    
        public DateTime DataInserção { get; set; }
        public List<Pergunta> Perguntas { get; set; }  = new List<Pergunta>();
        public int UsuarioId { get; set; }
    }
}