using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual ICollection<File> Files { get; set; } = new List<File>();
    }
}
