using Android.Media;
using Java.Lang;
using Polcirkelleden.Droid;
using System;
using System.Runtime;
using Xamarin.Forms;
using static Android.Widget.GridLayout;

[assembly: Dependency(typeof(BaseUrl_Android))]
namespace Polcirkelleden.Droid
{
    public class BaseUrl_Android : IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";
        }
    }
}