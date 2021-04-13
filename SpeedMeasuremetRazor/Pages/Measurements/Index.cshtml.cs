using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class IndexModel : PageModel
    {
        public ISpeedMeasurementRepo repo { get; set; }

        public List<SpeedMeasurement> MeasurementToList { get; set; }

        
        [BindProperty(SupportsGet = true)]
        public string OffenseString { get; set; }
        public IndexModel(ISpeedMeasurementRepo repositoryMeasurementRepo)
        {
            repo = repositoryMeasurementRepo;
            MeasurementToList =repo.AllSpeedMeasurements;
            OffenseString = "All";
        }
        public void OnGet()
        {
            SetMeasurementsToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            SetMeasurementsToList();
            repo.DeleteSpeedMeasurement(id);
            return Page();
        }

        private void SetMeasurementsToList()
        {
            if (OffenseString == "All")
                MeasurementToList = repo.GetAllSpeedMeasurements();
            else
            {
                Offense offense = Enum.Parse<Models.Offense>(OffenseString);
                switch (offense)
                {
                    case Offense.ConditionalRevocation:
                        MeasurementToList = repo.ConditionalRevocationMeasurements;
                        break;
                    case Offense.CutInLicense:
                        MeasurementToList = repo.CutInLicenseMeasurements;
                        break;
                    case Offense.OverspeedLimit:
                        MeasurementToList = repo.OverSpeedLimitMeasurements;
                        break;
                    default:
                        MeasurementToList = repo.GetAllSpeedMeasurements();
                        break;
                }
            }
        }
    }
}
