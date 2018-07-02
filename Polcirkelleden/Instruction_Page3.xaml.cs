using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace Polcirkelleden
{
    public partial class Instruction_Page3 : ContentPage
    {
        public Instruction_Page3()
        {
            InitializeComponent();
            SetControlLanguage();

            // Binding Instructions
            var baseURL = DependencyService.Get<IBaseUrl>().Get();
            var url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_Eng3.html") : System.IO.Path.Combine(baseURL, "Html_Instructions/Instruction_SV3.html");
            var source = new UrlWebViewSource();
            source.Url = url;
            webView.Source = source;

            // Button delegate
            finishBtn.Clicked += OnFinishClicked;
        }

        /// <summary>
        /// OnFinishClicked Button CLick Event
        /// </summary>
        void OnFinishClicked(object sender, EventArgs e)
        {
            try
            {
                Application.Current.Properties["GotIt"] = true;
                Application.Current.MainPage = new MainPage { Detail = new NavigationPage(new MainPage()) };
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
                Debug.WriteLine("SetControlLanguage() Exception Page3!!!");
                Debug.WriteLine("Exception Description: " + ex);
            }
        }
    }
}
