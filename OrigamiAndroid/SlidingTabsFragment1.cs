using System;
using OrigamiCore.ViewModels;
using Android.Support.V4.View;
using Android.Views;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Widget;
using System.Linq;
using Android.App;

namespace OrigamiAndroid
{
	public class SlidingTabsFragment1 : Fragment
	{
		private SlidingTabScrollView1 mSlidingTabScrollView;
		private ViewPager mViewPager;
		public DetailItemViewModel viewmodel;
		public SlidingTabsFragment1(DetailItemViewModel m)
		{
			this.viewmodel = m;
		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.fragment_sample1, container, false);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView1>(Resource.Id.sliding_tabs1);
			mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager1);
			mViewPager.Adapter = new SamplePagerAdapter1(viewmodel, view.Context);

			mSlidingTabScrollView.ViewPager = mViewPager;
		}

		public class SamplePagerAdapter1 : PagerAdapter
		{
			private DetailItemViewModel _fvm;
			private Context _con;
			//private int pos;
			public SamplePagerAdapter1(DetailItemViewModel fvm, Context con)
				: base()
			{
				_fvm = fvm;
				_con = con;
				//items.Add("Easy Origami");
				//items.Add("Origami Animal");
				//items.Add("Origami Flower");
				//items.Add("Origami Toy");
			}

			public override int Count
			{
				get
				{

					//return items.Count;
					return _fvm.Item.Steps.Count;
				}
			}

			public override bool IsViewFromObject(View view, Java.Lang.Object obj)
			{
				return view == obj;
			}

			public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
			{
				View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item1, container, false);
				container.AddView(view);
				var tu = view.FindViewById<TextView> (Resource.Id.item_tutorial);
				tu.Text = _fvm.Item.Steps[position].Tutorial;
				var hinh = view.FindViewById<ImageView>(Resource.Id.hinh1);
				int resourceId = container.Context.Resources.GetIdentifier("ladybug","drawable", container.Context.PackageName);
				hinh.SetImageResource(resourceId);
				//ListView txtTitle = view.FindViewById<ListView>(Resource.Id.listView1);
				//txtTitle.Adapter = new OrigamiAdapter(_fvm.Items[position].Items.ToList());
				//txtTitle.ItemClick += (s, e) =>
				//{
					//var clickedItem = _fvm.Items[position].Items[e.Position];
					//Toast.MakeText(container.Context, clickedItem.Title, ToastLength.Short).Show();
					//_fvm.ShowDetailCommand.Execute(clickedItem);
					//var intent = new Intent(container.Context,typeof(OrigamiItemView)); 
					//container.Context.StartActivity(intent);
				//};
				return view;
			}

			public string GetHeaderTitle(int position)
			{
				return _fvm.Item.Steps[position].Header;
			}

			public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
			{
				container.RemoveView((View)obj);
			}
		}
	}
}
