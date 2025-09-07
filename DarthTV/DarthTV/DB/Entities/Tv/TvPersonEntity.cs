namespace DarthTV.DB.Entities.Tv
{
    public class TvPersonEntity : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDirector { get; set; }
        public bool IsWriter { get; set; }
        public bool IsActor { get; set; }
    }
}
