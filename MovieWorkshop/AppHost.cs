using System.Web;

using Funq;

using MovieWorkshop.DAL;
using MovieWorkshop.Model;

using ServiceStack.OrmLite;

namespace MovieWorkshop
{
    public class AppHost
    {
        public void Configure(Container container)
        {
            InitDatabase(container);

            // for javascript ReleaseDate -> releaseDate
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            // don't forget to register validators!

            // maybe you want to try other Plugins like Swagger, RequestLogger, AuthFeature
            // see https://github.com/ServiceStack/ServiceStack/wiki/Plugins for list of plugins
        }

        private void InitDatabase(Container container)
        {
            // register
            var dbConnectionFactory = new OrmLiteConnectionFactory(HttpContext.Current.Server.MapPath("~/App_Data/movies.db"), SqliteDialect.Provider);
            container.Register<IDbConnectionFactory>(dbConnectionFactory);
            container.RegisterAutoWiredAs<MovieRepository, IMovieRepository>();

            // make sure table is in db...
            using (var db = container.Resolve<IDbConnectionFactory>().OpenDbConnection())
            {
                db.CreateTable<Movie>();
            }
        }
    }
}