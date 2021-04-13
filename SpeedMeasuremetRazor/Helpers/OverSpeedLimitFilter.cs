using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class OverSpeedLimitFilter:ISpeedFilter
    {
        public bool Criteria(SpeedMeasurement s)
        {
            if (s.Speed > s.Location.SpeedLimit)
                return true;
            else
            {
                return false;
            }
        }
    }
}
