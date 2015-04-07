using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Webshop_BusinessLayer.Repositories;
using Webshop.Models;
using Webshop_BusinessLayer.Services;

namespace Webshop
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IGenericRepository<ProgrammingFramework>, GenericRepository<ProgrammingFramework>>();
            container.RegisterType<IGenericRepository<OperatingSystem>, GenericRepository<OperatingSystem>>();
            container.RegisterType<IDeviceRepository, DeviceRepository>();
            container.RegisterType<IProductService, ProductService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}