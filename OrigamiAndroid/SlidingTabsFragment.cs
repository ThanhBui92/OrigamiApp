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
using Android.Support.V4.View;
using OrigamiCore.ViewModels;

namespace OrigamiAndroid
{
    public class SlidingTabsFragment : Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;
        public FirstViewModel viewmodel;
        public SlidingTabsFragment(FirstViewModel m)
        {
            this.viewmodel = m;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePagerAdapter(viewmodel, view.Context);

            mSlidingTabScrollView.ViewPager = mViewPager;
        }

        public class SamplePagerAdapter : PagerAdapter
        {
            List<string> items = new List<string>();
            private FirstViewModel _fvm;
            private Context _con;
            public SamplePagerAdapter(FirstViewModel fvm, Context con)
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
                    return _fvm.Items.Count;
                }
            }

            public override bool IsViewFromObject(View view, Java.Lang.Object obj)
            {
                return view == obj;
            }

            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item, container, false);
                container.AddView(view);
                ListView txtTitle = view.FindViewById<ListView>(Resource.Id.listView1);
                txtTitle.Adapter = new OrigamiAdapter(_fvm.Items[position].Items.ToList());
                txtTitle.ItemClick += (s, e) =>
                {
                    var clickedItem = _fvm.Items[position].Items[e.Position];
                    Toast.MakeText(container.Context, clickedItem.Title, ToastLength.Short).Show();
                    _fvm.ShowDetailCommand.Execute(clickedItem);
                    //var intent = new Intent(container.Context,typeof(OrigamiItemView)); 
                    //container.Context.StartActivity(intent);
                };
                return view;
            }

            public string GetHeaderTitle(int position)
            {
                return _fvm.Items[position].Title;
            }

            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj);
            }
        }
    }
}