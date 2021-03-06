[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NLayerApp.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NLayerApp.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace NLayerApp.WebAPI.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Ninject.Web.WebApi;
    //  using Ninject.Web.Common.WebHost;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Modules;
    using Ninject.Web.Common.WebHost;
    using BLL;

    public static class NinjectWebCommon
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
            var modules = new INinjectModule[] { new ServiceModule("DefaultConnection") };
            var kernel = new StandardKernel(modules);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                //to comment
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel); // 
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
            //to comment
            kernel.Bind<IPlaceService>().To<PlaceService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IFileService>().To<FileService>();
            //
            //System.Web.Mvc.DependencyResolver.SetResolver(new NLayerApp.WebAPI.Util.NinjectDependencyResolver(kernel));
        }
    }
}
