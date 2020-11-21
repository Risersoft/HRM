using risersoft.shared;
using risersoft.shared.portable.Model;
using Risersoft.ESS.Global;
using Risersoft.Framework.Dependency;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages.Alert;
using Risersoft.Framework.Pages.Framework;
using Risersoft.Framework.Service;
using Risersoft.Framework.XFView;
using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Risersoft.ESS.Pages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingLeavesDetailPage : BasePage, ICanHideBackButton
    {
        PendingLeavesDetailPageViewModel pendingLeavesDetailPageViewModel;
        public bool HideBackButton { get; set; }
        public PendingLeavesDetailPage()
        {
            InitializeComponent();
            BindInfo();
        }

        private async Task BindInfo()
        {
            var StkBtnCancelGesture = new TapGestureRecognizer();
            StkBtnCancelGesture.Tapped += StkBtnCancelGesture_Tapped;
            StkBtnCancel.GestureRecognizers.Add(StkBtnCancelGesture);
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                XLLoader.IsVisible = true;
                ResultInfo<LeaveAppInfo, HttpStatusCode> result = await RestClient.GetAsync<ResultInfo<LeaveAppInfo, HttpStatusCode>>(AppConstants.apiBaseUri, AppConstants.MyLeaveUrl);
                XLLoader.IsVisible = false; 
                if (result.Status == HttpStatusCode.OK && result != null)
                {
                    pendingLeavesDetailPageViewModel = new PendingLeavesDetailPageViewModel(result.Data);
                    BindingContext = pendingLeavesDetailPageViewModel;
                }
                else
                {
                    ShowAlertBox(AlertType.OK, "INFO", "Please try again later !", btnppok_Click, null, null);
                }
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "INFO", connectionStatus, btnok_Click, null, null);
        }

        private async void StkBtnCancelGesture_Tapped(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                XLLoader.IsVisible = true;
                ResultInfo<string, HttpStatusCode> result = await RestClient.GetAsync<ResultInfo<string, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.CancelMyLeave);
                XLLoader.IsVisible = false;

                if (result.Status == HttpStatusCode.OK && result != null)
                {
                    ShowAlertBox(AlertType.OK, "INFO", "Leave cancelled successfully !", btnppok_Click, null, null);
                }
                else
                {
                    ShowAlertBox(AlertType.OK, "INFO", "Please try again later !", btnppok_Click, null, null);
                }
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "INFO", connectionStatus, btnok_Click, null, null);
        }

        void btnok_Click()
        {
            ClearPopups();
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
                    LabelbtnAlertokGesture.Tapped += delegate { confimYes(); };
                    vwalertconfirm.LabelbtnAlertok.GestureRecognizers.Add(LabelbtnAlertokGesture);

                    var LabelbtncancelGesture = new TapGestureRecognizer();
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
        public override async Task<bool> VSave()
        {
            bool result = false;
            this.InitError();
            if (this.ValidateData())
            {
                if (await this.SaveModel()) result = true;
            }
            else this.SetError();
            return result;
        }
    }

    public class PendingLeavesDetailPageViewModel : LeaveAppInfo, INotifyPropertyChanged
    {
        public PendingLeavesDetailPageViewModel(LeaveAppInfo leaveAppInfo)
        {
            Authority2Action = leaveAppInfo.Authority2Action;
            Authority2Comments = leaveAppInfo.Authority2Comments;
            Authority2Name = leaveAppInfo.Authority2Name;
            Authority2Code = leaveAppInfo.Authority2Code;
            Authority2Id = leaveAppInfo.Authority2Id;
            Authority1Action = leaveAppInfo.Authority1Action;
            Authority1Comments = leaveAppInfo.Authority1Comments;
            Authority1Name = leaveAppInfo.Authority1Name;
            Authority1Code = leaveAppInfo.Authority1Code;
            Authority1Id = leaveAppInfo.Authority1Id;
            Reason = leaveAppInfo.Reason;
            EndDateHalf = leaveAppInfo.EndDateHalf;
            EndDate = leaveAppInfo.EndDate;
            StartDateHalf = leaveAppInfo.StartDateHalf;
            StartDate = leaveAppInfo.StartDate;
            CancellationDate = leaveAppInfo.CancellationDate;
            ApplicationDate = leaveAppInfo.ApplicationDate;
            FullName = leaveAppInfo.FullName;
            EmpCode = leaveAppInfo.EmpCode;
            EmployeeId = leaveAppInfo.EmployeeId;
            LeaveAppId = leaveAppInfo.LeaveAppId;
            StatusCode = leaveAppInfo.StatusCode;
            StatusText = leaveAppInfo.StatusText;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
