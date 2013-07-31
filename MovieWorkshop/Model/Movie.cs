using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;

namespace MovieWorkshop.Model
{
    // TODO: i wan't to be at /movie or /movie/1
    public class Movie
    {
        [AutoIncrement]
        public long Id { get; set; } 
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
    }
}