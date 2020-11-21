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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Risersoft.Framework.Global.Utility;

namespace Risersoft.ESS.Pages
{

    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingAppDetailPage : BasePage
    {
        PendingAppDetailPageViewModel PendingAppDetailPageVM;
        public PendingAppDetailPage()
        {
            InitializeComponent();
        }

        private async void BindInfo(LeaveAppInfo data)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                XLLoader.IsVisible = true;
                txtComment.Text = string.Empty;
                var leaveInfo = (LeaveAppInfo)data;
                var result = await RestClient.GetAsync<ResultInfo<List<LeaveBalanceInfo>, HttpStatusCode>>
                    (AppConstants.apiBaseUri, AppConstants.SubLeaveBalance + leaveInfo.EmployeeId);
                XLLoader.IsVisible = false;
                if (result.Status == HttpStatusCode.OK && result.Data.Count > 0)
                {
                    PendingAppDetailPageVM = new PendingAppDetailPageViewModel(result.Data, leaveInfo);
                    BindingContext = PendingAppDetailPageVM;
                }
                else
                    ShowAlertBox(AlertType.OK, "INFO", "No record found !", btnppok_Click, null, null);

                var lblBtnApproveGesture = new TapGestureRecognizer();
                lblBtnApproveGesture.Tapped += (o, e) => lblBtnApproveGesture_Tapped(o, e, leaveInfo.LeaveAppId);
                lblBtnApprove.GestureRecognizers.Add(lblBtnApproveGesture);

                var lblBtnRejectGesture = new TapGestureRecognizer();
                lblBtnRejectGesture.Tapped += (o, e) => lblBtnRejectGesture_Tapped(o, e, leaveInfo.LeaveAppId);
                lblBtnReject.GestureRecognizers.Add(lblBtnRejectGesture);

            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnppok_Click, null, null);
        }

        private void lblBtnRejectGesture_Tapped(object sender, EventArgs e, int leaveAppId)
        {
            ApproveRejectApplication(false, leaveAppId);
        }

        private void lblBtnApproveGesture_Tapped(object sender, EventArgs e, int leaveAppId)
        {
            ApproveRejectApplication(true, leaveAppId);
        }
        async void ApproveRejectApplication(bool IsApproved, int leaveAppId)
        {
            if (txtComment.Text == "")
            {
                lblerror.Text = "Please enter comments !";
                lblerror.IsVisible = true;
                return;
            }
            lblerror.IsVisible = false;
            var pendingLeaveApp = new PendingAppDetailRequestModel
            {
                LeaveAppId = leaveAppId,
                Accepted = IsApproved,
                Comments = txtComment.Text
            };
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                XLLoader.IsVisible = true;
                ResultInfo<string, HttpStatusCode> result = await RestClient.PostAsync<ResultInfo<string, HttpStatusCode>>(AppConstants.apiBaseUri, AppConstants.SubLeaveApp, pendingLeaveApp);
                XLLoader.IsVisible = false;
                if (result.Status == HttpStatusCode.OK && result != null)
                {
                    string message = string.Empty;
                    if (IsApproved)
                        message = "Application approved successfully !";
                    else
                        message = "Application rejected successfully !";

                    ShowAlertBox(AlertType.OK, "INFO", message, btnppok_Click, null, null);
                }
                else
                {
                    ShowAlertBox(AlertType.OK, "INFO", "Please try again later !", btnppok_Click, null, null);
                }
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnok_Click, null, null);
        }
        #region AlertPopUps
        async void btnok_Click()
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
        #endregion
        public override async Task<bool> PrepForm(clsXamView oView, EnumfrmMode prepMode, string prepIDX, string strXML = "")
        {
            this.FormPrepared = false;
            var result = await RestClient.GetAsync<ResultInfo<LeaveAppInfo, HttpStatusCode>>
                          (AppConstants.apiBaseUri, AppConstants.SubLeaveApp + prepIDX);
            this.BindInfo(result.Data);
            this.FormPrepared = true;
            return this.FormPrepared;
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
   
    class PendingAppDetailPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<LeaveBalanceInfo> leaveBalanceInfoItems { get; set; }
        public PendingAppDetailPageViewModel(List <LeaveBalanceInfo> leavebalance,LeaveAppInfo appinfo)
        {
           
            LeaveAppId = appinfo.LeaveAppId;
            EmployeeId = appinfo.EmployeeId;
            EmpCode = appinfo.EmpCode;
            FullName = appinfo.FullName;
            StartDate = appinfo.StartDate;
            EndDate = appinfo.EndDate;
            Reason = appinfo.Reason;
            Authority1Name = appinfo.Authority1Name;
            Authority2Name = appinfo.Authority2Name;
            leaveBalanceInfoItems  = new ObservableCollection<LeaveBalanceInfo>(leavebalance);
      
           
         
        }
       
        public int LeaveAppId { get; set; }
        public int EmployeeId { get; set; }
        public string EmpCode { get; set; }
        public string FullName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Reason { get; set; }
        public string Authority1Name { get; set; }
        public string Authority2Name { get; set; }
     

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class PendingAppDetailRequestModel
    {
        public int LeaveAppId { get; set; }

        public bool Accepted { get; set; }

        public string Comments { get; set; }      
    }
   
}
