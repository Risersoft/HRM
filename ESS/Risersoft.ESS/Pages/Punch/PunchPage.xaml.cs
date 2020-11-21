using Plugin.Geolocator.Abstractions;
using risersoft.shared;
using risersoft.shared.portable.Model;
using Risersoft.ESS.Global;
using Risersoft.Framework.Dependency;
using Risersoft.Framework.Entities;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages.Alert;
using Risersoft.Framework.Pages.Framework;
using Risersoft.Framework.Service;
using Risersoft.Framework.XFView;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Risersoft.ESS.Pages.Punch
{

    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PunchPage : BasePage, ICanHideBackButton
    {
        PunchPageViewModel PunchPageVM;
        private Position _position;
        public bool HideBackButton { get; set; }

        public PunchPage()
        {
            InitializeComponent();
            lblGeoCoordinateLat.Text = string.Empty;
            lblGeoCoordinateLong.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblTime.Text = string.Empty;
            lblLocation.Text = string.Empty;
            var btnPunchGesture = new TapGestureRecognizer();
            btnPunchGesture.Tapped += (o, e) => btnPunchGesture_Tapped();
            btnPunch.GestureRecognizers.Add(btnPunchGesture);
            var btnPunchHistoryGesture = new TapGestureRecognizer();
            btnPunchHistoryGesture.Tapped += (o, e) => btnPunchHistoryGesture_Tapped();
            
        }
        public override async Task<bool> PrepForm(clsXamView oView, EnumfrmMode prepMode, string prepIDX, string strXML = "")
        {
            var position = await Utility.GetLatitudeLongitude();
            this._position = position;
            await BindInfo();

            return true;
        }
        private async void btnPunchHistoryGesture_Tapped()
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
        }

        private async void btnPunchGesture_Tapped()
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                XLLoader.IsVisible = true;
                var newPunch = new GeoCoordinate()
                {
                    Longitude = _position.Longitude,
                    Latitude = _position.Latitude,
                    Device = await DependencyService.Get<ICaptureDeviceId>().GetInfo(),
                    TimeStamp = _position.Timestamp.DateTime,
                };
                var result = await RestClient.PostAsync<ResultInfo<string, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.MyPunch, newPunch);
                XLLoader.IsVisible = false;

                if (result != null && result.Status == HttpStatusCode.OK )
                    ShowAlertBox(AlertType.OK, "INFO", "Punch Successful!", btnppok_Click, null, null);
                else
                    ShowAlertBox(AlertType.OK, "INFO", "Error! "+ result.Message, btnppok_Click, null, null);
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
        private async Task BindInfo()
        {
            if (_position != null)
            {
                lblGeoCoordinateLat.Text = "lat: " + _position.Latitude;
                lblGeoCoordinateLong.Text = "lon:" + _position.Longitude;
                var dateTime = _position.Timestamp.DateTime.AddMinutes(330);
                lblDay.Text = dateTime.ToString("dddd");
                lblDate.Text = ", " + dateTime.Date.ToString("dd MMM yyyy");
                lblTime.Text = dateTime.ToString("hh:mm tt");
                var UriTemplate = string.Format("?lat={0}&lng={1}", _position.Latitude, _position.Longitude);
                var result = await RestClient.GetAsync<ResultInfo<string, HttpStatusCode>>(AppConstants.apiBaseUri + AppConstants.MyLocation, UriTemplate);

                if (result != null && result.Status == HttpStatusCode.OK)
                {
                    lblLocation.Text = result.Data;
                }
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

    class PunchPageViewModel : INotifyPropertyChanged
    {

        public PunchPageViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
//https://components.xamarin.com/view/GeolocatorPlugin