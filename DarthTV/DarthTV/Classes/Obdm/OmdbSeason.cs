namespace DarthTV.Classes.Obdm
{
    public class OmdbSeason
    {
        public string Title { get; set; }
        public string Season { get; set; }
        public string totalSeasons { get; set; }
        public string Response { get; set; }
        public List<OmdbEpisode> Episodes { get; set; }
    }
}
