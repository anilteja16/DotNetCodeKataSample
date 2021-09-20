using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DriverTripLibrary
{
   public class DriverFactory : DriverTripFactory
   {
      private const string DRIVER_COMMAND = "Driver";
      protected override IDriver GetDriverData(string driverStreamData)
      {
         return new Driver
         {
            Name = driverStreamData.Substring(DRIVER_COMMAND.Length + 1).Trim(),
            Trips = new List<Trip>()
         };
      }
      
      protected override ITrip GetTripData(string tripStreamData)
      {
         var tripArray = tripStreamData.Split(' ');

         var tripObj = new Trip
         {
            DriverName = tripArray[1],
            StartTime = DateTime.Parse(tripArray[2]),
            EndTime = DateTime.Parse(tripArray[3]),
            Miles = Double.Parse(tripArray[4])
         };
         tripObj.Duration = (tripObj.EndTime - tripObj.StartTime).TotalHours;

         return tripObj;
      }
   }
}
