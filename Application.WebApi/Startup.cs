﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using System.Web.Http;
using System.Reflection;
using Ninject;
using Exam.Data;

[assembly: OwinStartup(typeof(Exam.WebApi.Startup))]

namespace Exam.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IEstatesData>().To<IEstatesData>().WithConstructorArgument("context", c => new EstatesDbContext());
        }
    }
}
