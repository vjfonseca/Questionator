using System;
using System.Collections.Generic;

namespace app.Models
{
    public class Questionario
    {
        //  Título, Usuário, Data de cadastro
        public string Titulo { get; set; }    
        public string Usuario { get; set; }
        public DateTime DataInserção { get; set; }
        public IEnumerable<Resposta> Respostas { get; set; }
    }
}