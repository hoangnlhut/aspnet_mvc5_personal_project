using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _1WelcomeApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            ////add specific route BEFORE default route
            //routes.MapRoute(
            //    name: "MovieByReleaseDate",
            //    url: "movie/released/{year}/{month}",
            //    defaults: new { controller = "Movie", action = "ByReleaseDate" },
            //    //constraints: new { year = @"\d{4}", month = @"\d{2}" } //regex for year and month,
            //    constraints: new { year = @"2015|2016", month = @"\d{2}" } //regex for year between 2015 and 2016
            //    );

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
