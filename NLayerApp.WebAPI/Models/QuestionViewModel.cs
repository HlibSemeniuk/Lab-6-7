namespace NLayerApp.WebAPI
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }

        public virtual PlaceViewModel Place { get; set; }
    }
}