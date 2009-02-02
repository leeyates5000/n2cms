﻿using System.Web.Mvc;
using System.Web.Routing;

using N2.Web.Mvc;
using N2.Engine;

namespace MvcTest
{
	public class GlobalApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes, IEngine engine)
		{
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
			// This route detects content item paths and executes their controller
			routes.Add(new ContentRoute(engine, new MvcRouteHandler()));
            
			// This controller fallbacks to a controller unrelated to N2
			routes.MapRoute(
               "Default",                                              // Route name
               "{controller}/{action}/{id}",                           // URL with parameters
               new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }

        public override void Init()
        {
            IEngine engine = N2.Context.Initialize(false);
            RegisterRoutes(RouteTable.Routes, engine);

            base.Init();
        }
	}
}