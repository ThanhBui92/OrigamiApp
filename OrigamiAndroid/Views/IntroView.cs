
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
using OrigamiAndroid.Views;

namespace OrigamiAndroid
{
	[Activity (Label = "IntroView",ParentActivity=typeof(FirstView))]			
	public class IntroView : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.IntroView);
			// Create your application here
		}
	}
}

