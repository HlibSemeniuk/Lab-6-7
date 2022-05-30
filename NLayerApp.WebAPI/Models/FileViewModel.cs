namespace NLayerApp.WebAPI
{
    public class FileViewModel
    {
        public string Type { get; set; }
        public string Way { get; set; }
        public int Id { get; set; }
        public virtual PlaceViewModel Place { get; set; }
    }
}