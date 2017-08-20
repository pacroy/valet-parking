using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ValetParking.Models
{
    public interface IParkingTimeAPI
    {
        StartStopTime GetStartStopTime(int id);
    }

    public class ParkingTimeAPI : IParkingTimeAPI
    {
        public ParkingTimeAPI()
        {
        }

        public StartStopTime GetStartStopTime(int id)
        {
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://127.0.0.1:8081/api/ParkingTime/");

			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			// List data response.
            HttpResponseMessage response = client.GetAsync(id.ToString()).Result;  // Blocking call!
			if (response.IsSuccessStatusCode)
			{
				// Parse the response body
                return (ValetParking.Models.StartStopTime)response.Content.ReadAsAsync<StartStopTime>().Result;
			}
			else
			{
                return null;
			}
        }
    }
}
