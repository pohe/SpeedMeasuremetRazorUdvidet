using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Helpers
{
    public class FilterHelper
    {
        public static List<T> Filter<T>(List<T> liste, string criteria, Predicate<T> predicate)
        {
            if (criteria != null && criteria != "")
                liste = liste.FindAll(predicate);
            return liste;
        }


    }
}
