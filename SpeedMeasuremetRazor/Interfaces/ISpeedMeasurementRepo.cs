using System.Collections.Generic;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Interfaces
{
    public interface ISpeedMeasurementRepo
    {
        
        public List<SpeedMeasurement> AllSpeedMeasurements { get; }
        
        public List<SpeedMeasurement> OverSpeedLimitMeasurements { get; }

        public List<SpeedMeasurement> CutInLicenseMeasurements { get; }

        public List<SpeedMeasurement> ConditionalRevocationMeasurements { get; }
        List<SpeedMeasurement> GetAllSpeedMeasurements();
        void AddSpeedMeasurement(int speed, Location location, string imageName);
        double AvarageSpeed();
        int NoOfOverSpeedLimit();
        int NoOfCutInLicense();
        int NoOfCutInLicenseForeach();
        int NoOfConditionalRevocation();
        void DeleteSpeedMeasurement(int id);
    }
}