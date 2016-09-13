using Foundation;
using System;
using WatchKit;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace SFXUGDemo.SFXUGDemoWatchAppExtension
{
    public partial class PriceEstimateController : WKInterfaceController
    {
        public PriceEstimateController (IntPtr handle) : base (handle)
        {
        }

		string _uberType = "";

		async public override void WillActivate ()
		{
			await GetEstimates (_uberType);
		}

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			// Set defaults
			label1.SetText ("Estimating...");
			label2.SetText ("Miles:");
			label3.SetText ("Time:");

			// Grab UberType selected
			_uberType = context.ToString ();
		}

		private async Task GetEstimates (string uberType)
		{
			// Get price estimates
			var estimates = await Util.PriceEstimates (Util.NovaLat, Util.NovaLon, Util.HardRockLat, Util.HardRockLon);

			// Parse JSON
			JObject json = JObject.Parse (estimates);
			JArray prices = (JArray)json ["prices"];

			// Filter just the type we want
			var uber = prices.Where (p => p ["localized_display_name"].ToString () == uberType).FirstOrDefault ();

			int totalSeconds = Convert.ToInt32 (uber ["duration"].ToString ());
			int minutes = totalSeconds / 60;

			// Update display
			label1.SetText (string.Format ("{0} {1}", uberType, uber ["estimate"]));
			label2.SetText (string.Format ("Miles: {0}", uber ["distance"]));
			label3.SetText (string.Format ("Time: {0}min", minutes));
		}
    }
}