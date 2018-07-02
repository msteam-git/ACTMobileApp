using AudioManager.Interfaces;
using System;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Polcirkelleden
{
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();
            Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.About_Header : AppResourceSweden.About_Header;
            var baseURL = DependencyService.Get<IBaseUrl>().Get();
            var source1 = new UrlWebViewSource();
            source1.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_Eng3.html") : System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_SV3.html");
            instructionWebView.Source = source1;
            //DependencyService.Get<IAudioPlayerService>().Stop();
        }
    }
}

