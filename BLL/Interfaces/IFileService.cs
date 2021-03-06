using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IFileService
    {
        IEnumerable<FileDTO> GetAll();
        FileDTO GetById(int id);
        void AddFile(FileDTO file);
        void ChangeFileInfo(FileDTO fileDTO);
        void DeleteFile(int FileId);
    }
}
