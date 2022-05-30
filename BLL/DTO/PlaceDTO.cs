using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public string Comment { get; set; }
        public virtual ICollection<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();
        public virtual ICollection<FileDTO> Files { get; set; } = new List<FileDTO>();
    }
}
