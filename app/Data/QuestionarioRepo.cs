using System.Collections.Generic;
using System.Linq;
using app.Models;

namespace app.Data
{
    public class QuestionarioRepo : IQuestionarioRepo
    {
        private List<Questionario> _context;
        public QuestionarioRepo()
        {
            _context = new List<Questionario>();
        }

        public Questionario AddPergunta(Pergunta pergunta)
        {
            _context.Find(x => x.Id == pergunta.IdQuestionario).Perguntas.Add(pergunta);
            return _context.FirstOrDefault(x => x.Id == pergunta.IdQuestionario);
        }
        public Questionario AddResposta(Resposta resposta)
        {
            var q = _context.Select(q =>
            {
                q.Perguntas.First(p => p.Id == resposta.PerguntaId).Respostas.Add(resposta);        
                return q;
            }).ToList().First();
            return q;
        }
        public Questionario Create(Questionario questionario)
        {
            _context.Add(questionario);
            return _context.FirstOrDefault(x => x.Id == questionario.Id);
        }
        public IEnumerable<Questionario> GetAll(int userId)
        {
            var q = _context.Where(x => x.UsuarioId == userId);
            return q;
        }
        public Questionario GetById(int id)
        {
            return _context.FirstOrDefault<Questionario>(x => x.Id == id);
        }
    }
}