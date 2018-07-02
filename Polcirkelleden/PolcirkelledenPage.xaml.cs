using System.Linq;
using Xamarin.Forms;

namespace Polcirkelleden
{
    public partial class PolcirkelledenPage : ContentPage
    {
        public PolcirkelledenPage()
        {
            InitializeComponent();

            if (Application.Current.Properties.Keys.Any(b => b == "Language"))
            {
                Application.Current.MainPage = new Polcirkelleden.MainPage();
            }

            if (Application.Current.Properties.Keys.Any(b => b == "TempLanguage"))
            {
                Application.Current.Properties["Language"] = Application.Current.Properties["TempLanguage"];
                Application.Current.Properties.Remove("TempLanguage");
            }
            var swedish = this.FindByName<Image>("swedish");
            var english = this.FindByName<Image>("english");
            
            //swedish.Clicked += Swedish_Clicked;
            //english.Clicked += English_Clicked;

            var sweImage = new TapGestureRecognizer();
            sweImage.Tapped += Swedish_Clicked;

            var engImage = new TapGestureRecognizer();
            engImage.Tapped += English_Clicked;

            swedish.GestureRecognizers.Add(sweImage);
            english.GestureRecognizers.Add(engImage);

        }

        void Swedish_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.Properties["Language"] = "Swedish";

            Application.Current.MainPage = new Polcirkelleden.MainPage();
        }

        void English_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.Properties["Language"] = "English";
            //Application.Current.MainPage = new Polcirkelleden.Welcome();
            Application.Current.MainPage = new Polcirkelleden.MainPage();
        }
      
    }
}
