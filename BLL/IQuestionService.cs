using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IQuestionService
    {
        void AddAnswer(int id, string answer);
        void AddQuestiom(int id, string question);
        void ChangeQuestionInfo(QuestionDTO questionDTO);
        void DeleteQuestion(int QuestionId);
    }
}
