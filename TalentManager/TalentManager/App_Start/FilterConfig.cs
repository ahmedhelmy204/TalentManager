﻿using System.Web;
using System.Web.Mvc;

namespace TalentManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Add global authorize attribute
            //filters.Add(new AuthorizeAttribute());
        }
    }
}
