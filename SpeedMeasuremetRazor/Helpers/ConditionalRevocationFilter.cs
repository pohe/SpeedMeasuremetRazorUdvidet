using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class ConditionalRevocationFilter:ISpeedFilter
    {
        public bool Criteria(SpeedMeasurement s)
        {
            if (s.Location.Zone == Zone.Motorvej && s.Location.SpeedLimit == 130 && s.Speed > (s.Location.SpeedLimit * 1.30))
            {
                return true;
            }
            else if (s.Speed > (s.Location.SpeedLimit * 1.60))
            {
                return true; 
            }
            return false; 
        }
    }
}
