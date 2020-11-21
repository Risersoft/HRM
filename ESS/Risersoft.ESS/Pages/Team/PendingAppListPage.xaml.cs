using risersoft.shared.portable.Model;
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
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Risersoft.Framework.Global.Utility;

namespace Risersoft.ESS.Pages.Team
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingAppListPage : BasePage, ICanHideBackButton
    {
        public bool HideBackButton { get; set; }
        public PendingAppListPage(bool IsFromDrawer = false)
        {
            HideBackButton = IsFromDrawer;
            Title = "Pending Applications";
            InitializeComponent();
            BindInfo();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.ActionOnLeave)
            {
                BindInfo();
                App.ActionOnLeave = false;
            }
        }

        //public async void CheckInternet()
        //{
        //    var connectionStatus = await Utility.GetConnectivityStatus();
        //    if (!string.IsNullOrWhiteSpace(connectionStatus))
        //    {
        //        ShowAlertBox(AlertType.OK, "ALERT", connectionStatus, btnok_Click, null, null);
        //        return;
        //    }
        //}
        private async void BindInfo()
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {

                XLLoader.IsVisible = true;
                //lblloader.Text = "Please wait...";
                var pendingTeamLeave = await RestClient.GetAsync<ResultInfo<List<LeaveAppInfo>, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.PendingTeamLeave);
                XLLoader.IsVisible = false;

                if (pendingTeamLeave.Data != null)
                {
                    if (pendingTeamLeave.Data.Count > 0)
                        BindingContext = new PendingAppListViewModel(pendingTeamLeave.Data, this.Navigation);
                    else
                    {
                        ShowAlertBox(AlertType.OK, "INFO", "No record found !", btnppok_Click, null, null);
                    }
                }
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnok_Click, null, null);

        }
        #region AlertPopUps

        async void btnok_Click()
        {
            ClearPopups();
            //await ((App)Application.Current).NavigateHome();
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
    }

    class PendingAppListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<LeaveAppInfo> leaveAppInfoItems { get; }
        public string fontfamily_reg { get; set; }
        public string fontfamily_bold { get; set; }
        public PendingAppListViewModel(List<LeaveAppInfo> data, INavigation Navigation)
        {
            fontfamily_reg = Utility.GetFont(FontStyle.REGULAR);
            fontfamily_bold = Utility.GetFont(FontStyle.BOLD);

            leaveAppInfoItems = new ObservableCollection<LeaveAppInfo>();
            foreach (var item in data)
            {
                item.fontfamily_bold = fontfamily_bold;
                item.fontfamily_reg = fontfamily_reg;
                leaveAppInfoItems.Add(item);
            }
            _itemClickCommand = new Command(ListItem_Click);
            this._navigation = Navigation;
            //for (int i = 1; i <= 20; i++)
            //{
            //    LeaveAppInfo item = new LeaveAppInfo { LeaveAppId = i, FullName = "full name " + i, ApplicationDate = DateTime.UtcNow };
            //    leaveAppInfoItems.Add(item);
            //}
        }



        private async void ListItem_Click(object obj)
        {
            int leaveAppId = (int)obj;
            var leaveAppInfoItem = leaveAppInfoItems.Where(a => a.LeaveAppId == leaveAppId).SingleOrDefault();
            //await App.Rootpage.NavigateAsync(MenuType.PendingAppDetailPage, leaveAppInfoItem);
            await _navigation.PushAsync(new PendingAppDetailPage(leaveAppInfoItem));
        }
        private INavigation _navigation;

        ICommand _itemClickCommand;
        public ICommand ItemClickCommand
        {
            get
            {
                return _itemClickCommand;
            }
        }







        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
