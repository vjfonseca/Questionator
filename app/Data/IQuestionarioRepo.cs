using app.Models;

namespace app.Data
{
    public interface IQuestionarioRepo
    {
        public Questionario GetById(int id);
        public Questionario Create(Questionario questionario);
    }
}