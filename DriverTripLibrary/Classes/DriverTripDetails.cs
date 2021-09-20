using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTripLibrary
{
   public class DriverTripDetails: IDriverTripDetails
   {
      public string Name { get; set; }

      public int Miles { get; set; }

      public int AvgSpeed { get; set; }
   }
}
