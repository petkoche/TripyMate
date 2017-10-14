[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TelerikAcademy.TripyMate.Web.App_Start.InjectionConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TelerikAcademy.TripyMate.Web.App_Start.InjectionConfig), "Stop")]

namespace TelerikAcademy.TripyMate.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject.Extensions.Conventions;
    using Ninject;
    using Ninject.Web.Common;
    using Data.Repositories;
    using System.Data.Entity;
    using Data;
    using Services.Contracts;
    using Data.Repositories.Contracts;
    using Data.UnitOfWork;
    using Services;
    using AutoMapper;

    public static class InjectionConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            kernel.Bind(x =>
            {
                x.FromAssemblyContaining(typeof(IService))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind(typeof(DbContext), typeof(MsSqlDbContext)).To<MsSqlDbContext>().InRequestScope();

            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
            kernel.Bind<IPostRepository>().To<PostRepository>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IStartTownsRepository>().To<StartTownsRepository>().InSingletonScope();
            kernel.Bind<IMapper>().To<Mapper>();
        }        
    }
}
