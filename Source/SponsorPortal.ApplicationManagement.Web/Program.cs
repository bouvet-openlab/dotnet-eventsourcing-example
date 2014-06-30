using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SponsorPortal.ApplicationManagement.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8200/sponsorportal"))
            {
                Console.ReadLine();
            }
        }
    }
}
