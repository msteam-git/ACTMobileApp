﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Polcirkelleden
{
    public static class RootHelper
    {
        public static MainPage RootPage()
        {
            return (MainPage)Application.Current.MainPage;
        }

        public static void NavigateToHomePage()
        {
            try
            {
                AboutUs homePage = new AboutUs();
                MainPage masterDetailRootPage = (MainPage)Application.Current.MainPage;
                masterDetailRootPage.Detail = new NavigationPage(homePage);
                masterDetailRootPage.IsPresented = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("!!! NavigateToHomePage() Exception !!!");
                Debug.WriteLine("Exception Description: " + ex);
            }
        }
    }
}
