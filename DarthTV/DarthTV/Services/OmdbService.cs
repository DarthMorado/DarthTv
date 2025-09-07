using DarthTV.Classes;
using DarthTV.Classes.Obdm;
using DarthTV.Classes.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace DarthTV.Services
{
    public interface IOmdbService
    {
        public List<OmdbFullItem> FullSearch(string searchString);
        public OmdbSearchResults Search(string searchString);
        public OmdbFullItem GetOmdbInfo(string imdbId);
    }

    public class OmdbService : IOmdbService
    {
        private readonly string Token = ""; // todo:token
        public OmdbService(IOptions<OmdbOptions> options)
        {
            Token = options.Value.Token;
        }

        public string SearchObmdUrl(string searchSring)
            => $"http://omdbapi.com/?apikey={Token}&s={searchSring}&r=json";

        public string ObmdInfoUrl(string imdbId)
            => $"http://omdbapi.com/?apikey={Token}&r=json&i={imdbId}";

        public OmdbSearchResults Search(string searchString)
        {
            var client = new RestClient(SearchObmdUrl(searchString));
            var request = new RestRequest();
            var response = client.Get(request);
            var content = response.Content;
            var searchResults = JsonConvert.DeserializeObject<OmdbSearchResults>(content);

            return searchResults;
        }

        public List<OmdbFullItem> FullSearch(string searchString)
        {
            var searchResults = Search(searchString);


            if (searchResults is null || searchResults.totalResults == 0)
            {
                return new();
            }

            var results = new List<OmdbFullItem>();

            foreach (var item in searchResults.Search)
            {
                if (String.IsNullOrWhiteSpace(item.imdbID))
                {
                    continue;
                }
                var fullResult = GetOmdbInfo(item.imdbID);
                results.Add(fullResult);
            }

            return results;
        }

        public OmdbFullItem GetOmdbInfo(string imdbId)
        {
            var client = new RestClient(ObmdInfoUrl(imdbId));
            var request = new RestRequest();
            var response = client.Get(request);
            var content = response.Content;
            var results = JsonConvert.DeserializeObject<OmdbFullItem>(content);

            return results;
        }
    }
}
