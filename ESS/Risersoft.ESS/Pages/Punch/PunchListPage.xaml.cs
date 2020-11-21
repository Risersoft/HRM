using risersoft.shared.portable.Model;
using Risersoft.ESS.Global;
using Risersoft.Framework.Dependency;
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

namespace Risersoft.ESS.Pages.Punch
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PunchListPage : BasePage, ICanHideBackButton
    {
        public bool HideBackButton { get; set; }
        public PunchListPage()
        {
            InitializeComponent();
            BindInfo();
        }
        private async void BindInfo()
        {
            XLLoader.IsVisible = true;
            var punchHistorylist = await RestClient.GetAsync<ResultInfo<List<GeoCoordinate>, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.PunchHistory);
            XLLoader.IsVisible = false;

            if (punchHistorylist.Data != null)
            {
                if (punchHistorylist.Data.Count > 0)
                    BindingContext = new PunchListViewModel(punchHistorylist.Data);
                else
                    ShowAlertBox(AlertType.OK, "INFO", "No record found !", btnppok_Click, null, null);
            }
        }


        #region AlertPopUps
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

    class PunchListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GeoCoordinate> PunchHistoryItems { get; }
        public PunchListViewModel(List<GeoCoordinate> data)
        {
            PunchHistoryItems = new ObservableCollection<GeoCoordinate>(data);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
