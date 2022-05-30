using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class Question
    {
        public int Id { get; set; }
        public int PlaceID { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }

        //public virtual Place Place { get; set; }
    }
}
