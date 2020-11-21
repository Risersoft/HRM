using risersoft.shared;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages.Framework;
using System.ServiceModel;

namespace Risersoft.ESS
{
    public partial class TestPage : BasePage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var cb = new clsDataCallBackHandler();
            InstanceContext cbcontext = new InstanceContext(cb);
            var str1 = "";
            var Provider = ChannelProxyFactory.CreateNetHttp<IAppDataProviderDuplexClient>(cbcontext, str1, null);
        }
    }
}
