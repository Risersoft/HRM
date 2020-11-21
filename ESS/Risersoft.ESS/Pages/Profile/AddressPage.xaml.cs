using risersoft.shared.portable.Models.HR;
using Risersoft.Framework.Dependency;
using Risersoft.Framework.Entities;
using Risersoft.ESS.Global;
using Risersoft.Framework.Pages.Alert;
using Risersoft.Framework.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Risersoft.Framework.Global.Utility;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages.Framework;

namespace Risersoft.ESS.Pages.Profile
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressPage : BasePage, ICanHideBackButton
    {
        string ctry = string.Empty;
        public bool HideBackButton { get; set; }
        public AddressPage(AddressInfo address, string AddressType)
        {
            InitializeComponent();
            BindingContext = new AddressPageViewModel(address);

            txtCity.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence);
            txtState.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence);
            CountryLst.ItemsSource = GetCountries();
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

        private async void BtnSaveAddress_Clicked(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                if (!Validate())
                    return;
                else
                    lblerror.IsVisible = false;

                StackLayout lbl = (StackLayout)sender;
                TapGestureRecognizer labelgesture = (TapGestureRecognizer)lbl.GestureRecognizers.FirstOrDefault();
                string addressType = (string)labelgesture.CommandParameter;


                var updatedAdd = new AddressInfo
                {
                    Address = txtAddress.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    State = txtState.Text.Trim(),
                    Country = ctry,
                    PinCode = txtPincode.Text.Trim(),
                    AddressType = addressType
                };


                XLLoader.IsVisible = true;
                ResultInfo<string, HttpStatusCode> result = await RestClient.PostAsync<ResultInfo<string, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.MyAddress, updatedAdd);
                XLLoader.IsVisible = false;
                if (result.Status == HttpStatusCode.OK)
                {
                    App.IsProfileChanged = true;
                    ShowAlertBox(AlertType.OK, "INFO", "Record saved successfully !", btnppok_Click, null, null);
                }
                else
                {
                    ShowAlertBox(AlertType.OK, "INFO", result.Message, btnppok_Click, null, null);
                }
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "INFO", connectionStatus, btnok_Click, null, null);

        }
        bool Validate()
        {
            if (txtAddress.Text == "")
            {
                lblerror.Text = "Please enter Address !";
                lblerror.IsVisible = true;
                return false;
            }
            else if (txtCity.Text == "")
            {
                lblerror.Text = "Please enter City !";
                lblerror.IsVisible = true;
                return false;
            }
            else if (txtState.Text == "")
            {
                lblerror.Text = "Please enter State !";
                lblerror.IsVisible = true;
                return false;
            }
            else if (CountryLst.SelectedItem == null || string.IsNullOrEmpty(CountryLst.SelectedItem.ToString()))
            {
                lblerror.Text = "Please enter Country !";
                lblerror.IsVisible = true;
                return false;
            }
            else if (txtPincode.Text == "")
            {
                lblerror.Text = "Please enter Pincode !";
                lblerror.IsVisible = true;
                return false;
            }
            else if (!IsNumeric(txtPincode.Text))
            {
                lblerror.Text = "Pincode field should be numeric !";
                lblerror.IsVisible = true;
                return false;
            }
            else
                return true;
        }

        public List<string> GetCountries()
        {
            return new List<string>()
            {
                "India"
            };
        }

        private void CountryLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctry = CountryLst.SelectedItem.ToString();
        }
    }

    class AddressPageViewModel : INotifyPropertyChanged
    {
        public AddressInfo info { get; set; }
        public ObservableCollection<string> Countries { get; set; }

        public string fontfamily_reg { get; set; }
        public string fontfamily_bold { get; set; }
        public AddressPageViewModel(AddressInfo entity)
        {
            info = entity;

           Countries = new ObservableCollection<string>()
            {
                "Afghanistan",
                    "Albania",
                    "Algeria",
                    "Andorra",
                     "Angola",
        "Antigua and Barbuda",
                   "Argentin",
                    "Armenia",
                      "Aruba",
                  "Australia",
                    "Austria",
                 "Azerbaijan",
               "Bahamas, The",
                    "Bahrain",
                 "Bangladesh",
                   "Barbados",
                    "Belarus",
                    "Belgium",
                     "Belize",
                      "Benin",
                     "Bhutan",
                    "Bolivia",
     "Bosnia and Herzegovina",
                   "Botswana",
                     "Brazil",
                     "Brunei",
                   "Bulgaria",
               "Burkina Faso",
                      "Burma",
                    "Burundi",
                   "Cambodia",
                   "Cameroon",
                     "Canada",
                 "Cabo Verde",
   "Central African Republic",
                       "Chad",
                      "Chile",
                      "China",
                   "Colombia"
};
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
