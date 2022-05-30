using AutoMapper;
using BLL;
using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLayerApp.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        IPlaceService placeService;
        
        public ValuesController()
        {
            IUnitOfWork uow = new UnitOfWork("DB");
            placeService = new PlaceService(uow);
        }

        public ValuesController(IPlaceService serv)
        {
            placeService = serv;
        }

        // GET: api/Places/
        public IEnumerable<PlaceViewModel> GetPlaces()
        {
            Mapper.CreateMap<PlaceDTO, PlaceViewModel>();
            Mapper.CreateMap<QuestionDTO, QuestionViewModel>();
            Mapper.CreateMap<FileDTO, FileViewModel>();
            List<PlaceViewModel> places = Mapper.Map<IEnumerable<PlaceDTO>, List<PlaceViewModel>>(placeService.GetPlaces());
            return places;
        }

        // GET api/values/5
        public string GetPlace(int id)
        {
           
                Mapper.CreateMap<PlaceDTO, PlaceViewModel>();
                var places = Mapper.Map<IEnumerable<PlaceDTO>, List<PlaceViewModel>>(placeService.GetPlaces());
                var place = places.Find(phoneId=>phoneId.Id==id);
                return place.Id + place.Name + place.Type;
        }

        
    }
}
