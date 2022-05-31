using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuestionService : IQuestionService
    {
        IUnitOfWork Database { get; set; }

        public QuestionService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddAnswer(int id, string answer)
        {
            Question question = Database.Questions.Get(id);
            question.Answer = answer;
            Database.Save();
        }

        public void AddQuestiom(int PlaceId, string question)
        {
            Database.Places.Get(PlaceId).Questions.Add(new Question() { Description = question });
            Database.Save();
        }

        public void ChangeQuestionInfo(QuestionDTO questionDTO)
        {
            Mapper.CreateMap<PlaceDTO, Place>();
            Mapper.CreateMap<FileDTO, File>();
            Mapper.CreateMap<QuestionDTO, Question>();
            Database.Questions.Update(Mapper.Map<QuestionDTO, Question>(questionDTO));
            Database.Save();
        }

        public void DeleteQuestion(int QuestionId)
        {
            Database.Questions.Delete(Database.Questions.Get(QuestionId));
            Database.Save();
        }

        public IEnumerable<QuestionDTO> GetAll()
        {
            Mapper.CreateMap<Place, PlaceDTO>();
            Mapper.CreateMap<File, FileDTO>();
            Mapper.CreateMap<Question, QuestionDTO>();
            return Mapper.Map<IEnumerable<Question>, List<QuestionDTO>>(Database.Questions.GetAll());
        }
    }
}
