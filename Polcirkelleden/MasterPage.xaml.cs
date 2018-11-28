using System.Collections.Generic;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Linq;
using AudioManager.Interfaces;

namespace Polcirkelleden
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.Keys.Any(b => b == "GotIt"))
            {
                Icon = "hamburger.png";
                Title = "Polcirkelleden";
                IsEnabled = true;
            }
            else
            {
                Icon = null;
                Title = " ";
                IsEnabled = false;
            }
            var masterPageItems = new List<MasterPageItem>();
           
            masterPageItems.Add(new MasterPageItem
            {
                //Title = "Välkommen",
                Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Welcome_Header : AppResourceSweden.Welcome_Header,
                IconSource = "contacts.png",
                TargetType = typeof(Welcome)
            });
            masterPageItems.Add(new MasterPageItem
            {
                //Title = "Karta",
                Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Map_Header : AppResourceSweden.Map_Header,
                IconSource = "todo.png",
                TargetType = typeof(MapPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                //Title = "Djur & Natur",
                Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.Animal_Header : AppResourceSweden.Animal_Header,
                IconSource = "nature.png",
                TargetType = typeof(Nature)
            });
            masterPageItems.Add(new MasterPageItem
            {
                //Title = "Om Oss",
                Title = Application.Current.Properties["Language"].ToString() == "English" ? AppResourceEnglish.About_Header : AppResourceSweden.About_Header,
                IconSource = "aboutus.png",
                TargetType = typeof(AboutUs)
            });

            listView.ItemsSource = masterPageItems;
            listView.ItemTemplate.SetValue(TextCell.TextColorProperty, Color.White);
            change.Clicked += Change_Clicked;
        }

        void Change_Clicked(object sender, System.EventArgs e)
        {
            //DependencyService.Get<IAudioPlayerService>().Stop();
            Application.Current.Properties["TempLanguage"] = Application.Current.Properties["Language"];
            Application.Current.Properties.Remove("Language");
            Application.Current.MainPage = new Polcirkelleden.PolcirkelledenPage();
        }
    }
}
