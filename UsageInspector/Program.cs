using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Topshelf;
using Topshelf.Autofac;
using UsageInspector.IOC;

namespace UsageInspector
{
    class Program
    {
        static void Main(string[] args)
        {
            PlumbingFactory.Register();
            HostFactory.Run(x =>
            {
                x.UseAutofacContainer(PlumbingFactory.GetContainer());
                x.Service<UsageInspection>();
                x.RunAsLocalSystem();
                x.StartAutomatically();

                //x.SetDescription(Settings.Default.ServiceDescription);
                //x.SetDisplayName(Settings.Default.ServiceDisplayName);
                //x.SetServiceName(Settings.Default.ServiceName);
            });
        }
    }

    
}
