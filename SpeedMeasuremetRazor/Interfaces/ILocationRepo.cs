using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Interfaces
{
    public interface ILocationRepo
    {
        List<Location> GetAllLocations();
        Task<List<Location>> GetAllLocationsAsync();
        void AddLocation(Location location);
        Task AddLocationAsync(Location location);
        void UpdateLocation(Location location);

        Location GetLocation(int id);
        void DeleteLocation(int id);
    }
}
