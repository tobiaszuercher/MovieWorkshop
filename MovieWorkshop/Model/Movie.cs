using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;

namespace MovieWorkshop.Model
{
    [Route("/movie")]
    [Route("/movie/{id}")]
    public class Movie : IReturn<Movie>
    {
        [AutoIncrement]
        public long Id { get; set; } 
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
    }
}