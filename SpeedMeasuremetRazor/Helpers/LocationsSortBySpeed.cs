using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class LocationsSortBySpeed : IComparer<Location>
    {
        public int Compare(Location x, Location y)
        {
            if (x.SpeedLimit > y.SpeedLimit)
            {
                return 1;
            }

            if (x.SpeedLimit < y.SpeedLimit)
            {
                return -1;
            }
            return 0;
        }
    }
}
