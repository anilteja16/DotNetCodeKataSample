using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverTripLibrary;

namespace DriverTripLibrary
{
   public sealed class DriverTripReport
   {
      private const string DRIVER_COMMAND = "Driver";
      private const string TRIP_COMMAND = "Trip";

      private static DriverTripReport instance = null;
      private static readonly object Instancelock = new object();

      public static DriverTripReport GetInstance
      {
         get
         {
            if (instance == null)
            {
               lock (Instancelock)
               {
                  if (instance == null)
                  {
                     instance = new DriverTripReport();
                  }
               }
            }
            return instance;
         }
      }

      public IEnumerable<DriverTripDetails> ProcessInputStream(string inputStreamData)
      {
         var strArray = inputStreamData.Replace("\\n", String.Empty).Replace("\\r", "$").Split('$').ToList<string>();

         var output = new List<IDriver>();
         var output1 = new List<DriverTripDetails>();

         foreach (var text in strArray)
         {
            if (text.StartsWith(DRIVER_COMMAND))
            {
               if (!output.Exists(d => d.Name.Equals(DRIVER_COMMAND)))
               {
                  output.Add(new DriverFactory().CreateDriverData(text));
               }
            }
            else if (text.StartsWith(TRIP_COMMAND))
            {
               var tripObj = new DriverFactory().CreateTripData(text);

               output.Find(d => d.Name.Equals(tripObj.DriverName)).Trips.Add((Trip)tripObj);
            }
         }

         foreach (var driver in output)
         {
            if (driver.Trips.Count > 0)
            {
               driver.CalculateTripData(driver);
            }

            output1.Add(new DriverTripDetails
            {
               Name = driver.Name,
               Miles = (int)Math.Round(driver.Miles),
               AvgSpeed = (int)Math.Round(driver.AvgSpeed)
            });
         }

         return output1.OrderByDescending(d => d.Miles).ToList();
      }
   }
}