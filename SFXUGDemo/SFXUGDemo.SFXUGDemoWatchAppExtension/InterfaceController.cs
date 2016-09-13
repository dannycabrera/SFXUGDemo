using System;

using WatchKit;
using Foundation;

namespace SFXUGDemo.SFXUGDemoWatchAppExtension
{
	public partial class InterfaceController : WKInterfaceController
	{
		protected InterfaceController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			// Configure interface objects here.
			Console.WriteLine ("{0} awake with context", this);
		}

		public override void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);
		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
		}

		async partial void OnButtonPress ()
		{
			// Get time estimates
			var json = await Util.TimeEstimates (Util.NovaLat, Util.NovaLon);

			// Display time estimates
			PushController ("TimeEstimateController", json);
		}
	}
}
