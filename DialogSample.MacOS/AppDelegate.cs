using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using System;
using System.Diagnostics;

namespace DialogSample.MacOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow mainWindow;

        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 400, 600);
            //var rect = NSWindow.FrameRectFor(NSScreen.MainScreen.Frame, style);
            mainWindow = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            mainWindow.Title = "DialogSample.MacOS";
        }

        public override NSWindow MainWindow => mainWindow;

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();

            LoadApplication(new App());

            MessagingCenter.Subscribe<DialogSamplePage, Payload>(this, "show_message", (page, payload) =>
            {
                this.InvokeOnMainThread(() =>
                {
                    using (var alert = new NSAlert())
                    {
                        alert.MessageText = payload.Title;
                        alert.InformativeText = payload.Message;
                        alert.AddButton("Dismiss");
                        alert.RunSheetModal(NSApplication.SharedApplication.MainWindow);
                    }
                });
            });

            base.DidFinishLaunching(notification);
        }

        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender) => true;
    }
}
