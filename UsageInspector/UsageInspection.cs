using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Topshelf;
using UsageInspector.IOC;
using UsageInspector.Repositories;
using UsageInspector.Managers;

namespace UsageInspector
{
    class UsageInspection : ServiceControl
    {
        private UsageInspectionRepository _usageInspectionRepository;
        public bool Start(HostControl hostControl)
        {

            _usageInspectionRepository = PlumbingFactory.GetContainer().Resolve<UsageInspectionRepository>();
            var abc = _usageInspectionRepository.GetUsageHistory();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            
            return true;
        }
    }
}
