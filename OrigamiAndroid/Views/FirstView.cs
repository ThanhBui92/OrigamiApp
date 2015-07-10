using Android.App;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;
using OrigamiCore.ViewModels;
using Android.Widget;

namespace OrigamiAndroid.Views
{
	[Activity(Label = "OrigamiFun")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment(FirstViewModel);
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
		}
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case Resource.Id.menu:
				search ();
				return true;
			default:
				return base.OnOptionsItemSelected (item);
			}
		}
		private void search() {
			Toast.MakeText(this, "You click search", ToastLength.Short).Show();
		}
        protected FirstViewModel FirstViewModel
        {
            get { return base.ViewModel as FirstViewModel; }
        }
    }
}