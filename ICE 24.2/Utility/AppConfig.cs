using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDD_AutomationTests.Utility
{
 public class AppConfig
    {
        public string ApplicationURL { get; set; }
        public string Browser { get; set; }
        public string TakeScreenShotForAllSteps { get; set; }
        public string ApplicationName { get; set; }
    }
}