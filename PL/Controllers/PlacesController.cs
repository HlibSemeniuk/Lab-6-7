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

        public PlacesController(IPlaceService service)
        {
            this.placeService = service;
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
            placeService.AddQuestiom(placeId, question);
        }



        // PUT: api/Places/5
        public void Put()
        {
        }

        // DELETE: api/Places/5
        public void Delete(int id)
        {
        }
    }
}
