using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int PlaceID { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }

        //public virtual PlaceDTO Place { get; set; }
    }
}