using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class File
    {
        public string Type { get; set; }
        public string Way { get; set; }
        public int Id { get; set; }
        public int PlaceId { get; set; }
        //public virtual Place Place { get; set; }
    }
}
