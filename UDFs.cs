using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace RentMetrics
{
    public static class UDFs
    {
        public const String _RentHomes = "Returns nearby single family home rental listings with property features. By default, returns the closest 100 data points within the past 3 months.";
        public static dynamic RentHomes(String Address, String Bedrooms, String Bathrooms, String StartDate, String EndDate, String MaxDistanceMi, String Limit, String Offset, String IncludeImages)
        {
            UriBuilder url = new UriBuilder("http://www.rentmetrics.com/api/v1/homes.json");
            var apiParam = new NameValueCollection
            {
                { "api_token", Reg.API },
                { "address", Address },
                { "bedrooms", Bedrooms },
                { "bathrooms", Bathrooms },
                { "start_date", StartDate },
                { "end_date", EndDate },
                { "max_distance_mi", MaxDistanceMi },
                { "limit", Limit },
                { "offset", Offset },
                { "include_images", IncludeImages }
            };

            url.Query = String.Join("&", apiParam.AllKeys
                .Where(key => !String.IsNullOrWhiteSpace(apiParam[key]))
                .Select(key => String.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(apiParam[key])))
            );

            return HTTP.Get(url.Uri);
        }

        public const String _RentApts = "Returns nearby apartment rental listings with property features. By default, returns the closest 100 addresses with postings within the past 3 months. Each address contains one or more configurations with latest listed price.";
        public static dynamic RentApts(String Address, String Bedrooms, String Bathrooms, String StartDate, String EndDate, String MaxDistanceMi, String Limit, String Offset, String IncludeImages)
        {
            UriBuilder url = new UriBuilder("http://www.rentmetrics.com/api/v1/apartments.json");
            var apiParam = new NameValueCollection
            {
                { "api_token", Reg.API },
                { "address", Address },
                { "bedrooms", Bedrooms },
                { "bathrooms", Bathrooms },
                { "start_date", StartDate },
                { "end_date", EndDate },
                { "max_distance_mi", MaxDistanceMi },
                { "limit", (String.IsNullOrWhiteSpace(Limit) ? "100" : Limit) },
                { "offset", Offset },
                { "include_images", IncludeImages }
            };

            url.Query = String.Join("&", apiParam.AllKeys
                .Where(key => !String.IsNullOrWhiteSpace(apiParam[key]))
                .Select(key => String.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(apiParam[key])))
            );

            return HTTP.Get(url.Uri);
        }
    }
}
