using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using OrigamiCore.ViewModels;

namespace OrigamiAndroid.Views
{
	[Activity(Label = "Origami",ParentActivity=typeof(FirstView))]
    public class DetailItemView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // you have to create game.xml 
            SetContentView(Resource.Layout.OrigamiItemView);
			FragmentTransaction transaction = FragmentManager.BeginTransaction();
			SlidingTabsFragment1 fragment = new SlidingTabsFragment1(DetailItemViewModel);
			transaction.Replace(Resource.Id.sample_content_fragment1, fragment);
			transaction.Commit();
			ActionBar actionBar = this.ActionBar;
			actionBar.SetDisplayHomeAsUpEnabled(true);
        }
        protected DetailItemViewModel DetailItemViewModel
        {
            get { return base.ViewModel as DetailItemViewModel; }
        }
    }
}