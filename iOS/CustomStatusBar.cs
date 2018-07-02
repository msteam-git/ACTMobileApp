using System;
using AudioManager.Interfaces;
using AVFoundation;
using Foundation;
using Polcirkelleden.Interfaces;
using Polcirkelleden.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Polcirkelleden.iOS.ICustomStatusBarService))]
namespace Polcirkelleden.iOS
{
    public class ICustomStatusBarService : Interfaces.ICustomStatusBarService
    {
        public void ThemeChange()
        {
            UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = UIColor.White;//color.ToUIColor();
            }
        }
    }
}
