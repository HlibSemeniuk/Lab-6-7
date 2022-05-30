using BLL.DTO;
using DAL;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL
{
    public class PlaceService : IPlaceService
    {
        IUnitOfWork Database { get; set; }

        public PlaceService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<PlaceDTO> GetPlaces()
        {
            Mapper.CreateMap<Place, PlaceDTO> ();
            Mapper.CreateMap<File, FileDTO>();
            Mapper.CreateMap<Question, QuestionDTO>();
            return Mapper.Map<IEnumerable<Place>, List<PlaceDTO>> (Database.Places.GetAll());
        }

        public PlaceDTO GetPlace(int id)
        {
            Mapper.CreateMap<Place, PlaceDTO>();
            Mapper.CreateMap<File, FileDTO>();
            Mapper.CreateMap<Question, QuestionDTO>();
            return Mapper.Map<Place, PlaceDTO>(Database.Places.Get(id));
        }

        public void AddPlace(PlaceDTO placeDTO)
        {
            Mapper.CreateMap<PlaceDTO, Place>();
            Mapper.CreateMap<FileDTO, File>();
            Mapper.CreateMap<QuestionDTO, Question>();
            Place temp = Mapper.Map<PlaceDTO, Place>(placeDTO);
            
            Database.Places.Add(temp);
            Database.Save();
        }

        public void AddComment(int id, string comment)
        {
            Database.Places.Get(id).Comment = comment;
            Database.Save();
        }

        public void AddQuestiom(int id, string question)
        {
            Database.Places.Get(id).Questions.Add(new Question() { Description = question });
            Database.Save();
        }

        public void AddFile(int id, FileDTO file)
        {
            Database.Places.Get(id).Files.Add(new File() { Type = file.Type, Way = file.Way });
            Database.Save();
        }

        public void AddAnswer(int id, QuestionDTO question)
        {
            Place place = Database.Places.Get(id);
            place.Questions.ElementAt(question.Id - 1).Answer = question.Answer;
            Database.Save();
        }

        public void ChangePlaceInfo(PlaceDTO placeDTO)
        {
            Mapper.CreateMap<PlaceDTO, Place>();
            Mapper.CreateMap<FileDTO, File>();
            Mapper.CreateMap<QuestionDTO, Question>();

            Database.Places.Update(Mapper.Map<PlaceDTO, Place>(placeDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void ChangeQuestionInfo(QuestionDTO questionDTO)
        {
            Mapper.CreateMap<PlaceDTO, Place>();
            Mapper.CreateMap<FileDTO, File>();
            Mapper.CreateMap<QuestionDTO, Question>();
        }

        public void ChangeFileInfo(FileDTO fileDTO)
        {
            throw new NotImplementedException();
        }
    }
}
