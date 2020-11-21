using Plugin.Geolocator.Abstractions;
using risersoft.shared;
using risersoft.shared.portable.Models.Nav;
using risersoft.shared.Providers;
using Risersoft.ESS.Global;
using Risersoft.ESS.Pages;
using Risersoft.ESS.Pages.Punch;
using Risersoft.Framework.Global;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace Risersoft.ESS
{
    public class clsAppExtenderESS : clsXamAppExtendBase
    {
        public override string StartupAppCode()
        {
            //return "ess.mob";
            return base.StartupAppCode();
        }
        public override IForm AboutBox()
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicFormModelTypes()
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicReportProviderTypes(clsAppController myContext)
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicTaskProviderTypes()
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicWOInfoTypes()
        {
            throw new NotImplementedException();
        }
        public override Page AddPage(string pgKey)
        {
            switch (pgKey.ToLower().Trim())
            {
                case "pendingleavedetailpage":
                    return new PendingLeavesDetailPage();
                case "pendingappdetailpage":
                    return new PendingAppDetailPage();
                case "profilepage":
                    //return new ProfilePage(true);
                case "applyleavepage":
                    return  new ApplyLeavePage();
                case "punchpage":
                    return new PunchPage();
                default:
                    return new Page();
            }
        }
        public override string ProgramName()
        {
            return "ESS";
        }
        public override string ProgramCode()
        {
            return "ess";
        }

        public override IAppDataProvider CreateDataProvider(clsAppController context, IAsyncWCFCallBack cb)
        {
            var str1 = AppConstants.RestServiceHost();

            var provider = new clsAppDataProviderREST(context, str1, (clsXamPolice)context.Police);
            return provider;
        }

        public override IForm frmDel(clsView pView, string IDX, string sysentXML)
        {
            throw new NotImplementedException();
        }
    }
}
