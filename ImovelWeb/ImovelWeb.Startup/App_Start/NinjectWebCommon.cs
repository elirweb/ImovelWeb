[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ImovelWeb.Startup.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ImovelWeb.Startup.App_Start.NinjectWebCommon), "Stop")]

namespace ImovelWeb.Startup.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ImovelWeb.Repository;
    using ImovelWeb.WorkFlow;

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
            kernel.Bind<RepositorioFoto>().To<RepositorioFoto>();
            kernel.Bind<RepositoryCorretor>().To<RepositoryCorretor>();
            kernel.Bind<RepositoryEmpreendimento>().To<RepositoryEmpreendimento>();
            kernel.Bind<RepositoryPorcentagem>().To<RepositoryPorcentagem>();
            kernel.Bind<EmailCorretor>().To<EmailCorretor>();
            kernel.Bind<EmailCorretorEsqueceuSenha>().To<EmailCorretorEsqueceuSenha>();
            kernel.Bind<RepositoryRegistro>().To<RepositoryRegistro>();
            kernel.Bind<RepositoryImobiliario>().To<RepositoryImobiliario>();
        }        
    }
}
