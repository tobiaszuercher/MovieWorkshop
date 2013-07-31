using System.Collections.Generic;

using MovieWorkshop.Model;

using ServiceStack.OrmLite;

namespace MovieWorkshop.DAL
{
    /// <summary>
    /// I received a DAL-Master achievement by writing this awesome repository :).
    /// </summary>
    public class MovieRepository : IMovieRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public Movie AddMovie(Movie movie)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.Insert(movie);
                movie.Id = db.GetLastInsertId();

                return movie;
            }
        }

        public Movie UpdateMovie(Movie movie)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.Update(movie);

                return movie;
            }
        }

        public void RemoveMovie(Movie movie)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.Delete(movie);
            }
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.Select<Movie>(m => m.Genre.ToLower() == genre.ToLower());
            }
        }

        public List<Movie> GetAllMovies()
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.Select<Movie>();
            }
        }

        public Movie GetMovieById(long id)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.Id<Movie>(id);
            }
        }

        public void Reset()
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.CreateTable<Movie>(true);
                db.Insert(new Movie() { Genre = "Action", Title = "The Matrix", ReleaseYear = 1999 });
                db.Insert(new Movie() { Genre = "Action", Title = "Gladiator", ReleaseYear = 2000 });
            }
        }
    }
}