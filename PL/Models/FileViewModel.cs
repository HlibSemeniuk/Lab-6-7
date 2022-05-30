using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class FileViewModel
    {
        public string Type { get; set; }
        public string Way { get; set; }
        public int Id { get; set; }
        public int PlaceId { get; set; }
        //public virtual PlaceViewModel Place { get; set; }
    }
}