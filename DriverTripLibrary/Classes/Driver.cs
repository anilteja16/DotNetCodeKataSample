using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverTripLibrary
{
   public class Driver : IDriver
   {
      public string Name { get; set; }

      public double Miles { get; set; }

      public double AvgSpeed { get; set; }

      public List<Trip> Trips { get; set; }

      public void CalculateTripData(IDriver driver)
      {
         if (driver.Trips.Count.Equals(1))
         {
            driver.Miles = driver.Trips[0].Miles;
            var avgSpeed = driver.Trips[0].Miles / driver.Trips[0].Duration;
            driver.AvgSpeed = (avgSpeed > 5 && avgSpeed < 100) ? avgSpeed : 0;
         }
         else if (driver.Trips.Count > 1)
         {
            double avgSpeed = 0;
            double duration = 0;
            foreach (var trip in driver.Trips)
            {
               driver.Miles += trip.Miles;
               duration += trip.Duration;
            }

            avgSpeed = driver.Miles / duration;

            driver.AvgSpeed += (avgSpeed > 5 && avgSpeed < 100) ? avgSpeed : 0;
         }
      }
   }
}
