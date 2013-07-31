using System.Web;

using Funq;

using MovieWorkshop.DAL;
using MovieWorkshop.Model;
using MovieWorkshop.Services;

using ServiceStack.Api.Swagger;
using ServiceStack.OrmLite;
using ServiceStack.WebHost.Endpoints;

using ServiceStack.ServiceInterface.Validation;

namespace MovieWorkshop
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("MovieWorkshop Services", typeof(MovieService).Assembly) { }

        public override void Configure(Container container)
        {
            // add needed plugins
            Plugins.Add(new SwaggerFeature());
            Plugins.Add(new ValidationFeature());

            // init db stuff
            var dbConnectionFactory = new OrmLiteConnectionFactory(HttpContext.Current.Server.MapPath("~/App_Data/db.sql"), SqliteDialect.Provider);
            container.Register<IDbConnectionFactory>(dbConnectionFactory);
            container.RegisterAutoWiredAs<MovieRepository, IMovieRepository>();

            // make sure table is in db...
            using (var db = container.Resolve<IDbConnectionFactory>().OpenDbConnection())
            {
                db.CreateTable<Movie>();
            }

            // for javascript ReleaseDate -> releaseDate
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            // validator stuff
            container.RegisterValidators(typeof(DuplicateValidator).Assembly);
            container.RegisterAutoWiredAs<DuplicateValidator, IDuplicateValidator>();
        }
    }
}