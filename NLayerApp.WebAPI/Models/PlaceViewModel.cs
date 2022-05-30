using System.Collections.Generic;

namespace NLayerApp.WebAPI
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public string Comment { get; set; }
        public virtual ICollection<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
        public virtual ICollection<FileViewModel> Files { get; set; } = new List<FileViewModel>();
    }
}
