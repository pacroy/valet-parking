using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ValetParking.Models;

namespace ValetParking.Controllers
{
    public class ValetParkingController : ApiController
    {
		public ParkingCost Get(int id)
		{
            return new ParkingCalculator().getCostById(id);
		}
    }
}
