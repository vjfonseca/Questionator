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
            if (q == null)
            {
                return NotFound("Id de questionario Invalido");
            }
            return Ok(q);
        }
        [HttpPost]
        public ActionResult<Questionario> Create([FromBody] Questionario questionario)
        {
            var q = _repo.Create(questionario);
            if (q == null) throw new System.Exception();
            return Ok(q);
        }
        [HttpPost]
        public ActionResult<Questionario> AddPergunta([FromBody] Pergunta pergunta)
        {
            var q = _repo.AddPergunta(pergunta);
            return Ok(q);
        }
        [HttpPost]
        public ActionResult<Questionario> AddResposta([FromBody] Resposta resposta)
        {
            var q = _repo.AddResposta(resposta);
            return Ok(q);
        }
    }
}