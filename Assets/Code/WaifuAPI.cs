using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Code
{
    public static class WaifuAPI
    {
        public static T TestApi<T>(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(url));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            T returnValue = JsonConvert.DeserializeObject<T>(jsonResponse);
            return returnValue;
        }
    }
}