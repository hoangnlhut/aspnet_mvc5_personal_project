using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1WelcomeApp
{
    public enum MemberShipTypes
    {
        PayAsYouGo = 1,
        Monthly = 2,
        Quarterly = 3,
        Annual = 4
    }

    public static class UserRoles
    {
       public const string CanManageMovies = "CanManageMovies";
    }
}