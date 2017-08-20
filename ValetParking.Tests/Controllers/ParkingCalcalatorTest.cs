using NUnit.Framework;
using System;
using ValetParking.Models;

namespace ValetParking.Tests.Controllers
{
	public class ParkingTimeAPIMock : IParkingTimeAPI
	{
        private DateTime start;
        private DateTime stop;

        public ParkingTimeAPIMock(DateTime start, DateTime stop)
		{
            this.start = start;
            this.stop = stop;
		}

		public StartStopTime GetStartStopTime(int id)
		{
			return new StartStopTime
			{
				start = this.start,
				stop = this.stop,
			};
		}
	}

    [TestFixture]
    public class ParkingCalculator_GetCostByIdTest
    {
		private ParkingCalculator pcalc;

		[SetUp]
		public void setup()
		{
			pcalc = new ParkingCalculator();
		}

        [Test]
        public void id_1_cost_0()
        {
            pcalc.ParkingTimeAPIInstance = new ParkingTimeAPIMock(
                new DateTime(2017,8,25,10,0,0),
                new DateTime(2017,8,25,10,15,0)
            );
            Assert.AreEqual(0, pcalc.getCostById(1).cost);
        }

		[Test]
		public void id_2_cost_12()
		{
			pcalc.ParkingTimeAPIInstance = new ParkingTimeAPIMock(
				new DateTime(2017, 8, 25, 10, 0, 0),
				new DateTime(2017, 8, 25, 14, 0, 0)
			);
            Assert.AreEqual(12, pcalc.getCostById(2).cost);
		}
    }

    [TestFixture]
    public class ParkingCalculator_GetCostById_IntegrationTest
    {
		private ParkingCalculator pcalc;

		[SetUp]
		public void setup()
		{
			pcalc = new ParkingCalculator();
		}

		[Test]
		public void id_1000_cost_0()
		{
			Assert.AreEqual(0, pcalc.getCostById(1000).cost);
		}

		[Test]
		public void id_1001_cost_12()
		{
            Assert.AreEqual(0, pcalc.getCostById(1001).cost);
		}

		[Test]
		public void id_1002_cost_12()
		{
            Assert.AreEqual(0, pcalc.getCostById(1002).cost);
		}
    }
}
