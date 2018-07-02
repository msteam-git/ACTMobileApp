using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;

namespace Polcirkelleden.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
            var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
            //x = typeof(Xamarin.Forms.Themes.iOS.CornerRadiusEffect);
            //x = typeof(Xamarin.Forms.Themes.iOS.UnderlineEffect);
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            
            global::Xamarin.Forms.Forms.Init();
           
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
