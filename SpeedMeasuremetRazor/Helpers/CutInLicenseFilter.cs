using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class CutInLicenseFilter:ISpeedFilter
    {
        public bool Criteria(SpeedMeasurement s)
        {
            if (s.Speed > (s.Location.SpeedLimit * 1.30) && !new ConditionalRevocationFilter().Criteria(s))
            {
                return true;
            }
            return false; 
        }
    }
}
