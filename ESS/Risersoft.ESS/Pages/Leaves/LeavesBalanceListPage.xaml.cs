using risersoft.shared.portable.Model;
using Risersoft.ESS.Global;
using Risersoft.Framework.Dependency;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages;
using Risersoft.Framework.Pages.Alert;
using Risersoft.Framework.Pages.Framework;
using Risersoft.Framework.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Risersoft.Framework.Global.Utility;

namespace Risersoft.ESS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeavesBalanceListPage : BasePage, ICanHideBackButton
    {
        public bool HideBackButton { get; set; }


        public LeavesBalanceListPage(bool IsFromDrawer = false)
        {

            HideBackButton = IsFromDrawer;
            RSNavigationPage.SetBackButtonTitle(this, "Back");
            InitializeComponent();
            Bindinfo();
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    if (this.Navigation.NavigationStack.Count == 1 && App.IsFromDrawer)
        //    {
        //        App.IsFromDrawer = false;
        //        NavigateToDB();

        //    }
        //    return false;
        //}

        async void NavigateToDB()
        {
            //await this.Navigation.PushAsync(new DashboardPage());
            //await ((App)Application.Current).NavigateHome();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        private async void Bindinfo()
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrEmpty(connectionStatus))
            {
                if (App.EmployeeInfo.Data.LeaveApplyEnabled)
                {
                    var StkBtnApplyLeaveGesture = new TapGestureRecognizer();
                    StkBtnApplyLeaveGesture.Tapped += StkBtnApplyLeaveGesture_Tapped;
                    StkBtnApplyLeave.GestureRecognizers.Add(StkBtnApplyLeaveGesture);
                }
                else StkBtnApplyLeave.IsEnabled = false;

                XLLoader.IsVisible = true;
                //lblloader.Text = "Please wait...";
                var leaveBalance = await RestClient.GetAsync<ResultInfo<List<LeaveBalanceInfo>, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.MyLeaveBalanceUrl);
                XLLoader.IsVisible = false;

                if (leaveBalance.Data != null)
                    if (leaveBalance.Data.Count > 0)
                        BindingContext = new LeavesBalancePageViewModel(leaveBalance.Data);
                    else
                        ShowAlertBox(AlertType.OK, "INFO", "No record found !", btnppok_Click, null, null);
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnppok_Click, null, null);
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
        private async void StkBtnApplyLeaveGesture_Tapped(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                XLLoader.IsVisible = true;
                //lblloader.Text = "Please wait...";
                var pendingLeave = await RestClient.GetAsync<ResultInfo<PendingLeavesDetailPageViewModel, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.MyLeaveUrl);
                XLLoader.IsVisible = false;

                if (pendingLeave.Data == null)
                {
                    //await App.Rootpage.NavigateAsync(MenuType.ApplyLeave);
                    await this.Navigation.PushAsync(new ApplyLeavePage(), false);
                }
                else
                {
                    var vm = pendingLeave.Data;
                    vm.fontfamily_reg = Utility.GetFont(FontStyle.REGULAR);
                    vm.fontfamily_bold = Utility.GetFont(FontStyle.BOLD);
                    await this.Navigation.PushAsync(new PendingLeavesDetailPage(vm), false);
                }
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnppok_Click, null, null);
        }
    }

    class LeavesBalancePageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<LeaveBalanceInfo> LeaveBalances { get; }
        public string fontfamily_reg { get; set; }
        public string fontfamily_bold { get; set; }
        public LeavesBalancePageViewModel(List<LeaveBalanceInfo> data)
        {
            fontfamily_reg = Utility.GetFont(FontStyle.REGULAR);
            fontfamily_bold = Utility.GetFont(FontStyle.BOLD);
            LeaveBalances = new ObservableCollection<LeaveBalanceInfo>();
            foreach (var item in data)
            {
                item.fontfamily_bold = fontfamily_bold;
                item.fontfamily_reg = fontfamily_reg;
                LeaveBalances.Add(item);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
