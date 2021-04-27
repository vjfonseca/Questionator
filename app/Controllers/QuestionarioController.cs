using System.Collections.Generic;
using app.Data;
using app.Models;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    public class QuestionarioController : ControllerBase
    {
        private readonly IQuestionarioRepo _repo;
        public QuestionarioController(IQuestionarioRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Questionario>> GetAll(int userId)
        {
            var data = _repo.GetAll(userId);
            return Ok(data);
        }
        [HttpGet]
        public ActionResult<Questionario> GetById(int id)
        {
            var q = _repo.GetById(id);
            if (q.Titulo == null)
            {
                return NotFound("Id de questionario Invalido");
            }
            return Ok(q);
        }
        [HttpPost]
        public ActionResult<Questionario> Create([FromBody] Questionario questionario)
        {
            if (questionario == null) return StatusCode(499);
            if (questionario.Titulo == null) return StatusCode(499);
            _repo.Create(questionario);
            var q = _repo.GetById(questionario.Id);
            return Ok(q);
        }
        [HttpPost]
        public ActionResult<Questionario> AddPergunta([FromBody] Pergunta pergunta)
        {
            _repo.AddPergunta(pergunta);
            return Ok(_repo.GetById(pergunta.IdQuestionario));
        }
        [HttpPost]
        public ActionResult<IEnumerable<Questionario>> AddResposta([FromBody] Resposta resposta)
        {
            if (!_repo.hasPergunta(resposta.PerguntaId))
            {
                return BadRequest("Pergunta não encontrada.");
            }
            _repo.AddResposta(resposta);
            return Ok("pergunta adicionada");
        }
    }
}