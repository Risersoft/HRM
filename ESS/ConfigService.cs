﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Risersoft.Framework.Dependency;
using Risersoft.Framework.Global;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConfigService))]
namespace Risersoft.Framework.Dependency
{
    public class ConfigService : IConfiguration

    {
        public string LoginServiceHost()
        {
            return "http://login.risersoft.com";
             // return "http://login.qa.appsnirvana.com";
            //return "http://dse3.kanohar.net:11626";
        }

        public string RestServiceHost()
        {
            //return "http://rest.risersoft.com";
         //   return "http://hrm.qa.appsnirvana.com";
            return "http://hrmnirvana.com";
            //return "http://dse3.kanohar.net:56494";
        }
         public string AppName()
        {
            return Globals.myXamApp.objAppExtender.ProgramName();
        }
        public string ClientId()
        {
            return "ess.mob";
        }
        public string ClientSecret()
        {
              return "essmob123";
        }
        public string AppList() {
            return "hrmess";
        }
        public string WCFServiceHost()
        {
            return "http://wcf.risersoft.com/dataservice.svc";
        }
    }
}