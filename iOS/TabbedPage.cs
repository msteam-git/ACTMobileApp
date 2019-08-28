using Polcirkelleden;
using Polcirkelleden.Interfaces;
using Polcirkelleden.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Nature), typeof(MainPageRenderer))]
namespace Polcirkelleden.iOS
{
    public class MainPageRenderer : TabbedRenderer
    {
        Nature _page;
        readonly nfloat imageYOffset = 7.0f;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
                _page = e.NewElement as Nature;
            else
                _page = e.OldElement as Nature;

            try
            {
                if (ViewController is UITabBarController tabBarController)
                    tabBarController.ViewControllerSelected += OnTabbarControllerItemSelected;
                
            }
            catch (Exception)
            {
                //Debug.WriteLine(exception);
            }
        }

        void OnTabbarControllerItemSelected(object sender, UITabBarSelectionEventArgs eventArgs)
        {
            if (_page?.CurrentPage?.Navigation != null && _page.CurrentPage.Navigation.NavigationStack.Count > 0)
            {
                //Debug.WriteLine("Tab Tapped");
                //Handle Tab Tapped
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (TabBar.Items != null)
            {
                foreach (var item in TabBar.Items)
                {
                    item.Title = null;
                    item.ImageInsets = new UIEdgeInsets(imageYOffset, 0, -imageYOffset, 0);
                }
            }
        }
    }

}
