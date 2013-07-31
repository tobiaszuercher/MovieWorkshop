using System.Collections.Generic;

using MovieWorkshop.Model;

namespace MovieWorkshop.DAL
{
    public interface IMovieRepository
    {
        Movie AddMovie(Movie movie);
        
        void RemoveMovie(Movie movie);
        
        List<Movie> GetMoviesByGenre(string genre);
        
        void Reset();

        List<Movie> GetAllMovies();

        Movie GetMovieById(long id);

        Movie UpdateMovie(Movie movie);
    }
}