using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class FileDTO
    {
        public string Type { get; set; }
        public string Way { get; set; }
        public int Id { get; set; }
        public int PlaceId { get; set; }
        //public virtual PlaceDTO Place { get; set; }
    }
}
