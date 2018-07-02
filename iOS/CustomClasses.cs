using System;
using Foundation;
using Polcirkelleden.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_iOS))]
namespace Polcirkelleden.iOS
{
    public class BaseUrl_iOS : IBaseUrl
    {
        public string Get()
        {
            return NSBundle.MainBundle.BundlePath; // to load resources in the iOS app itself
        }

    }
}