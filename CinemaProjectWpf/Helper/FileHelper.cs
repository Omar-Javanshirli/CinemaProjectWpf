using CinemaProjectWpf.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.Helper
{
    public class FileHelper
    {
        public static void WriteMovie(List<Movie> movie)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("movies.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, movie);
                }
            }
        }

        public static List<Movie> ReadMovies()
        {
            List<Movie> movies = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("movies.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    movies = serializer.Deserialize<List<Movie>>(jr);
                }
            }
            return movies;
        }
    }
}
