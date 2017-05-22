using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using UsageInspector.Managers;
using UsageInspector.Repositories;

namespace UsageInspector.IOC
{
    public static class PlumbingFactory
    {
        private static IContainer _container;

        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UsageInspection>();
            builder.RegisterType<UsageInspectionRepository>();
            var connStringFe = ConfigurationManager.ConnectionStrings["koredb-fe"].ConnectionString;
            var connStringBe = ConfigurationManager.ConnectionStrings["koredb-be"].ConnectionString;
            builder.RegisterInstance(new ConnectionManager(connStringFe)).SingleInstance().As<IConnectionManager>();
            builder.RegisterInstance(new ConnectionManager(connStringBe)).SingleInstance().As<IConnectionManager>();
            _container = builder.Build();
        }
        public static IContainer GetContainer()
        {
            return _container;
        }
    }
}
