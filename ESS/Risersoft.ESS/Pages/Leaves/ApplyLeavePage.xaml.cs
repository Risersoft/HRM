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
using static Risersoft.Framework.Global.Utility;

namespace Risersoft.ESS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplyLeavePage : BasePage, ICanHideBackButton
    {
        ApplyLeavePageViewModel ApplyLeavePageVM;
        public bool HideBackButton { get; set; }
        public ApplyLeavePage()
        {
            InitializeComponent();
            BindInfo();
            ApplyLeavePageVM = new ApplyLeavePageViewModel();
            BindingContext = ApplyLeavePageVM;
        }
        private void BindInfo()
        {
            var StkBtnApplyLeaveGesture = new TapGestureRecognizer();
            StkBtnApplyLeaveGesture.Tapped += StkBtnApplyLeaveGesture_Tapped;
            StkBtnApplyLeave.GestureRecognizers.Add(StkBtnApplyLeaveGesture);
            txtReason.Text = string.Empty;
            var imguncheckGesture = new TapGestureRecognizer();
            imguncheckGesture.Tapped += imguncheckGesture_Tapped;
            imguncheck.GestureRecognizers.Add(imguncheckGesture);

            var imguncheck2Gesture = new TapGestureRecognizer();
            imguncheck2Gesture.Tapped += imguncheck2Gesture_Tapped;
            imguncheck2.GestureRecognizers.Add(imguncheck2Gesture);
        }
        private async void imguncheck2Gesture_Tapped(object sender, EventArgs e)
        {
            var source = (FileImageSource)imguncheck2.Source;
            if (dpStartDate.Date == dpEndDate.Date)
            {
                //no difference in UI
            }
            if (source.File == "unchecked.png")
                imguncheck2.Source = "checked.png";
            else
                imguncheck2.Source = "unchecked.png";

        }
        private async void imguncheckGesture_Tapped(object sender, EventArgs e)
        {
            var source = (FileImageSource)imguncheck.Source;
            if (source.File == "unchecked.png")
                imguncheck.Source = "checked.png";
            else
                imguncheck.Source = "unchecked.png";
        }
        private async void StkBtnApplyLeaveGesture_Tapped(object sender, EventArgs e)
        {
            var strtHlfDay = (FileImageSource)imguncheck.Source;
            var endHlfDay = (FileImageSource)imguncheck2.Source;
            if (dpEndDate.Date < dpStartDate.Date)
            {
                lblerror.Text = "End date cannot be less than start date !";
                lblerror.IsVisible = true;
                return;
            }
            if (txtReason.Text == "")
            {
                lblerror.Text = "Please enter reason !";
                lblerror.IsVisible = true;
                return;
            }
            if (dpEndDate.Date == dpStartDate.Date && strtHlfDay == "checked.png" && endHlfDay == "checked.png")
            {
                lblerror.Text = "Both start and end cannot be half days as start date = end date !";
                lblerror.IsVisible = true;
                return;
            }
            lblerror.IsVisible = false;
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                var applyLeave = new LeaveAppInfo()
                {
                    StartDate = dpStartDate.Date,
                    EndDate = dpEndDate.Date,
                    Reason = txtReason.Text
                };
                if (strtHlfDay.File == "checked.png")
                    applyLeave.StartDateHalf = 1; 
                else
                    applyLeave.StartDateHalf = 0;
                if (endHlfDay.File == "checked.png")
                    applyLeave.EndDateHalf = 1;
                else
                    applyLeave.EndDateHalf = 0;
                XLLoader.IsVisible = true;
                ResultInfo<string,HttpStatusCode> result = await RestClient.PostAsync<ResultInfo<string, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.MyLeaveUrl, applyLeave);
                XLLoader.IsVisible = false;
                if (result.Status == HttpStatusCode.OK && result != null)
                {
                    ShowAlertBox(AlertType.OK, "INFO", "Leave applied successfully !", btnppok_Click, null, null);
                }
                else
                {
                    ShowAlertBox(AlertType.OK, "INFO", "Please try again later !", btnppok_Click, null, null);
                }
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "INFO", connectionStatus, btnok_Click, null, null);
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

  
    public class ApplyLeavePageViewModel : INotifyPropertyChanged
    {
        public ApplyLeavePageViewModel()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }



}
