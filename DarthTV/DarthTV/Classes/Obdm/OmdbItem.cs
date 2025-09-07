namespace DarthTV.Classes.Obdm
{
    public class OmdbItem
    {
        public string Title { get; set; }
        public string Year { get; set; }//int
        public string imdbID { get; set; }
        public string Type { get; set; }//enum
        private string _Poster;
        public string Poster { 
            get
            {
                return _Poster;
            }
            set
            {
                if (value is null) _Poster = null;
                if (String.IsNullOrWhiteSpace(value)) _Poster = null;
                _Poster = value;
            }
        }
    }
}
