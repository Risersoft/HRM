using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Risersoft.Framework.CustomRenderer;
using Risersoft.Framework.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NativeListView), typeof(NativeiOSListViewRenderer))]
namespace Risersoft.Framework.iOS.Renderer
{
    public class NativeiOSListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                //Control.Source = new NativeiOSListViewSource(e.NewElement as NativeListView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //if (e.PropertyName == NativeListView.ItemsProperty.PropertyName)
            //{
            //    Control.Source = new NativeiOSListViewSource(Element as NativeListView);
            //}
        }
    }
}