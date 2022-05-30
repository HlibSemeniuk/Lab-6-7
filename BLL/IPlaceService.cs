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
        void AddQuestiom(int id, string question);
        void AddFile(int id, FileDTO file);
        void AddAnswer(int id, QuestionDTO question);
        void ChangePlaceInfo(PlaceDTO placeDTO);
        void ChangeQuestionInfo(QuestionDTO questionDTO);
        void ChangeFileInfo(FileDTO fileDTO);
        void Dispose();
    }
}
