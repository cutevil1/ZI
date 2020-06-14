using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AntivirusService
{
    static class Program
    {
       
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] {
                new Service()
            };

            ServiceBase.Run(ServicesToRun);
        }
    }
}
