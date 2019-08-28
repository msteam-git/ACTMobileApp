using AudioManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace Polcirkelleden
{
    public partial class Instruction_Page1 : ContentPage
    {
        public Instruction_Page1()
        {
            InitializeComponent();
            //BindingContext = new AudioPlayerViewModel(DependencyService.Get<IAudioPlayerService>());
            //AudioPlayerViewModel.instance = (AudioPlayerViewModel)BindingContext;
            //InstructionsPlay.Clicked += InstructionsPlayClick;
            SetControlLanguage();
            var baseURL = DependencyService.Get<IBaseUrl>().Get();
            var url = Application.Current.Properties["Language"].ToString()=="English" ? System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_Eng1.html"): System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_SV1.html");
            var source = new UrlWebViewSource();
            source.Url = url;
            webView.Source = source;
            this.Disappearing += WebView_Disappearing;
          
            nextButton.Clicked += OnNextPageClicked;
            if (Device.RuntimePlatform == Device.iOS)
            {
                NavigationPage.SetBackButtonTitle(this, "");
                if (Application.Current.Properties["Language"].ToString() == "English")
                {
                    webView.HeightRequest = 1150;
                }
                else
                    webView.HeightRequest = 1200;
                //webView.IsEnabled = false;
            }
        }

        private void WebView_Disappearing(object sender, EventArgs e)
        {
            WebView view5 = this.FindByName<WebView>("webView");
            view5.Eval("stopAudio()");
        }

        //private void InstructionsPlayClick(object sender, EventArgs e)
        //{
        //    InstructionsPlay.Text = AudioPlayerViewModel.instance.CommandText == "Audio Information" ? "Audio Information" : "Pause";
        //}

        void OnNextPageClicked(object sender, EventArgs e)
        {
            //var source = new UrlWebViewSource();
            //var baseURL = DependencyService.Get<IBaseUrl>().Get();
            //source.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_Eng1.html") : System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_SV1.html");
            //webView.Source = source;
            Application.Current.Properties["GotIt"] = true;
            Application.Current.MainPage = new Polcirkelleden.MainPage();
            //await Navigation.PushAsync(new Instruction_Page2());
        }

        void SetControlLanguage()
        {
            try
            {
                Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Welcome_Instruction : AppResourceSweden.Welcome_Instruction;
                nextButton.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.GotIt : AppResourceSweden.GotIt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SetControlLanguage() Exception Page1!!!");
                Debug.WriteLine("Exception Description: " + ex);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            //stop the videoview
            //DependencyService.Get<IAudioPlayerService>().Stop();
            //AudioPlayerViewModel.instance._isStopped = true;
            //AudioPlayerViewModel.instance.CommandText = "Audio Information";
            var source = new UrlWebViewSource();
            var baseURL = DependencyService.Get<IBaseUrl>().Get();
            source.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_Eng1.html") : System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_SV1.html");
            webView.Source = source;

            return base.OnBackButtonPressed();
        }
    }
}
