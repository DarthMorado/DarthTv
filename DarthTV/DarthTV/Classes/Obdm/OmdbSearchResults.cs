namespace DarthTV.Classes.Obdm
{
    public class OmdbSearchResults
    {
        public List<OmdbItem> Search { get; set; }
        public int totalResults { get; set; }
        public bool Response { get; set; }
    }
}
