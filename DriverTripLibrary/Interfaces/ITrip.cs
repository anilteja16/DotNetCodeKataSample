using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTripLibrary
{
   public interface ITrip
   {
      string DriverName { get; set; }

      DateTime StartTime { get; set; }

      DateTime EndTime { get; set; }

      double Duration { get; set; }

      double Miles { get; set; }
   }
}
