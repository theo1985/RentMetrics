using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace RentMetrics
{
    public static class HTTP
    {
        public static dynamic Get(Uri url)
        {
            try
            {
                // Query API
                String oResponse = null;
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    oResponse = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                }

                // Deserialize Data
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
                return serializer.Deserialize(oResponse, typeof(object));
            }
            catch (WebException e)
            {
                if (e is WebException && ((WebException)e).Status == WebExceptionStatus.ProtocolError)
                {
                    using (HttpWebResponse response = (HttpWebResponse)e.Response)
                    {
                        String oResponse = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                        MessageBox.Show(oResponse);
                    }
                }
            }

            return null;
        }
    }
}
