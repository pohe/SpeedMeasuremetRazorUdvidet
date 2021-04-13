using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using SpeedMeasuremetRazor.Exceptions;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class SpeedMeasurementRepo : ISpeedMeasurementRepo
    {
        private  List<SpeedMeasurement> _allMeasurements;

        public List<SpeedMeasurement> AllSpeedMeasurements
        {
            get { return _allMeasurements; }
            private set { _allMeasurements = value; }
        }
        
        public List<SpeedMeasurement> OverSpeedLimitMeasurements
        {
            get { return FilterSpeedMeasurements(new OverSpeedLimitFilter()); }
        }

        public List<SpeedMeasurement> CutInLicenseMeasurements
        {
            get { return FilterSpeedMeasurements(new CutInLicenseFilter()); }
        }

        public List<SpeedMeasurement> ConditionalRevocationMeasurements
        {
            get { return FilterSpeedMeasurements(new ConditionalRevocationFilter()); }
        }

        public SpeedMeasurementRepo()
        {
            _allMeasurements = MockData.Measurements;
        }

        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            return _allMeasurements;
        }
        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            if (speed > 0 && speed <= 300)
                _allMeasurements.Add(new SpeedMeasurement(speed,location, imageName));
            else
            {
                throw new CalibrationException($"Incorrect speed {speed} km/t - something went wrong!");
            }
        }

        public List<SpeedMeasurement> FilterSpeedMeasurements(ISpeedFilter filter)
        {
            List<SpeedMeasurement> filtered = new List<SpeedMeasurement>(); 
            foreach (SpeedMeasurement s in GetAllSpeedMeasurements())
            {
                if (filter.Criteria(s))
                {
                    filtered.Add(s);
                }
            }
            return filtered; 
        }

        public double AvarageSpeed()
        {
            if (_allMeasurements.Count == 0)
                return 0.0;
            int total = 0;
            foreach (SpeedMeasurement speedMeasurement in _allMeasurements)
            {
                total = total + speedMeasurement.Speed;
            }
            return ((double)total) / _allMeasurements.Count;
        }

        public override string ToString()
        {
            string speedMeasurements = "";
            foreach (SpeedMeasurement m in _allMeasurements)
            {
                speedMeasurements += m.ToString() + "\n\t";
            }
            return $"SpeedMeasurements: \n\t{speedMeasurements}";
        }

        public int NoOfOverSpeedLimit()
        {
            int no = 0;
            foreach (SpeedMeasurement speedMeasurement in _allMeasurements)
            {
                if (speedMeasurement.Speed > speedMeasurement.Location.SpeedLimit)
                    no++;
            }
            return no;
        }

        public int NoOfCutInLicense()
        {
            int no = 0;
            for (int i = 0; i < _allMeasurements.Count; i++)
            {
                if (_allMeasurements[i].Speed > (_allMeasurements[i].Location.SpeedLimit * 1.30))
                {
                    no++;
                }
            }
            return no;
        }

        public int NoOfCutInLicenseForeach()
        {
            int no = 0;
            foreach (SpeedMeasurement speedMeasurement in _allMeasurements)
            {
                if (speedMeasurement.Speed > (speedMeasurement.Location.SpeedLimit * 1.30))
                {
                    no++;
                }
            }
            return no;
        }

        public int NoOfConditionalRevocation()
        {
            int no = 0;
            foreach (SpeedMeasurement speedMeasurement in _allMeasurements)
            {
                if (speedMeasurement.Location.Zone == Zone.Motorvej && speedMeasurement.Location.SpeedLimit == 130 && speedMeasurement.Speed > (speedMeasurement.Location.SpeedLimit * 1.30))
                {
                    no++;
                }
                else if (speedMeasurement.Speed > (speedMeasurement.Location.SpeedLimit * 1.60))
                {
                    no++;
                }
            }
            return no;
        }

        public void DeleteSpeedMeasurement(int id)
        {
            SpeedMeasurement speedMeasurementToDelete = GetSpeedMeasurement(id);
            if (speedMeasurementToDelete != null)
                _allMeasurements.Remove(speedMeasurementToDelete);
        }
        public SpeedMeasurement GetSpeedMeasurement(int id)
        {
            foreach (var m in _allMeasurements)
            {
                if (m.Id == id)
                {
                    return m;
                }
            }
            return null;
        }
    }
}
