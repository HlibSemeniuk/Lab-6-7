using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }

       //public virtual PlaceDTO Place { get; set; }
    }
}
