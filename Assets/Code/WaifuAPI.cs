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
        public static T ApiCall<T>(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(url));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            T returnValue = JsonConvert.DeserializeObject<T>(jsonResponse);
            return returnValue;
        }
    }
    
    /// <summary>
    /// Classes using this interface are created based on API results and require further assistance to finish building objects
    /// </summary>
    public interface IWaifuApiObject
    {
        /// <summary>
        /// In case of unfinished data contents, use this to fetch all data for object
        /// </summary>
        void GetData();
    }
}