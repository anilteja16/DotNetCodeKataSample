using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTripLibrary
{
   public interface IDriverTripDetails
   {
      string Name { get; set; }

      int Miles { get; set; }

      int AvgSpeed { get; set; }
   }
}
