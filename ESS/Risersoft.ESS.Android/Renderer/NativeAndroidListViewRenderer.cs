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
using Xamarin.Forms.Platform.Android;
using Risersoft.Framework.CustomRenderer;
using Xamarin.Forms;
using Risersoft.Framework.Droid.Renderer;

[assembly: ExportRenderer(typeof(NativeListView), typeof(NativeAndroidListViewRenderer))]
namespace Risersoft.Framework.Droid.Renderer
{
    public class NativeAndroidListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // unsubscribe
                //Control.ItemClick -= OnItemClick;
            }

            if (e.NewElement != null)
            {
                // subscribe

                //Control.Adapter = new NativeAndroidListViewAdapter(Forms.Context as Android.App.Activity, e.NewElement as NativeListView);
                var listView = this.Control as Android.Widget.ListView;
                listView.NestedScrollingEnabled = true;
               // Control.ItemClick += OnItemClick;
            }
        }

        //protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);

        //    if (e.PropertyName == NativeListView.ItemsProperty.PropertyName)
        //    {
        //        Control.Adapter = new NativeAndroidListViewAdapter(Forms.Context as Android.App.Activity, Element as NativeListView);
        //    }
        //}

        //void OnItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        //{
        //    ((NativeListView)Element).NotifyItemSelected(((NativeListView)Element).Items.ToList()[e.Position - 1]);
        //}
    }
}