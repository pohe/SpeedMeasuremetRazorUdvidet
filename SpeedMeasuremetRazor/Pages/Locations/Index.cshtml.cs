using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class IndexModel : PageModel
    {
        public ILocationRepo locationrepo { get; set; }

        //[BindProperty]
        public List<Location> Locations { get; set; }

        [BindProperty]
        public LocationSort LocationSortCriteria { get; set; }

        [BindProperty]
        public string Criteria { get; set; }
        public IndexModel(ILocationRepo repositoryLocation)
        {
            locationrepo = repositoryLocation;
            //Locations = locationrepo.GetAllLocations();
            Locations = locationrepo.GetAllLocationsAsync().Result;
            Locations.Sort();
        }
        public void OnGet()
        {
            //Locations = locationrepo.GetAllLocations();
            Locations = locationrepo.GetAllLocationsAsync().Result;
        }
        
        public void OnPostFilterSort()
        {
            Filter();
            Sort();
        }

        
        private void Filter()
        {
            Locations = FilterHelper.Filter<Location>(Locations, Criteria, (l) => l.Address.Contains(Criteria));
        }

        

        private void Sort()
        {
            switch (LocationSortCriteria)
            {
                case LocationSort.Address:
                    Locations.Sort();
                    break;
                case LocationSort.SpeedLimit:
                    Locations.Sort(new LocationsSortBySpeed());
                    break;
                case LocationSort.Zone:
                    Locations.Sort(new LocationsSortByZone());
                    break;
                default:
                    Locations.Sort();
                    break;
            }
        }
    }
}
