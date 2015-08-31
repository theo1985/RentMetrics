using System;
using System.Collections.Generic;

namespace RentMetrics
{
    public class SortOrder : IComparer<String>
    {
        static List<String> _Lib = new List<String>();

        public SortOrder()
        {
            Add("owner");
            Add("operator");
            Add("name");
            Add("distance_mi");
            Add("address");
            Add("city");
            Add("zip_code");
            Add("state");
            Add("latest_prices");
            Add("bedrooms");
            Add("full_bathrooms");
            Add("partial_bathrooms");
            Add("sq_ft");
            Add("rent");
            Add("rent_per_sq_ft");
            Add("concession_type");
            Add("concession_value");
            Add("eff_rent");
            Add("eff_rent_per_sq_ft");
            Add("rent_posted_date");
            Add("year_built");
            Add("sq_ft_lot");
            Add("latitude");
            Add("longitude");
            Add("features");
            Add("neighborhood");
        }

        // Calls CaseInsensitiveComparer.Compare with the parameters reversed. 
        int IComparer<String>.Compare(String x, String y)
        {
            return _Lib.IndexOf(x).CompareTo(_Lib.IndexOf(y));
        }

        internal static void Add(String k)
        {
            if (!_Lib.Contains(k.Trim()))
                _Lib.Add(k.Trim());
        }

        internal static Int32 IndexOf(String k)
        {
            return _Lib.IndexOf(k);
        }

        internal static String AtIndex(Int32 i)
        {
            return _Lib[i];
        }

        internal static Int32 Count { get { return _Lib.Count; } }
    }
}