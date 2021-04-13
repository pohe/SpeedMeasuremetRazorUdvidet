using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Models
{
    public class Location: IComparable<Location>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public Zone Zone { get; set; }
        [Required]
        public int SpeedLimit { get; set; }

        public Location()
        {
            
        }
        public Location(int id, string address, Zone zone, int speedLimit)
        {
            Id = id;
            Address = address;
            Zone = zone;
            SpeedLimit = speedLimit;
        }

        public int CompareTo(Location other)
        {
            if (Address.CompareTo(other.Address)>0)
            {
                return 1;
            }
            if (Address.CompareTo(other.Address) < 0)
            {
                return -1;
            }
            return 0;
            //alternativt bare 
            //return Address.CompareTo(other.Address);
        }

        public override bool Equals(object? obj)
        {
            Location loc=null;
            if (obj is Location)
            {
                loc = (Location)obj;
                if (this.Id == loc.Id)
                    return true;
            }
            return false;
        }
    }
}
