using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTripLibrary
{
   public interface IDriver
   {
      string Name { get; set; }

      double Miles { get; set; }

      double AvgSpeed { get; set; }

      List<Trip> Trips { get; set; }

      void CalculateTripData(IDriver driver);
   }
}