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
using OrigamiCore.Data;

namespace OrigamiAndroid
{
    public class OrigamiAdapter : BaseAdapter<OrigamiItem>
    {
        private List<OrigamiItem> items;

        public OrigamiAdapter(List<OrigamiItem> items)
            : base()
        {
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override OrigamiItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.itemrow1, parent, false);
            var ten = view.FindViewById<TextView>(Resource.Id.ten);
            ten.Text = items[position].Title;
            var mota = view.FindViewById<TextView>(Resource.Id.mota);
            mota.Text = items[position].Description;
            var hinh = view.FindViewById<ImageView>(Resource.Id.hinh);
			int resourceId = parent.Context.Resources.GetIdentifier(items[position].ImagePath, "drawable", parent.Context.PackageName);
            hinh.SetImageResource(resourceId);
            return view;
        }
    }
}
