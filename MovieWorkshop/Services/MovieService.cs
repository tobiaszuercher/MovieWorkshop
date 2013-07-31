using System.Collections.Generic;

using MovieWorkshop.DAL;
using MovieWorkshop.Model;

using ServiceStack.FluentValidation;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace MovieWorkshop.Services
{
    public class MovieService : Service
    {
        public IMovieRepository MovieRepository { get; set; }

        public object Get(Movie request)
        {
            if (request.Id == default(long))
            {
                return MovieRepository.GetAllMovies();
            }

            return new List<Movie>() { MovieRepository.GetMovieById(request.Id) };
        }

        public Movie Post(Movie request)
        {
            return MovieRepository.AddMovie(request);
        }

        public object Put(Movie request)
        {
            return MovieRepository.UpdateMovie(request);
        }

        public void Delete(Movie request)
        {
            MovieRepository.RemoveMovie(request);
        }
    }

    public class MovieValidator : AbstractValidator<Movie>
    {
        public IDuplicateValidator DuplicateValidator { get; set; }
        
        public MovieValidator()
        {
            // apply different validation to Put/Post
            RuleSet(ApplyTo.Put | ApplyTo.Delete, () => RuleFor(m => m.Id).NotEmpty().GreaterThan(0));
            RuleSet(ApplyTo.Post, () => RuleFor(m => m.Title).Must(title => DuplicateValidator.ValidateIsNotDuplicate(title)).WithMessage("Duplicate detected"));
        }
    }

    public class DuplicateValidator : IDuplicateValidator
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; } // demonstrate that we can inject object and do more complex validaton

        public bool ValidateIsNotDuplicate(string title)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.Select<Movie>(m => m.Title == title).Count == 0;
            }
        }
    }

    public interface IDuplicateValidator
    {
        bool ValidateIsNotDuplicate(string title);
    }
}