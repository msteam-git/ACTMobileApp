using AudioManager.Interfaces;
using System;
using System.Linq;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Polcirkelleden
{
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
            SetControlLanguage();
            //DependencyService.Get<IAudioPlayerService>().Stop();
            //Navigation to map page on map icon
            //map.Command = new Command(() =>
            //{
            //    MessagingCenter.Send<ContentPage>(new MapPage(), "OpenInDetail");
            //});
            var baseURL = DependencyService.Get<IBaseUrl>().Get();
            var source = new UrlWebViewSource();
            source.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Welcome/Welcome_Eng.html") : System.IO.Path.Combine(baseURL, "Welcome/Welcome_SV.html");
            welcomeAudioWebView.Source = source;
            this.Disappearing+= WelcomeAudioWebView_Disappearing;
            Instructions.Clicked += Instructions_Clicked;
        }

        /// <summary>
        /// Stop Audio on page change.
        /// </summary>
        private void WelcomeAudioWebView_Disappearing(object sender, EventArgs e)
        {
            welcomeAudioWebView.Eval("stopAudio()");

        }

        /// <summary>
        /// Sets selected language for the welcome page
        /// </summary>
        void SetControlLanguage()
        {
            Welcome_Info.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Welcome_Info : AppResourceSweden.Welcome_Info;
            Welcome_To.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Welcome_To : AppResourceSweden.Welcome_To;
            Welcome_QR.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Welcome_QR : AppResourceSweden.Welcome_QR;
            Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Welcome_Header : AppResourceSweden.Welcome_Header;
            Instructions.Text=Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Welcome_Instruction : AppResourceSweden.Welcome_Instruction;
            //var baseURL = DependencyService.Get<IBaseUrl>().Get();
            //var source = new UrlWebViewSource();
            //source.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Welcome/Welcome_Eng.html") : System.IO.Path.Combine(baseURL, "Welcome/Welcome_SV.html");
            //welcomeAudioWebView.Source = source;
        }

        /// <summary>
        /// Instruction button click navigation to instruction page1
        /// </summary>
        async void Instructions_Clicked(object sender, EventArgs e)
        {
            //if (Application.Current.Properties.Keys.Any(b => b == "GotIt"))
            //{
            //    await Navigation.PushAsync(new Instruction_Page1());
            //}
            //else
            //{
            //    Application.Current.MainPage = new Polcirkelleden.Instruction_Page1();
            //}
            
            await Navigation.PushAsync(new Instruction_Page1());
        }
    }
}

