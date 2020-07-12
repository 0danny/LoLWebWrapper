using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;

namespace LoLWebWrapper.Core.Main
{
    public class NetworkRequest
    {
        public static string getString(string url)
        {
            try
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    httpRequest.ClearAllHeaders();
                    httpRequest.AllowAutoRedirect = true;
                    string response = httpRequest.Get(url).ToString();

                    return response;
                }
            }
            catch (Exception)
            {
                return "Could not access url.";
            }
        }
    }
}
