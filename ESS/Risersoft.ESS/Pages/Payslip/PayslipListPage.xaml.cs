using risersoft.shared.portable.Models.HR;
using Risersoft.ESS.Global;
using Risersoft.Framework.Dependency;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages.Alert;
using Risersoft.Framework.Pages.Framework;
using Risersoft.Framework.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Risersoft.Framework.Global.Utility;

namespace Risersoft.ESS.Pages.Payslip
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayslipListPage : BasePage, ICanHideBackButton
    {
        PayslipListPageViewModel vm;

        public bool HideBackButton { get; set; }

        public PayslipListPage(bool IsFromDrawer = false)
        {
            HideBackButton = IsFromDrawer;
            InitializeComponent();
            BindInfo();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void BindInfo()
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                XLLoader.IsVisible = true;
                var paysliplist = await RestClient.GetAsync<ResultInfo<List<PayslipInfo>, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.paysliplist);
                XLLoader.IsVisible = false;

                if (paysliplist.Data != null)
                {
                    if (paysliplist.Data.Count > 0)
                    {
                        vm = new PayslipListPageViewModel(paysliplist.Data, this.Navigation);
                        BindingContext = vm;
                    }
                    else
                        ShowAlertBox(AlertType.OK, "INFO", "No record found !", btnppok_Click, null, null);
                }
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnok_Click, null, null);
        }

        #region AlertPopUps
        async void btnok_Click()
        {
            ClearPopups();
           // await ((App)Application.Current).NavigateHome();
        }
        async void btnppok_Click()
        {
            ClearPopups();
            await this.Navigation.PopAsync();
        }
        void ShowAlertBox(AlertType type, string title, string message, Action alertOk, Action confimYes, Action confimNo)
        {
            ContentView vw = null;
            switch (type)
            {
                case AlertType.OK:
                    AlertOk vwalertok = new AlertOk();
                    vwalertok.LabelTitle.Text = title;
                    vwalertok.Labelmessage.Text = message;
                    var LabelbtnokGesture = new TapGestureRecognizer();
                    //LabelbtnokGesture.Tapped += LabelbtnokGesture_Tapped;
                    LabelbtnokGesture.Tapped += delegate { alertOk(); };
                    vwalertok.Labelbtnok.GestureRecognizers.Add(LabelbtnokGesture);
                    vwalertok.HorizontalOptions = LayoutOptions.FillAndExpand;
                    vwalertok.VerticalOptions = LayoutOptions.FillAndExpand;
                    vw = vwalertok;
                    break;
                case AlertType.TRYAGAIN:
                    AlertTryAgain vwalerttryagain = new AlertTryAgain();
                    vwalerttryagain.LabelTitle.Text = title;
                    vwalerttryagain.Labelmessage.Text = message;
                    var LabelbtntryagainGesture = new TapGestureRecognizer();
                    //LabelbtnokGesture.Tapped += LabelbtnokGesture_Tapped;
                    LabelbtntryagainGesture.Tapped += delegate { alertOk(); };
                    vwalerttryagain.Labelbtntryagain.GestureRecognizers.Add(LabelbtntryagainGesture);
                    vwalerttryagain.HorizontalOptions = LayoutOptions.FillAndExpand;
                    vwalerttryagain.VerticalOptions = LayoutOptions.FillAndExpand;
                    vw = vwalerttryagain;
                    break;
                case AlertType.CONFIRM:
                    AlertConfirm vwalertconfirm = new AlertConfirm();
                    vwalertconfirm.LabelTitle.Text = title;
                    vwalertconfirm.Labelmessage.Text = message;

                    var LabelbtnAlertokGesture = new TapGestureRecognizer();
                    //LabelbtnAlertokGesture.Tapped += LabelbtnAlertokGesture_Tapped;
                    LabelbtnAlertokGesture.Tapped += delegate { confimYes(); };
                    vwalertconfirm.LabelbtnAlertok.GestureRecognizers.Add(LabelbtnAlertokGesture);

                    var LabelbtncancelGesture = new TapGestureRecognizer();
                    //LabelbtncancelGesture.Tapped += LabelbtncancelGesture_Tapped;
                    LabelbtncancelGesture.Tapped += delegate { confimNo(); };
                    vwalertconfirm.LabelbtnAlertcancel.GestureRecognizers.Add(LabelbtncancelGesture);

                    vwalertconfirm.HorizontalOptions = LayoutOptions.FillAndExpand;
                    vwalertconfirm.VerticalOptions = LayoutOptions.FillAndExpand;

                    vw = vwalertconfirm;
                    break;
            }
            if (vw != null)
            {
                ppholder.Children.Clear();
                ppholder.Children.Add(vw);
                ppholder.IsVisible = true;
            }
        }
        void ClearPopups()
        {
            if (ppholder != null)
            {
                ppholder.Children.Clear();
                ppholder.IsVisible = false;
            }
        }
        #endregion

        private async void btnViewPaySlip_Clicked(object sender, EventArgs e)
        {
            StackLayout lbl = (StackLayout)sender;
            TapGestureRecognizer labelgesture = (TapGestureRecognizer)lbl.GestureRecognizers.FirstOrDefault();
            int PayslipID = (int)labelgesture.CommandParameter;

            XLLoader.IsVisible = true;
            byte[] result = await vm.GetPDFAsync(PayslipID);
            XLLoader.IsVisible = false;

            if (result.Length > 0)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    bool permissiongranted = await DependencyService.Get<IStorage>().StoragePermission();
                    if (permissiongranted)
                        DependencyService.Get<ISaveFile>().SaveFileAsync(result, PayslipID.ToString());
                    else
                        ShowAlertBox(AlertType.OK, "INFO", "Storage permission required !", btnppok_Click, null, null);
                }
                else
                    DependencyService.Get<ISaveFile>().SaveFileAsync(result, PayslipID.ToString());
            }
        }

        //private async Task GetPaySlip(object sender)
        //{

        //}

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }

    class PayslipListPageViewModel : INotifyPropertyChanged
    {
        public string fontfamily_reg { get; set; }
        public string fontfamily_bold { get; set; }
        public ObservableCollection<PayslipInfo> PayslipItems { get; }
        public PayslipListPageViewModel(List<PayslipInfo> data, INavigation Navigation)
        {
            fontfamily_reg = Utility.GetFont(FontStyle.REGULAR);
            fontfamily_bold = Utility.GetFont(FontStyle.BOLD);
            PayslipItems = new ObservableCollection<PayslipInfo>();
            foreach (var item in data)
            {
                item.fontfamily_bold = fontfamily_bold;
                item.fontfamily_reg = fontfamily_reg;
                PayslipItems.Add(item);
            }
            this._navigation = Navigation;
            //_viewPaySlipTapCommand = new Command(ViewPayslipItem);
        }
        INavigation _navigation;
        //ICommand _viewPaySlipTapCommand;
        //public ICommand ViewPaySlipTapCommand
        //{
        //    get
        //    {
        //        return _viewPaySlipTapCommand;
        //    }
        //}
        public async Task<byte[]> GetPDFAsync(int PayslipID)
        {
            byte[] result = await RestClient.GetPDF(AppConstants.apiBaseUri,string.Format(AppConstants.Payslip, PayslipID));
            return result;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}

