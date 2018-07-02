using AudioManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace Polcirkelleden
{
    public partial class Instruction_Page2 : ContentPage
    {
        public Instruction_Page2()
        {
            InitializeComponent();
            // Binding Instructions
            var baseURL = DependencyService.Get<IBaseUrl>().Get();
            var url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_Eng2.html"): System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_SV2.html");
            var source = new UrlWebViewSource();
            source.Url = url;
            webView.Source = source;
            SetControlLanguage();
            // Button delegate
            finishBtn.Clicked += OnFinishClicked;
            //BindingContext = new AudioPlayerViewModel(DependencyService.Get<IAudioPlayerService>());
            //AudioPlayerViewModel.instance = (AudioPlayerViewModel)BindingContext;
            if(Device.RuntimePlatform==Device.iOS)
            {
                webView.HeightRequest = Application.Current.Properties["Language"].ToString() == "English"? 540:720;
                webView.IsEnabled = false;
            }
        }

        //async void OnNextPageClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Instruction_Page3());
        //}

        /// <summary>
        /// OnFinishClicked Button CLick Event
        /// </summary>
        void OnFinishClicked(object sender, EventArgs e)
        {
            try
            {

                //DependencyService.Get<IAudioPlayerService>().Stop();
                //AudioPlayerViewModel.instance._isStopped = true;
                //AudioPlayerViewModel.instance.CommandText = "Audio Information";
                Application.Current.Properties["GotIt"] = true;
                var baseURL = DependencyService.Get<IBaseUrl>().Get();
                var url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_Eng1.html") : System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_SV1.html");
                var source = new UrlWebViewSource();
                source.Url = url;
                webView.Source = source;


                Application.Current.MainPage = new Polcirkelleden.MainPage();
                //Application.Current.MainPage = new MainPage { Detail = new NavigationPage(new MapPage()) }; 
            }
            catch (Exception ex)
            {
                Debug.WriteLine("OnFinishClicked() Exception Page3!!!");
                Debug.WriteLine("Exception Description: " + ex);
            }
        }

        /// <summary>
        /// Bind Control Languages Specific
        /// </summary>
        void SetControlLanguage()
        {
            try
            {
                Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Welcome_Instruction : AppResourceSweden.Welcome_Instruction;
                finishBtn.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.GotIt : AppResourceSweden.GotIt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SetControlLanguage() Exception Page2!!!");
                Debug.WriteLine("Exception Description: " + ex);
            }
        }

    }
}
