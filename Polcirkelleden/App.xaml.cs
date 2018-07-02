using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Polcirkelleden
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Application.Current.Properties.Keys.Any(b => b == "Language"))
            {
                Application.Current.MainPage = new Polcirkelleden.MainPage();
            }
            else
            {
                MainPage = new PolcirkelledenPage();
                
            }
        }
      
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
         
    }

   
}
