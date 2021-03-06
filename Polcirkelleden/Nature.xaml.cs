﻿using AudioManager.Interfaces;
using Polcirkelleden.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Polcirkelleden
{
    public partial class Nature 
    {
        //private int count = 0;
        private string baseURL = DependencyService.Get<IBaseUrl>().Get();
        public Nature()
        {
            try
            {
                InitializeComponent();
                SetControlLanguage();
                Reindeer.Disappearing += Reindeer_Disappearing;
                Taiga.Disappearing += Taiga_Disappearing;
                BirchPolypore.Disappearing += BirchPolypore_Disappearing;
                Black.Disappearing += Black_Disappearing;
                Bear.Disappearing += Bear_Disappearing;
                Freshwater.Disappearing += Freshwater_Disappearing;
                Siberian.Disappearing += Siberian_Disappearing;

                //if(Device.RuntimePlatform==Device.iOS)
                //{

                //    DependencyService.Get<ITabbedPage>().TabRender(this);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Nature() Exception !!!");
                Debug.WriteLine("Exception Description: " + ex);
            }
        }

        /// <summary>
        /// Set Language of specific controls on page
        /// </summary>
        void SetControlLanguage()
        {
            // Tabbed Page Title
            Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Animal_Header : AppResourceSweden.Animal_Header;
            
            lblReindeerHeader.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleA : AppResourceSweden.Aminal_TitleA;
            lblTaigaHeader.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleB : AppResourceSweden.Aminal_TitleB;
            lblBirchPolyporeHeader.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleC : AppResourceSweden.Aminal_TitleC;
            lblBlackHeader.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleD : AppResourceSweden.Aminal_TitleD;
            lblBearHeader.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleE : AppResourceSweden.Aminal_TitleE;
            lblFreshwaterHeader.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleF : AppResourceSweden.Aminal_TitleF;
            lblSiberianHeader.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleG : AppResourceSweden.Aminal_TitleG;

            if (Device.RuntimePlatform == Device.iOS)
            {
                lblBearHeader.IsVisible = false;
                lblFreshwaterHeader.IsVisible = false;
                lblSiberianHeader.IsVisible = false;
                bearWebView.HeightRequest = 500;

                Bear.Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleE : AppResourceSweden.Aminal_TitleE;
                Freshwater.Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleF : AppResourceSweden.Aminal_TitleF;
                Siberian.Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Aminal_TitleG : AppResourceSweden.Aminal_TitleG;
            }
            else
            {
                lblBearHeader.IsVisible = true;
                lblFreshwaterHeader.IsVisible = true;
                lblSiberianHeader.IsVisible = true;
            }

            Reindeer.IconImageSource = "reindeernew.png";
            Taiga.IconImageSource = "forest.png";
            BirchPolypore.IconImageSource = "birch.png";
            Black.IconImageSource = "grouse.png";
            Bear.IconImageSource = "bearnew.png";
            Freshwater.IconImageSource = "clam.png";
            Siberian.IconImageSource = "bird.png";
            
            //baseURL = DependencyService.Get<IBaseUrl>().Get();

            // Reindeer Data
            var source = new UrlWebViewSource();
            source.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Nature_Html/Reindeer_Eng.html") : System.IO.Path.Combine(baseURL, "Nature_Html/Reindeer_SV.html");
            reindeerWebView.Source = source;

            // BirchPolypore Data
            var source1 = new UrlWebViewSource();
            source1.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Nature_Html/BirchPolypore_Eng.html") : System.IO.Path.Combine(baseURL, "Nature_Html/BirchPolypore_SV.html");
            birchWebView.Source = source1;

            // Black Grouse And Wood Grouse Data
            var source2 = new UrlWebViewSource();
            source2.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Nature_Html/BlackGrouse_Eng.html") : System.IO.Path.Combine(baseURL, "Nature_Html/BlackGrouse_SV.html");
            blackWebView.Source = source2;

            // Bear - Brunbjörn Data
            var source3 = new UrlWebViewSource();
            source3.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Nature_Html/Bear_Eng.html") : System.IO.Path.Combine(baseURL, "Nature_Html/Bear_SV.html");
            bearWebView.Source = source3;

            //Fresh Water Mussel Audio
            var source4 = new UrlWebViewSource();
            source4.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Nature_Html/Freshwater_Eng.html") : System.IO.Path.Combine(baseURL, "Nature_Html/Freshwater_SV.html");
            freshWaterWebView.Source = source4;
            //freshWaterWebView.IsEnabled = false;

            //Taiga Audio
            var source5 = new UrlWebViewSource();
            source5.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Nature_Html/Taiga_Eng.html") : System.IO.Path.Combine(baseURL, "Nature_Html/Taiga_SV.html");
            taigaWebView.Source = source5;
            //taigaWebView.IsEnabled = false;

            //Siberian Jay Audio
            var source6 = new UrlWebViewSource();
            source6.Url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Nature_Html/Siberian_Eng.html") : System.IO.Path.Combine(baseURL, "Nature_Html/Siberian_SV.html");
            siberianWebView.Source = source6;
            //siberianWebView.IsEnabled = false;

            // Contect Pages Label text
            //lblTaiga.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Animal_Taiga : AppResourceSweden.Animal_Taiga;
            //lblFreshWater.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Animal_FreshWater : AppResourceSweden.Animal_FreshWater;
            //lblSiberian.Text = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Animal_Siberian : AppResourceSweden.Animal_Siberian;
           
           
        }


        /// <summary>
        /// Phone back button click
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            reindeerWebView.Eval("stopAudio()");
            taigaWebView.Eval("stopAudio()");
            blackWebView.Eval("stopAudio()");
            birchWebView.Eval("stopAudio()");
            freshWaterWebView.Eval("stopAudio()");
            bearWebView.Eval("stopAudio()");
            siberianWebView.Eval("stopAudio()");
            return base.OnBackButtonPressed();
        }

        #region On Tab page disappering to stop the audio if running 

        private void Reindeer_Disappearing(object sender, EventArgs e)
        {
            WebView view = this.FindByName<WebView>("reindeerWebView");
            view.Eval("stopAudio()");
        }

        private void Siberian_Disappearing(object sender, EventArgs e)
        {
            WebView view6 = this.FindByName<WebView>("siberianWebView");
            view6.Eval("stopAudio()");
        }

        private void Freshwater_Disappearing(object sender, EventArgs e)
        {
            WebView view5 = this.FindByName<WebView>("freshWaterWebView");
            view5.Eval("stopAudio()");
        }

        private void Bear_Disappearing(object sender, EventArgs e)
        {
            WebView view4 = this.FindByName<WebView>("bearWebView");
            view4.Eval("stopAudio()");
        }

        private void Black_Disappearing(object sender, EventArgs e)
        {
            WebView view3 = this.FindByName<WebView>("blackWebView");
            view3.Eval("stopAudio()");
        }

        private void BirchPolypore_Disappearing(object sender, EventArgs e)
        {
            WebView view2 = this.FindByName<WebView>("birchWebView");
            view2.Eval("stopAudio()");
        }

        private void Taiga_Disappearing(object sender, EventArgs e)
        {
            WebView view1 = this.FindByName<WebView>("taigaWebView");
            view1.Eval("stopAudio()");
        }

        #endregion

    }
}

