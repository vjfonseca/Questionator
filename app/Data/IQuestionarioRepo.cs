using System.Collections.Generic;
using app.Models;

namespace app.Data
{
    public interface IQuestionarioRepo
    {
        public Questionario GetById(int id);
        public IEnumerable<Questionario> GetAll(int userId);
        public void Create(Questionario questionario);
        public void AddResposta(Resposta resposta);
        public void AddPergunta(Pergunta pergunta);
        public bool hasPergunta(int id);
    }
}