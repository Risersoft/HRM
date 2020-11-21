using Plugin.Media;
using risersoft.shared;
using risersoft.shared.portable.Models.HR;
using Risersoft.ESS.Global;
using Risersoft.Framework.Dependency;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages.Alert;
using Risersoft.Framework.Pages.Framework;
using Risersoft.Framework.Service;
using Risersoft.Framework.XFView;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static Risersoft.Framework.Global.Utility;

namespace Risersoft.ESS.Pages.Profile
{

    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : BasePage, ICanHideBackButton
    {
        public bool HideBackButton { get; set; }
        ProfilePageViewModel vm;
        public ProfilePage(bool IsFromDrawer = false)
        {
            HideBackButton = IsFromDrawer;
            InitializeComponent();
            BindInfo();

            var stkbtnEditPrAddressGesture = new TapGestureRecognizer();
            stkbtnEditPrAddressGesture.Tapped += (o, e) => stkbtnEditPrAddressGesture_Tapped(o, e);
            stkbtnEditPrAddress.GestureRecognizers.Add(stkbtnEditPrAddressGesture);

            var stkbtnEditPmAddressGesture = new TapGestureRecognizer();
            stkbtnEditPmAddressGesture.Tapped += (o, e) => stkbtnEditPmAddressGesture_Tapped(o, e);
            stkbtnEditPmAddress.GestureRecognizers.Add(stkbtnEditPmAddressGesture);

            var stkbtnAddEducationGesture = new TapGestureRecognizer();
            stkbtnAddEducationGesture.Tapped += stkbtnAddEducationGesture_Tapped;
            stkbtnAddEducation.GestureRecognizers.Add(stkbtnAddEducationGesture);

            var stkbtnAddFamilyGesture = new TapGestureRecognizer();
            stkbtnAddFamilyGesture.Tapped += stkbtnAddFamilyGesture_Tapped;
            stkbtnAddFamily.GestureRecognizers.Add(stkbtnAddFamilyGesture);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (App.IsProfileChanged)
            {
                BindInfo();
                App.IsProfileChanged = false;
            }
        }
        
        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            if (App.IsNewUploaded)
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
                var pic = await DependencyService.Get<ISavePic>().GetPhoto();
                if (pic != null)
                    ((App)Application.Current).SetUserPic(pic);
                else
                        {
                            var profilePicUris = App.EmployeeInfo.Data.ProfilePicUris;
                            var picToBeDownloaded = profilePicUris[profilePicUris.Count - 1];

                            HttpClient client = new HttpClient();
                            var getPicResponse = await client.GetByteArrayAsync(picToBeDownloaded);
                            DependencyService.Get<ISavePic>().SavePicAsync(getPicResponse);

                            var newUploadedPic = await DependencyService.Get<ISavePic>().GetPhoto();
                            ((App)Application.Current).SetUserPic(newUploadedPic);
                        }
                App.IsNewUploaded = false;
            }
        }
        PersonInfo personinfo;
        async void BindInfo()
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                XLLoader.IsVisible = true;
                var result = await RestClient.GetAsync<ResultInfo<PersonInfo, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.MyPerson);
                personinfo = result.Data;
                if (personinfo != null)
                {
                    vm = new ProfilePageViewModel(personinfo, this.Navigation);
                    BindingContext = vm;

                }
                await SetProfilePic();
                XLLoader.IsVisible = false;
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "ALERT", connectionStatus, btnok_Click, null, null);
        }

        private async Task SetProfilePic()
        {
            var myPhoto = await DependencyService.Get<ISavePic>().GetPhoto();
            if (myPhoto != null)
            {
                imgprofilepic.Source = ImageSource.FromStream(() =>
                {
                    var stream = myPhoto;
                    return stream;
                });
            }
        }
        private async void stkbtnEditPmAddressGesture_Tapped(object o, EventArgs e)
        {
            await this.Navigation.PushAsync(new AddressPage(personinfo.PmAddress, "pm"));
        }

        private async void stkbtnEditPrAddressGesture_Tapped(object o, EventArgs e)
        {
            await this.Navigation.PushAsync(new AddressPage(personinfo.PrAddress, "pr"));
        }

        private async void stkbtnAddFamilyGesture_Tapped(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new FamilyPage());
        }

        private async void stkbtnAddEducationGesture_Tapped(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new EducationPage());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                StackLayout lbl = (StackLayout)sender;
                TapGestureRecognizer labelgesture = (TapGestureRecognizer)lbl.GestureRecognizers.FirstOrDefault();
                int PersFamilyID = (int)labelgesture.CommandParameter;

                XLLoader.IsVisible = true;
                var result = await vm.DeleteFamilyItem(PersFamilyID);
                XLLoader.IsVisible = false;
                if (result != null && result.Status.Equals(HttpStatusCode.OK))
                {
                    ShowAlertBox(AlertType.OK, "INFO", "Record deleted successfully !", btnppok_Click, null, null);
                }
                else
                {
                    ShowAlertBox(AlertType.OK, "INFO", result.Message, btnppok_Click, null, null);
                }
            }
            else
                ShowAlertBox(AlertType.TRYAGAIN, "INFO", connectionStatus, btninok_Click, null, null);
        }

        #region AlertPopUps
        async void btninok_Click()
        {
            ClearPopups();
        }

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

        private async void btnUploadPic_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
               await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }

            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });
            if (file == null)
                return;

            var croppedBytes = await CrossMethod.Current.CropImageFromOriginalToBytes(file.Path);
            if (croppedBytes != null)
                await PutBlob_async(croppedBytes);
        }
        private async Task<string> PutBlob_async(Byte[] blobContent)
        {
            XLLoader.IsVisible = true;
            var urlData = await RestClient.GetAsync<ResultInfo<string, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.ProfilePicUrl);

            if (!string.IsNullOrWhiteSpace(urlData.Data))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("x-ms-blob-type", AppConstants.BlobType);

                HttpContent requestContent = new ByteArrayContent(blobContent);

                var uri = urlData.Data;
                var putPicResponse = await client.PutAsync(uri, requestContent);


                if (putPicResponse.StatusCode == HttpStatusCode.Created)
                {

                    var getPicResponse = await client.GetByteArrayAsync(uri);
                    if (Device.OS == TargetPlatform.Android)
                    {
                        var storagePermission = await DependencyService.Get<IStorage>().StoragePermission();
                        if (storagePermission)
                            DependencyService.Get<ISavePic>().SavePicAsync(getPicResponse);
                        else
                            ShowAlertBox(AlertType.OK, "INFO", "Storage permission required !", btnppok_Click, null, null);
                    }
                    else

                        DependencyService.Get<ISavePic>().SavePicAsync(getPicResponse);
                    await SetProfilePic();
                    var result = await RestClient.GetAsync<ResultInfo<Boolean, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.ConfirmProfilePicUrl + uri);
                    XLLoader.IsVisible = false;
                    if (result.Data == true)
                    {
                        App.IsNewUploaded = true;
                        ShowAlertBox(AlertType.OK, "INFO", "Profile pic has been uploaded successfully !", btnppok_Click, null, null);
                    }
                }
            }
            return null;
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

    public class ProfilePageViewModel : INotifyPropertyChanged
    {
        public string fontfamily_reg { get; set; }
        public string fontfamily_bold { get; set; }

        public ObservableCollection<PersFamilyInfo> PersFamilyInfoItems { get; }
        public ObservableCollection<PersEduInfo> PersEduInfoItems { get; }

        INavigation _navigation;
        ICommand _editFamilyCommand;
        public ICommand EditFamilyTapCommand
        {
            get
            {
                return _editFamilyCommand;
            }
        }

        public ProfilePageViewModel(PersonInfo data, INavigation Navigation)
        {
            fontfamily_reg = Utility.GetFont(FontStyle.REGULAR);
            fontfamily_bold = Utility.GetFont(FontStyle.BOLD);

            PersFamilyInfoItems = new ObservableCollection<PersFamilyInfo>();
            if (data.PersFamilies != null)
            {
                foreach (var item in data.PersFamilies)
                {
                    item.fontfamily_bold = fontfamily_bold;
                    item.fontfamily_reg = fontfamily_reg;
                    PersFamilyInfoItems.Add(item);
                }

            }


            PersEduInfoItems = new ObservableCollection<PersEduInfo>();
            if (data.PersEdus != null)
            {
                foreach (var item in data.PersEdus)
                {
                    item.fontfamily_bold = fontfamily_bold;
                    item.fontfamily_reg = fontfamily_reg;
                    PersEduInfoItems.Add(item);
                }
            }


            if (data.PrAddress != null)
            {
                PrAddress = string.IsNullOrEmpty(data.PrAddress.Address) ? string.Empty :
               data.PrAddress.Address;

                PrCountry = string.IsNullOrWhiteSpace(data.PrAddress.Country) ? string.Empty : data.PrAddress.Country;

                PrState = string.IsNullOrWhiteSpace(data.PrAddress.State) ? string.Empty : data.PrAddress.State;

                PrCity = string.IsNullOrWhiteSpace(data.PrAddress.City) ? string.Empty : data.PrAddress.City;

                PrPincode = string.IsNullOrWhiteSpace(data.PrAddress.PinCode) ? string.Empty : data.PrAddress.PinCode;
            }

            if (data.PmAddress != null)
            {
                PmAddress = string.IsNullOrEmpty(data.PmAddress.Address) ? string.Empty :
                         data.PmAddress.Address;

                PmCountry = string.IsNullOrWhiteSpace(data.PmAddress.Country) ? string.Empty : data.PmAddress.Country;

                PmState = string.IsNullOrWhiteSpace(data.PmAddress.State) ? string.Empty : data.PmAddress.State;

                PmCity = string.IsNullOrWhiteSpace(data.PmAddress.City) ? string.Empty : data.PmAddress.City;

                PmPincode = string.IsNullOrWhiteSpace(data.PmAddress.PinCode) ? string.Empty : data.PmAddress.PinCode;

            }
            _editFamilyCommand = new Command(EditFamilyItem);

            this._navigation = Navigation;

        }
        public async Task<ResultInfo<string,HttpStatusCode>> DeleteFamilyItem(int PersFamilyID)
        {
            var selectedMember = PersFamilyInfoItems.Where(x => x.PersFamilyID == PersFamilyID).FirstOrDefault();
            selectedMember.MemberName = string.Empty;
            var result = await RestClient.PostAsync<ResultInfo<string,HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.MyFamilyMember, selectedMember);
            if (result != null && result.Status.Equals(HttpStatusCode.OK))
            {
                PersFamilyInfoItems.Remove(selectedMember);
            }
            return result;
        }
        private async void EditFamilyItem(object obj)
        {
            var selectedMember = PersFamilyInfoItems.Where(x => x.PersFamilyID == (int)obj).FirstOrDefault();
            await _navigation.PushAsync(new FamilyPage(selectedMember));
        }
        public string PrAddress { get; set; }
        public string PrCountry { get; set; }
        public string PrState { get; set; }
        public string PrCity { get; set; }
        public string PrPincode { get; set; }

        public string PmAddress { get; set; }
        public string PmCountry { get; set; }
        public string PmState { get; set; }
        public string PmCity { get; set; }
        public string PmPincode { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
