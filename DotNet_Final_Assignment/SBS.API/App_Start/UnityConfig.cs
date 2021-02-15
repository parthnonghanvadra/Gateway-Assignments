using SBS.BusinessLogicLayer.Class;
using SBS.BusinessLogicLayer.Helper;
using SBS.BusinessLogicLayer.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace SBS.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICustomerManager, CustomerManager>();
            container.RegisterType<IVehicleManager, VehicleManager>();
            container.RegisterType<ISupportManager, SupportManager>();
            container.RegisterType<IAppointmentManager, AppointmentManager>();

            container.AddNewExtension<UnityRepositoryHelper>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}