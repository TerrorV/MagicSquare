using StructureMap;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace MagicSquares
{
    public class ServiceActivator : IHttpControllerActivator
    {
        private readonly IContainer _container;

        public ServiceActivator(IContainer container)
        {
            _container = container;
        }
        public ServiceActivator(HttpConfiguration configuration) { }

        public IHttpController Create(HttpRequestMessage request
            , HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = _container.GetInstance(controllerType) as IHttpController;
            return controller;
        }
    }
}