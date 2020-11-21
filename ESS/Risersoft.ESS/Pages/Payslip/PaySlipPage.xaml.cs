using Risersoft.Framework.Dependency;
using Risersoft.Framework.Pages.Framework;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Risersoft.ESS.Pages
{

    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaySlipPage : BasePage, ICanHideBackButton
    {
        public bool HideBackButton { get; set; }
        public PaySlipPage()
        {
            InitializeComponent();
            //BindingContext = new ContentPageViewModel();
            var StkBtnGoGesture = new TapGestureRecognizer();
            StkBtnGoGesture.Tapped += StkBtnGoGesture_Tapped;
            StkBtnGo.GestureRecognizers.Add(StkBtnGoGesture);
        }

        private async void StkBtnGoGesture_Tapped(object sender, EventArgs e)
        {
            //var selectedDate = txtDatePicker.Date.ToString("yyyy-MM-dd");
            //await RestClient.GetAsyncTest<dynamic>(AppConstants.MyPayslip + selectedDate);
        }
    }

    class PaySlipPageViewModel : INotifyPropertyChanged
    {

        public PaySlipPageViewModel()
        {

        }

       

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
