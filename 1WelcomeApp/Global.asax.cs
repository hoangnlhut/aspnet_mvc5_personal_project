using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _1WelcomeApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DbInterception.Add(new DatabaseLogger());
        }

    }

    //public class DatabaseLogger : IDbCommandInterceptor
    //{
    //    public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    //    {
    //        LogQuery(command);
    //    }

    //    public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    //    {
    //        LogQuery(command);
    //    }

    //    public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    //    {
    //        LogQuery(command);
    //    }

    //    public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    //    {
    //        LogQuery(command);
    //    }

    //    public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    //    {
    //        LogQuery(command);
    //    }

    //    public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    //    {
    //        LogQuery(command);
    //    }

    //    private void LogQuery(DbCommand command)
    //    {
    //        Debug.WriteLine($"SQL Query: {command.CommandText}");
    //    }
    //}

}
