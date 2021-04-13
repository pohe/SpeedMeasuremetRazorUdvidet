using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Interfaces
{
    public interface ISpeedFilter
    {
        public bool Criteria(SpeedMeasurement s);

    }
}