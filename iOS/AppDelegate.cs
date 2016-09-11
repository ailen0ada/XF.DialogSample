using System;
using System.Collections.Generic;
using System.Linq;
using DialogSample;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;

namespace DialogSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Forms.Init();

            LoadApplication(new DialogSample.App());

            MessagingCenter.Subscribe<DialogSamplePage, Payload>(this, "show_message", (page, payload) =>
            {
                this.InvokeOnMainThread(() =>
                {
                    using (var alert = UIAlertController.Create(payload.Title, payload.Message, UIAlertControllerStyle.Alert))
                    {
                        alert.AddAction(UIAlertAction.Create("Dismiss", UIAlertActionStyle.Default, null));
                        UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
                    }
                });
            });

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
