using Android.App;
using Android.Views;
using Android.Widget;
using risersoft.shared.portable.Models.HR;
using Risersoft.Framework.CustomRenderer;
using System.Collections.Generic;
using System.Linq;


namespace Risersoft.Framework.Droid.Renderer
{
    public class NativeAndroidListViewAdapter : BaseAdapter<PersEduInfo>
    {
        readonly Activity context;
        IList<PersEduInfo> tableItems = new List<PersEduInfo>();

        public IEnumerable<PersEduInfo> Items
        {
            set
            {
                tableItems = value.ToList();
            }
        }

        public NativeAndroidListViewAdapter(Activity context, NativeListView view)
        {
            this.context = context;
            //tableItems = view.Items.ToList();
        }

        public override PersEduInfo this[int position]
        {
            get
            {
                return tableItems[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return tableItems.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = tableItems[position];

            var view = convertView;
            if (view == null)
            {
                // no view to re-use, create new
                //view = context.LayoutInflater.Inflate(Resource.Layout.education_list_item, null);
            }

            //view.FindViewById<TextView>(Resource.Id.txtinstitute).Text = item.Institution;
            //view.FindViewById<TextView>(Resource.Id.txtqualification).Text = item.Qualification;
            //view.FindViewById<TextView>(Resource.Id.txtyear).Text = item.YearQual;
            //view.FindViewById<TextView>(Resource.Id.txtmarks).Text = item.Marks.ToString();
            // view.FindViewById<TextView>(Resource.Id.Text2).Text = item.Category;

            // grab the old image and dispose of it
            //if (view.FindViewById<ImageView>(Resource.Id.Image).Drawable != null)
            //{
            //    using (var image = view.FindViewById<ImageView>(Resource.Id.Image).Drawable as BitmapDrawable)
            //    {
            //        if (image != null)
            //        {
            //            if (image.Bitmap != null)
            //            {
            //                //image.Bitmap.Recycle ();
            //                image.Bitmap.Dispose();
            //            }
            //        }
            //    }
            //}

            // If a new image is required, display it
            //if (!String.IsNullOrWhiteSpace(item.ImageFilename))
            //{
            //    context.Resources.GetBitmapAsync(item.ImageFilename).ContinueWith((t) => {
            //        var bitmap = t.Result;
            //        if (bitmap != null)
            //        {
            //            view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(bitmap);
            //            bitmap.Dispose();
            //        }
            //    }, TaskScheduler.FromCurrentSynchronizationContext());
            //}
            //else
            //{
            //    // clear the image
            //    view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(null);
            //}

            return view;
        }
    }
}