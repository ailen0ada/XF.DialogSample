using System;
using AppKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using DialogSample;
using DialogSample.MacOS;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace DialogSample.MacOS
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BezelStyle = NSBezelStyle.Rounded;
                Control.KeyEquivalent = "\r";
                Control.Font = NSFont.SystemFontOfSize(NSFont.SystemFontSize);
            }
        }
    }
}
