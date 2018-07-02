using Polcirkelleden.Interfaces;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Polcirkelleden
{
    public partial class MainPage : MasterDetailPage
    {
        public NavigationPage DetailNavigation;

        public MainPage()
        {
            try
            {
                InitializeComponent();
                if(Device.RuntimePlatform==Device.iOS)
                {
                    DependencyService.Get<ICustomStatusBarService>().ThemeChange();
                }
                if (Application.Current.Properties.Keys.Any(b => b == "GotIt"))
                {
                    DetailNavigation = new NavigationPage(new MapPage());
                    Detail = DetailNavigation;
                    MasterBehavior = MasterBehavior.Popover;
                    IsGestureEnabled = true;
                   
                }
                else
                {
                    IsGestureEnabled = false;
                }
                masterPage.ListView.ItemSelected += OnItemSelected;
              

                //MessagingCenter.Subscribe<ContentPage>(this, "OpenInDetail", (sender) =>
                //{
                //    Detail = new NavigationPage(sender);
                //});
                IsPresentedChanged += OnPresentedChanged;
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = e.SelectedItem as MasterPageItem;
                if (item != null)
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    masterPage.ListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To hide and show masterPage on hamburger click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPresentedChanged(object sender, EventArgs e)
        {
            var currentPresented = this.IsPresented;
            if (Application.Current.Properties.Keys.Any(b => b == "GotIt"))
            {
                if(currentPresented)
                this.IsPresented = true;
            }
            else
            {
                this.IsPresented = false;
            }
        }
    }
}
