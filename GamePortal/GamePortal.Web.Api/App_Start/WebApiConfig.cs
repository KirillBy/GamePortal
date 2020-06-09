﻿using FluentValidation.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GamePortal.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            FluentValidationModelValidatorProvider.Configure(config, opt =>
            {
                opt.ValidatorFactory = new CustomValidatorFactory(config.DependencyResolver);
            });

        }
    }
}
