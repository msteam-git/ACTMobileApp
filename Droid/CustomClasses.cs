using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android;
using Android.Content;
using Android.Views;
using Android.Content.Res;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Support.Design.Widget;

[assembly: ExportRenderer(typeof(Polcirkelleden.CustomImageCell), typeof(Polcirkelleden.CustomImageCellRenderer))]

namespace Polcirkelleden
{
    public class CustomImageCellRenderer : ImageCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            LinearLayout cell = (LinearLayout)base.GetCellCore(item, convertView, parent, context);
            ImageView image = (ImageView)cell.GetChildAt(0);
            image.SetScaleType(ImageView.ScaleType.FitCenter);
            //image.SetMinimumHeight(10);
            //image.SetMaxHeight(10);
            //cell.
            //android:textAppearance=""?android:attr/textAppearanceLarge"

            //cell.(Android.Graphics.Color.White);
            return cell;
        }
    }
}