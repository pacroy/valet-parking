using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ValetParking.Models;

namespace ParkingTime.Controllers
{
    public class ParkingTimeController : ApiController
    {
        public StartStopTime Get(int id)
		{
			switch (id)
			{
				case 1000:
                    return new StartStopTime
                    {
                        start = new DateTime(2017, 08, 20, 12, 0, 0),
                        stop = new DateTime(2017, 08, 20, 12, 15, 0),
                    };
				case 1001:
					return new StartStopTime
					{
						start = new DateTime(2017, 08, 20, 12, 30, 0),
						stop = new DateTime(2017, 08, 20, 13, 30, 0),
					};
				case 1002:
					return new StartStopTime
					{
						start = new DateTime(2017, 08, 20, 12, 0, 0),
						stop = new DateTime(2017, 08, 20, 14, 59, 0),
					};
				default:
					var response = new HttpResponseMessage(HttpStatusCode.NotFound)
					{ Content = new StringContent("Id not found") };
					throw new HttpResponseException(response);
			}		}
    }
}
