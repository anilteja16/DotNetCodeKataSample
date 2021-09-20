using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverTripLibrary
{
   public class Trip: ITrip
   {
      public string DriverName { get; set; }

      public DateTime StartTime { get; set; }

      public DateTime EndTime { get; set; }

      public double Duration { get; set; }

      public double Miles { get; set; }
   }
}