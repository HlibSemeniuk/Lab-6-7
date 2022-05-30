using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPlaceService : IDisposable
    {
        IEnumerable<PlaceDTO> GetPlaces();
        PlaceDTO GetPlace(int id);
        void AddPlace(PlaceDTO placeDTO);
        void AddComment(int id, string comment);
        void ChangePlaceInfo(PlaceDTO placeDTO);
        void Dispose();
    }
}
