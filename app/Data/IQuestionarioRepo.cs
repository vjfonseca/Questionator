using System.Collections.Generic;
using app.Models;

namespace app.Data
{
    public interface IQuestionarioRepo
    {
        public Questionario GetById(int id);
        public IEnumerable<Questionario> GetAll(int userId);
        public Questionario Create(Questionario questionario);
        public Questionario AddResposta(Resposta resposta);
        public Questionario AddPergunta(Pergunta pergunta);
    }
}