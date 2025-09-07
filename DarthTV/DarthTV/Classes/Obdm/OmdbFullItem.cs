namespace DarthTV.Classes.Obdm
{
    public class OmdbFullItem
    {
        //"Title": "Prison Break",
        public string Title { get; set; }
        //"Year": "2005–2017",
        public string Year { get; set; }
        //"Rated": "TV-14",
        public string Rated { get; set; }
        //"Released": "29 Aug 2005",
        public string Released { get; set; }
        //"Runtime": "44 min",
        public string Runtime { get; set; }
        //"Genre": "Action, Crime, Drama",
        public string Genre { get; set; }
        //"Director": "N/A",
        public string Director { get; set; }
        //"Writer": "Paul T. Scheuring",
        public string Writer { get; set; }
        //"Actors": "Dominic Purcell, Wentworth Miller, Amaury Nolasco",
        public string Actors { get; set; }
        //"Plot": "A structural engineer installs himself in a prison he helped design, in order to save his falsely accused brother from a death sentence by breaking themselves out from the inside.",
        public string Plot { get; set; }
        //"Language": "English, Spanish, Arabic",
        public string Language { get; set; }
        //"Country": "United Kingdom, United States",
        public string Country { get; set; }
        //"Awards": "Nominated for 1 Primetime Emmy. 8 wins & 32 nominations total",
        public string Awards { get; set; }
        //"Poster": "https://m.media-amazon.com/images/M/MV5BMTg3NTkwNzAxOF5BMl5BanBnXkFtZTcwMjM1NjI5MQ@@._V1_SX300.jpg",
        public string Poster { get; set; }
        //"Ratings": [
        //],
        public List<OmdbRatingSource> Ratings { get; set; }
        //"Metascore": "N/A",
        public string Metascore { get; set; }
        //"imdbRating": "8.3",
        public string imdbRating { get; set; }
        //"imdbVotes": "608,495",
        public string imdbVotes { get; set; }
        //"imdbID": "tt0455275",
        public string imdbID { get; set; }
        //"Type": "series",
        public string Type { get; set; }
        //"totalSeasons": "5",
        public string totalSeasons { get; set; }
        //"Response": "True"
        public string Response { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
    }
}
