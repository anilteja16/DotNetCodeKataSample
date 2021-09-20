using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverTripLibrary
{
   public abstract class DriverTripFactory
   {
      protected abstract IDriver GetDriverData(string driverStreamData);
      protected abstract ITrip GetTripData(string tripStreamData);

      public IDriver CreateDriverData(string driverStreamData)
      {
         return this.GetDriverData(driverStreamData);
      }

      public ITrip CreateTripData(string tripStreamData)
      {
         return this.GetTripData(tripStreamData);
      }

   }
}