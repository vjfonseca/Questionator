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

        public ActionResult<Questionario> Get(int id)
        {
            return Ok(_repo.GetById(id));
        }
        [HttpPost]
        public ActionResult<Questionario> Create(Questionario questionario)
        {
            return Ok(_repo.Create(questionario));
        }
        [HttpPut]
        public ActionResult<Questionario> Update(Questionario questionario)
        {
            return Ok(questionario);
        }
    }
}