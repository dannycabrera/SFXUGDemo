using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SFXUGDemo.SFXUGDemoWatchAppExtension
{
	public static class Util
	{
		public static string Token { get { return "<UBER SERVER TOKEN>"; } }

		public static double NovaLat { get { return 26.08101311; } }
		public static double NovaLon { get { return -80.2425289; } }

		public static double HardRockLat { get { return 25.955543; } }
		public static double HardRockLon { get { return -80.238336; } }

		public static async Task<string> TimeEstimates (double latitude, double longitude)
		{
			using (HttpClient client = new HttpClient ()) {
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Token", Util.Token);
				var url = string.Format ("https://api.uber.com/v1/estimates/time?start_latitude={0}&start_longitude={1}", latitude, longitude);
				var json = await client.GetStringAsync (url);

				return json;
			}
		}

		public static async Task<string> PriceEstimates (double startLat, double startLon, double endLat, double endLon)
		{
			using (HttpClient client = new HttpClient ()) {
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Token", Util.Token);
				var url = string.Format ("https://api.uber.com/v1/estimates/price?start_latitude={0}&start_longitude={1}&end_latitude={2}&end_longitude={3}"
											, startLat, startLon, endLat, endLon);
				var json = await client.GetStringAsync (url);

				return json;
			}
		}
	}
}
