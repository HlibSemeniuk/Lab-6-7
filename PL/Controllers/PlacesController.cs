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

        // POST: api/Places
        public void Post(PlaceViewModel model)
        {
            Mapper.CreateMap<PlaceViewModel, PlaceDTO>();
            Mapper.CreateMap<QuestionViewModel, QuestionDTO>();
            Mapper.CreateMap<FileViewModel, FileDTO>();
            placeService.AddPlace(Mapper.Map<PlaceViewModel, PlaceDTO>(model));
        }

        // PUT: api/Places/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Places/5
        public void Delete(int id)
        {
        }
    }
}
