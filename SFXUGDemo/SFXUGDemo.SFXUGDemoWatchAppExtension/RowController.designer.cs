// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SFXUGDemo.SFXUGDemoWatchAppExtension
{
    [Register ("RowController")]
    partial class RowController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public WatchKit.WKInterfaceLabel rowLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (rowLabel != null) {
                rowLabel.Dispose ();
                rowLabel = null;
            }
        }
    }
}