using Foundation;
using System;
using WatchKit;
using Newtonsoft.Json.Linq;

namespace SFXUGDemo.SFXUGDemoWatchAppExtension
{
    public partial class TimeEstimateController : WKInterfaceController
    {
        public TimeEstimateController (IntPtr handle) : base (handle)
        {
        }

		JArray times = new JArray ();

		public override void WillActivate ()
		{
			LoadRows ();
		}

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			// Parse JSON
			JObject json = JObject.Parse (context.ToString ());
			times = (JArray)json ["times"];
		}

		void LoadRows ()
		{
			myTable.SetNumberOfRows ((nint)times.Count, "default");
			for (var i = 0; i < times.Count; i++) {

				// Get row instance
				var elementRow = (RowController)myTable.GetRowController (i);

				int totalSeconds = Convert.ToInt32 (times [i] ["estimate"].ToString ());
				int minutes = totalSeconds / 60;

				// Set row text
				elementRow.rowLabel.SetText (times [i] ["display_name"] + " - " + minutes + "m");
			}
		}

		public override void DidSelectRow (WKInterfaceTable table, nint rowIndex)
		{
			// Get row data
			var rowData = times [(int)rowIndex];

			// Display price estimates
			PushController ("PriceEstimateController", rowData ["display_name"].ToString ());
		}
    }
}