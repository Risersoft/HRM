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

    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EducationPage : BasePage, ICanHideBackButton
    {
        public bool HideBackButton { get; set; }
        public EducationPage()
        {
            InitializeComponent();
            txtInstituteName.Text = string.Empty;
            txtMarks.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtYear.Text = string.Empty;

            BindingContext = new EducationPageViewModel();
        }

        bool Validate()
        {
            if (txtInstituteName.Text == "")
            {
                lblerror.Text = "Please enter Institution Name !";
                lblerror.IsVisible = true;
                return false;
            }
            if (txtQualification.Text == "")
            {
                lblerror.Text = "Please enter Qualification !";
                lblerror.IsVisible = true;
                return false;
            }
            if (txtYear.Text == "")
            {
                lblerror.Text = "Please enter Year !";
                lblerror.IsVisible = true;
                return false;
            }

            if (!IsNumeric(txtYear.Text))
            {
                lblerror.Text = "Year field should be numeric !";
                lblerror.IsVisible = true;
                return false;
            }

            if (txtYear.Text.Length != 4)
            {
                lblerror.Text = "Year field should be in (YYYY) format !";
                lblerror.IsVisible = true;
                return false;
            }

            if (txtMarks.Text == "")
            {
                lblerror.Text = "Please enter Marks !";
                lblerror.IsVisible = true;
                return false;
            }

            if (!IsNumeric(txtMarks.Text))
            {
                lblerror.Text = "Marks field should be numeric !";
                lblerror.IsVisible = true;
                return false;
            }
            else
                return true;
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

        private async void BtnSaveEducation_Clicked(object sender, EventArgs e)
        {
            var connectionStatus = await Utility.GetConnectivityStatus();
            if (string.IsNullOrWhiteSpace(connectionStatus))
            {
                if (!Validate())
                    return;
                else
                    lblerror.IsVisible = false;

                var newEducation = new PersEduInfo()
                {
                    Institution = txtInstituteName.Text.Trim(),
                    Qualification = txtQualification.Text.Trim(),
                    YearQual = txtYear.Text.Trim(),
                    Marks = Convert.ToDecimal(txtMarks.Text.Trim())
                };

                XLLoader.IsVisible = true;
                ResultInfo<string, HttpStatusCode> result = await RestClient.PostAsync<ResultInfo<string, HttpStatusCode>>(AppConstants.apiBaseUri,AppConstants.MyEducation, newEducation);
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


    }

    class EducationPageViewModel : INotifyPropertyChanged
    {
        public string fontfamily_reg { get; set; }
        public string fontfamily_bold { get; set; }
        public EducationPageViewModel()
        {
            fontfamily_reg = Utility.GetFont(FontStyle.REGULAR);
            fontfamily_bold = Utility.GetFont(FontStyle.BOLD);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
