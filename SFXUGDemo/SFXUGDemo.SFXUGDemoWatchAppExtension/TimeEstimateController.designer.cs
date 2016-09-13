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
    [Register ("TimeEstimateController")]
    partial class TimeEstimateController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceTable myTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (myTable != null) {
                myTable.Dispose ();
                myTable = null;
            }
        }
    }
}