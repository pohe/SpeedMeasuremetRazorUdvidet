using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class LocationsSortByZone : IComparer<Location>
    {
        public int Compare(Location x, Location y)
        {
            if (x.Zone > y.Zone)
            {
                return 1;
            }

            if (x.Zone < y.Zone)
            {
                return -1;
            }
            return 0;
        }
    }
}
