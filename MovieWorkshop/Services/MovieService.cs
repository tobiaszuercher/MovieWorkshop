using ServiceStack.ServiceInterface;

namespace MovieWorkshop.Services
{
    public class MovieService
    {
        // TODO: requirements for MovieService:

        // GET,POST /movie -> return all movies
        // GET      /movie/1 -> return movie with id 1
        // DELETE   /movie/1 -> delete movie with id 1
        // POST     /movie (without id) -> add movie
        // PUT      /movie/1 -> modify
        
        // note:
        // try to implement validtion logic like checking wheter the id is set for a DELETE request in a validator
        // to keep DRY principle. also add a duplicate validator which will check that no movies with the same title are added
        // use the IoC!
    }
}