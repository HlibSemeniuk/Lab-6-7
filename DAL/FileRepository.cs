using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileRepository : GenericRepository<File>, IFileRepository
    {
        public FileRepository(PlaceContext context) : base(context)
        {
        }
    }
}
