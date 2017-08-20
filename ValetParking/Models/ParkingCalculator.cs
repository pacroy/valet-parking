using System;
namespace ValetParking.Models
{
    public class ParkingCalculator
    {
        private IParkingTimeAPI ptAPI;

        public IParkingTimeAPI ParkingTimeAPIInstance
        {
            get
            {
                if (ptAPI is null)
                {
                    ptAPI = new ParkingTimeAPI();
                }
                return ptAPI;
            }
            set
            {
                ptAPI = value;
            }
        }

        public ParkingCalculator()
        {
        }

        public ParkingCost getCostById(int id)
        {
            StartStopTime startStopTime = ParkingTimeAPIInstance.GetStartStopTime(id);
            if ((startStopTime.stop - startStopTime.start).TotalMinutes > 15)
			{
                return new ParkingCost{
                    parkingTime = startStopTime,
                    cost = 12
                };
			}
			else
			{
				return new ParkingCost
				{
					parkingTime = startStopTime,
					cost = 0
				};
			}
        }
    }
}
