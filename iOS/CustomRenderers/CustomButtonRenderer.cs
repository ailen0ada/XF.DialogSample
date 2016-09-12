using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using DialogSample;
using DialogSample.iOS;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace DialogSample.iOS
{
    public class CustomButtonRenderer : ButtonRenderer
    {
    }
}
