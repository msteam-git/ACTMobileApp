using Xamarin.Forms;
using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using System.Threading;
using Nito.AsyncEx;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic;
using System.IO;
using AudioManager.Interfaces;

namespace Polcirkelleden
{
    public partial class MapPage : ContentPage
    {
        System.Timers.Timer myTimer = new System.Timers.Timer();
        public MapPage()
        {
            try
            {
                InitializeComponent();
                Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Map_Header : AppResourceSweden.Map_Header;
                var baseURL = DependencyService.Get<IBaseUrl>().Get();
                var url = Application.Current.Properties["Language"].ToString() == "English" ? System.IO.Path.Combine(baseURL, "Map.html") : System.IO.Path.Combine(baseURL, "Map_Swedish.html");

                var source = new UrlWebViewSource();
                source.Url = url;
                map.Source = source;
                //var myTimer = new System.Timers.Timer();
                myTimer.Elapsed += MyTimer_Elapsed;
                myTimer.Interval = 10000;
                myTimer.Enabled = true;

                this.Disappearing += Map_Disappearing;
                //DependencyService.Get<IAudioPlayerService>().Stop();
                //if (Device.RuntimePlatform == Device.iOS)
                //{
                //    //var cookieJar = NSHttpCookieStorage.SharedStorage;
                //    //cookieJar.AcceptPolicy = NSHttpCookieAcceptPolicy.Always;
                //    //foreach (var aCookie in cookieJar.Cookies)
                //    //{
                //    //    cookieJar.DeleteCookie(aCookie);
                //    //}
                //    NSHttpCookieStorage CookieStorage = NSHttpCookieStorage.SharedStorage;

                //    foreach (var cookie in CookieStorage.Cookies)
                //        CookieStorage.DeleteCookie(cookie);

                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Map_Disappearing(object sender, EventArgs e)
        {
            myTimer.Dispose();
        }

        async Task RunGPS()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 5;
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                Device.BeginInvokeOnMainThread(() =>
                {
                    map.Eval(string.Format("setPosition({0}, {1})", position.Latitude, position.Longitude));
                });
                //map.Eval(string.Format("setPosition({0}, {1})", 30.723494, 76.847195));
                //map.Eval(string.Format("setPosition({0}, {1})", position.Latitude, position.Longitude));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            AsyncContext.Run(() => MyTimer_ElapsedAsync());
        }

        async void MyTimer_ElapsedAsync()
        {
            await RunGPS();
        }
    }
}

