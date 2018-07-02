using System;
using Xamarin.Forms;

namespace Polcirkelleden
{
	public class MainPageCS : MasterDetailPage
	{
		MasterPageCS masterPage;

		public MainPageCS ()
		{
			masterPage = new MasterPageCS ();
			Master = masterPage;
			Detail = new NavigationPage (new ContactsPageCS ());

			masterPage.ListView.ItemSelected += OnItemSelected;

		}

		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null) {
				Detail = new NavigationPage ((Page)Activator.CreateInstance (item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}
