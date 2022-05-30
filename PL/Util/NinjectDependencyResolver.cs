using System.Web.Mvc;
using Ninject;
using System.Collections.Generic;
using System;
using BLL;

namespace PL.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IPlaceService>().To<PlaceService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IFileService>().To<FileService>();
        }
    }
}