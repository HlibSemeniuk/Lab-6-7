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
    public class FileService : IFileService
    {

        IUnitOfWork Database { get; set; }

        public FileService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddFile(FileDTO file)
        {
            Mapper.CreateMap<PlaceDTO, Place>();
            Mapper.CreateMap<QuestionDTO, Question>();
            Mapper.CreateMap<FileDTO, File>();
            Database.Files.Add(Mapper.Map<FileDTO, File>(file));
            Database.Save();
        }

        public void ChangeFileInfo(FileDTO fileDTO)
        {
            Mapper.CreateMap<PlaceDTO, Place>();
            Mapper.CreateMap<FileDTO, File>();
            Mapper.CreateMap<QuestionDTO, Question>();

            Database.Files.Update(Mapper.Map<FileDTO, File>(fileDTO));
            Database.Save();
        }

        public void DeleteFile(int FileId)
        {
            Database.Files.Delete(Database.Files.Get(FileId));
            Database.Save();
        }

        public IEnumerable<FileDTO> GetAll()
        {
            Mapper.CreateMap<Place, PlaceDTO>();
            Mapper.CreateMap<File, FileDTO>();
            Mapper.CreateMap<Question, QuestionDTO>();
            return Mapper.Map<IEnumerable<File>, List<FileDTO>>(Database.Files.GetAll());
        }

        public FileDTO GetById(int id)
        {
            Mapper.CreateMap<Place, PlaceDTO>();
            Mapper.CreateMap<File, FileDTO>();
            Mapper.CreateMap<Question, QuestionDTO>();
            return Mapper.Map<File, FileDTO>(Database.Files.Get(id));
        }
    }
}
