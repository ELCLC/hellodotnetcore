using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace hellodotnetcore
{
    public class Paths {
        public static string MOVIE_PATH = "movie/{movieId}?api_key={apiKey}";
    }

    public class TMDBAPIClient
    {
        static string API_KEY = "7172077c673079742b28032cbffe3b78";
        static HttpClient client = new HttpClient();

        public static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Get the movie
                Movie movie = await GetMovieAsync("550");
                Console.WriteLine(movie.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static async Task<Movie> GetMovieAsync(string movieId)
        {
            Movie movie = null;
            string path = Paths.MOVIE_PATH.Replace("{movieId}", movieId).Replace("{apiKey}", API_KEY);
            Console.WriteLine(path);
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                movie = await response.Content.ReadAsAsync<Movie>();
            }
            return movie;
        }
    }
}
