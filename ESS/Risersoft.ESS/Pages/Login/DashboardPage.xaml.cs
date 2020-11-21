using Risersoft.ESS.Pages.Punch;
using Risersoft.Framework.Dependency;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages.Alert;
using Risersoft.Framework.Pages.Framework;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Risersoft.Framework.Global.Utility;

namespace Risersoft.ESS.Pages
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : BasePage
    {

        public DashboardPage()
        {
            InitializeComponent();
            XLLoader.IsVisible = true;
            BindInfo();
            BindingContext = new DashboardViewModel();
        }
        private async void BindInfo()
        {

            var RlLeavesGesture = new TapGestureRecognizer();
            RlLeavesGesture.Tapped += RlLeavesGesture_Tapped;
            RlLeaves.GestureRecognizers.Add(RlLeavesGesture);

            var RlTeamsGesture = new TapGestureRecognizer();
            RlTeamsGesture.Tapped += RlTeamsGesture_Tapped;
            RlTeams.GestureRecognizers.Add(RlTeamsGesture);

            var RlPayslipGesture = new TapGestureRecognizer();
            RlPayslipGesture.Tapped += RlPayslipGesture_Tapped;
            RlPayslip.GestureRecognizers.Add(RlPayslipGesture);

            var RlProfileGesture = new TapGestureRecognizer();
            RlProfileGesture.Tapped += RlProfileGesture_Tapped;
            RlProfile.GestureRecognizers.Add(RlProfileGesture);

            //if (App.Menupage.RootViewModel != null)
            //{
            //    Title = "Welcome " + App.Menupage.RootViewModel.EmployeeInfo.Data.FullName + "!";
            //    lblempcode.Text = "Emp Code: " + App.Menupage.RootViewModel.EmployeeInfo.Data.EmpCode;
            //    App.Menupage.SetUserName(App.Menupage.RootViewModel.EmployeeInfo.Data.FullName);
            //    XLLoader.IsVisible = false;
            //}
            var BtnPunchGesture = new TapGestureRecognizer();
            BtnPunchGesture.Tapped += BtnPunchGesture_Tapped;
            btnpunch.GestureRecognizers.Add(BtnPunchGesture);

            BindingContext = new DashboardViewModel();


        }

        private async void BtnPunchGesture_Tapped(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                XLLoader.IsVisible = true;
                var position = await Utility.GetLatitudeLongitude();
                if (Device.OS == TargetPlatform.iOS)
                {
                    bool IsEnabled = false;
                    if (position == null)
                        IsEnabled = await DisplayAlert("Need location", "Please enable your location.", "OK", "Cancel");
                    if (IsEnabled)
                    {
                        var result = DependencyService.Get<IEnableLocation>().CheckEnabledLocation();
                        if (result)
                            Device.OpenUri(new Uri(string.Format("app-settings:")));
                        else
                            Device.OpenUri(new Uri(string.Format("prefs:root=app-settings")));
                    }

                }
                if (Device.OS == TargetPlatform.Android)
                {
                    if (position == null)
                        ShowAlertBox(AlertType.OK, "INFO", "Please enable device location !", btnppok_Click, null, null);
                }
                if (position != null)
                {
                    await this.Navigation.PushAsync(new PunchPage());
                }
                XLLoader.IsVisible = false;
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "INFO", connectionStatus, btnppok_Click, null, null);
        }

        protected async override void OnAppearing()
        {
            //RSNavigationPage.SetBackButtonTitle(this, string.Empty);
            //base.OnAppearing();
            //if (App.EmployeeInfo == null)
            //{

            //    var empinfo = await RestClient.GetAsync<ResultInfo<EmployeeInfo, HttpStatusCode>>(AppConstants.apiBaseUri,"MyEmp");
            //    App.EmployeeInfo = empinfo;
            //}
            //if (App.EmployeeInfo != null)
            //{
            //    if (App.EmployeeInfo.Data != null)
            //    {
            //        Title = "Welcome " + App.EmployeeInfo.Data.FullName + "!";
            //        lblempcode.Text = "Emp Code: " + App.EmployeeInfo.Data.EmpCode;
            //       // ((App)Application.Current).SetUserName(App.EmployeeInfo.Data.FullName);
            //        this.RlTeams.IsVisible = (App.EmployeeInfo.Data.LeaveAuthCount > 0);
            //        this.btnpunch.IsEnabled = (App.EmployeeInfo.Data.PunchEnabled);
            //    }
            //}
            //XLLoader.IsVisible = false;
            //GetUserPic();

        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private async void GetUserPic()
        {
                if (Device.OS == TargetPlatform.Android)
                {
                    var storagePermission = await DependencyService.Get<IStorage>().StoragePermission();
                    if (!storagePermission)
                    {
                        DependencyService.Get<ICloseApplication>().closeApplication();
                        return;
                    }
                }
                XLLoader.IsVisible = true;
                try
                {
                    await GetPicStream();
                var downloadedPic = await DependencyService.Get<ISavePic>().GetPhoto();
                await GetPicStream(downloadedPic);
                }
                catch (Exception ex)
                { }
                XLLoader.IsVisible = false;
        }

        async Task<Stream> GetPicStream(Stream pic = null)
        {
            //if (pic != null)
            //{
            //   // ((App)Application.Current).SetUserPic(pic);
            //    return pic;
            //}
            //else
            //{
            //    if (App.EmployeeInfo != null)
            //    {
            //        var profilePicUris = App.EmployeeInfo.Data.ProfilePicUris;
            //        if (profilePicUris.Count == 0)
            //            return null;
            //        var picToBeDownloaded = profilePicUris[profilePicUris.Count - 1];

            //        HttpClient client = new HttpClient();
            //        var getPicResponse = await client.GetByteArrayAsync(picToBeDownloaded);
            //        DependencyService.Get<ISavePic>().SavePicAsync(getPicResponse);
            //        return null;
            //    }
            //    else
            //        return null;
            //}
            return null;
        }

        private async void RlProfileGesture_Tapped(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
                await this.Navigation.PushAsync(new ProfilePage());
            else
                ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnppok_Click, null, null);
        }

        private async void RlPayslipGesture_Tapped(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            //if (string.IsNullOrWhiteSpace(connectionStatus))
            //    await this.Navigation.PushAsync(new PayslipListPage());
            //else
            //    ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnppok_Click, null, null);
        }

        private async void RlTeamsGesture_Tapped(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            //if (string.IsNullOrWhiteSpace(connectionStatus))
            //    await this.Navigation.PushAsync(new PendingAppListPage());
            //else
            //    ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnppok_Click, null, null);
        }

        private async void RlLeavesGesture_Tapped(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            //if (string.IsNullOrWhiteSpace(connectionStatus))
            //    await this.Navigation.PushAsync(new LeavesBalanceListPage());
            //else
            //    ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnppok_Click, null, null);
        }



        #region AlertPopUps
        async void btnppok_Click()
        {
            ClearPopups();
            //await this.Navigation.PopAsync();
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
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public DashboardViewModel()
        {
            fontfamily_reg = Utility.GetFont(FontStyle.REGULAR);
            fontfamily_bold = Utility.GetFont(FontStyle.BOLD);
        }
        public string fontfamily_reg { get; set; }
        public string fontfamily_bold { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
