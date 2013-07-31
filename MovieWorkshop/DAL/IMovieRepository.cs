using System.Collections.Generic;

using MovieWorkshop.Model;

namespace MovieWorkshop.DAL
{
    public interface IMovieRepository
    {
        Movie AddMovie(Movie movie);
        Movie GetMovieById(long id);
        List<Movie> GetAllMovies();
        List<Movie> GetMoviesByGenre(string genre);
        Movie UpdateMovie(Movie movie);
        void Reset();
        void RemoveMovie(Movie movie);
    }
}