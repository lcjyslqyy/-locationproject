using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocateProject.App_Start
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using System.Reflection;
    using System.Web.Mvc; 
    public class AutoFacConfig
    {
        public static void Register()
        {
            ContainerBuilder builder = new Autofac.ContainerBuilder();
            Assembly controllerAss = Assembly.Load("LocateProject");
            builder.RegisterControllers(controllerAss);
            //Assembly repositoryAss = Assembly.Load("ILP_DAL");//接口层
            //Type[] rtypes = repositoryAss.GetTypes();
            //builder.RegisterTypes(rtypes)
            //    .AsImplementedInterfaces(); 
            Assembly servicesAss = Assembly.Load("LP_DAL");
            Type[] stypes = servicesAss.GetTypes();
            builder.RegisterTypes(stypes)
                .AsImplementedInterfaces();  
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

           
        }
    }
}