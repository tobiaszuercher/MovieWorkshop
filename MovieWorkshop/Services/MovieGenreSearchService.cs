using System.Collections.Generic;

using MovieWorkshop.DAL;
using MovieWorkshop.Model;

using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace MovieWorkshop.Services
{
    public class MovieGenreSearchService : Service
    {
        public IMovieRepository MovieRepository { get; set; }

        public List<Movie> Get(MovieGenreSearchRequest request)
        {
            return MovieRepository.GetMoviesByGenre(request.Genre);
        }
    }

    [Route("/movie/genre/{genre}")]
    public class MovieGenreSearchRequest : IReturn<Movie>
    {
        public string Genre { get; set; }
    }
}