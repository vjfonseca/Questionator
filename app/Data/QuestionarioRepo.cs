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
        public void AddPergunta(Pergunta pergunta)
        {
            _context.Find(x => x.Id == pergunta.IdQuestionario).Perguntas.Add(pergunta);
        }
        public void AddResposta(Resposta resposta)
        {
            int questId = _context.Select(q =>
            {
                q.Perguntas.Find(p => p.Id == resposta.PerguntaId);
                return q;
            }).First().Id;

            _context.First(q => q.Id == questId).Perguntas
                    .First(p => p.Id == resposta.PerguntaId).Respostas
                    .Add(resposta);
        }
        public void Create(Questionario questionario)
        {
            _context.Add(questionario);
        }
        public IEnumerable<Questionario> GetAll(int userId)
        {
            var q = _context.Where(x => x.UsuarioId == userId).ToList();
            return q;
        }
        public Questionario GetById(int id)
        {
            return _context.FirstOrDefault<Questionario>(x => x.Id == id);
        }
        public bool hasPergunta(int id)
        {
            var p = _context.Select(q =>
            {
                Pergunta p = q.Perguntas.First(p => p.Id == id);
                return p;
            }).First();
            return p.Id == id;
        }
    }
}