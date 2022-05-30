using AutoMapper;
using BLL;
using BLL.DTO;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PL.Controllers
{
    public class PlacesController : ApiController
    {

        IPlaceService placeService;
        IQuestionService questionService;
        IFileService fileService;

        public PlacesController(IPlaceService service, IQuestionService questionService, IFileService fileService)
        {
            this.placeService = service;
            this.questionService = questionService;
            this.fileService = fileService;
        }

        // GET: api/Places
        public IEnumerable<PlaceViewModel> Get()
        {
            Mapper.CreateMap<PlaceDTO, PlaceViewModel>();
            Mapper.CreateMap<QuestionDTO, QuestionViewModel>();
            Mapper.CreateMap<FileDTO, FileViewModel>();
            return Mapper.Map<IEnumerable<PlaceDTO>, List<PlaceViewModel>>(placeService.GetPlaces());
        }

        // GET: api/Places/5
        public PlaceViewModel Get(int id)
        {
            Mapper.CreateMap<PlaceDTO, PlaceViewModel>();
            Mapper.CreateMap<QuestionDTO, QuestionViewModel>();
            Mapper.CreateMap<FileDTO, FileViewModel>();
            return Mapper.Map<PlaceDTO, PlaceViewModel>(placeService.GetPlace(id));
        }

        [Route("api/Places/GetQuestionsForPlace/{id}")]
        [HttpGet]
        public List<QuestionViewModel> GetQuestionsForPlace(int id)
        {
            Mapper.CreateMap<PlaceDTO, PlaceViewModel>();
            Mapper.CreateMap<QuestionDTO, QuestionViewModel>();
            Mapper.CreateMap<FileDTO, FileViewModel>();
            return Mapper.Map<IEnumerable<QuestionDTO>, List<QuestionViewModel>>(placeService.GetPlace(id).Questions);
        }

        // POST: api/Places
        public void Post(PlaceViewModel model)
        {
            Mapper.CreateMap<PlaceViewModel, PlaceDTO>();
            Mapper.CreateMap<QuestionViewModel, QuestionDTO>();
            Mapper.CreateMap<FileViewModel, FileDTO>();
            placeService.AddPlace(Mapper.Map<PlaceViewModel, PlaceDTO>(model));
        }

        [Route("api/Places/AddQuestionForPlace")]
        [HttpPost]
        public void AddQuestionForPlace(int placeId, string question)
        {
            questionService.AddQuestiom(placeId, question);
        }

        [Route("api/Places/AddAnswer")]
        [HttpPost]
        public void AddAnswer(int questionId, string answer)
        {
            Mapper.CreateMap<PlaceViewModel, PlaceDTO>();
            Mapper.CreateMap<QuestionViewModel, QuestionDTO>();
            Mapper.CreateMap<FileViewModel, FileDTO>();
           
            questionService.AddAnswer(questionId, answer);
        }

        [Route("api/Places/AddCommentForPlace")]
        [HttpPost]
        public void AddCommentForPlace(int placeId, string comment)
        {
            placeService.AddComment(placeId, comment);
        }

        [Route("api/Places/AddFileForPlace")]
        [HttpPost]
        public void AddFile(int placeId, string way, string type)
        {
            FileViewModel file = new FileViewModel() { PlaceId = placeId, Way = way, Type = type };

            Mapper.CreateMap<PlaceViewModel, PlaceDTO>();
            Mapper.CreateMap<QuestionViewModel, QuestionDTO>();
            Mapper.CreateMap<FileViewModel, FileDTO>();
            fileService.AddFile(Mapper.Map<FileViewModel, FileDTO>(file));
        }



        // PUT:

        [Route("api/Places/ChangePlaceInfo")]
        [HttpPut]
        public void ChangePlaceInfo(PlaceViewModel place)
        {
            Mapper.CreateMap<PlaceViewModel, PlaceDTO>();
            Mapper.CreateMap<QuestionViewModel, QuestionDTO>();
            Mapper.CreateMap<FileViewModel, FileDTO>();


            placeService.ChangePlaceInfo(Mapper.Map<PlaceViewModel, PlaceDTO>(place));

        }

        [Route("api/Places/ChangeQuestionInfo")]
        [HttpPut]
        public void ChangeQuestionInfo(QuestionViewModel question)
        {
            Mapper.CreateMap<PlaceViewModel, PlaceDTO>();
            Mapper.CreateMap<QuestionViewModel, QuestionDTO>();
            Mapper.CreateMap<FileViewModel, FileDTO>();
            questionService.ChangeQuestionInfo(Mapper.Map<QuestionViewModel, QuestionDTO>(question));
        }

        [Route("api/Places/ChangeFileInfo")]
        [HttpPut]
        public void ChangeFileInfo(FileViewModel file)
        {
            Mapper.CreateMap<PlaceViewModel, PlaceDTO>();
            Mapper.CreateMap<QuestionViewModel, QuestionDTO>();
            Mapper.CreateMap<FileViewModel, FileDTO>();
            fileService.ChangeFileInfo(Mapper.Map<FileViewModel, FileDTO>(file));
        }

        // DELETE: api/Places/5
        public void Delete(int id)
        {
        }
    }
}
