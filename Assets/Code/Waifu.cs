using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Code
{
    [System.Serializable]
    public class Waifu : IWaifuApiObject
    {
        
#region PROPERTIES
        [JsonProperty("id")]
        public int ID { get; private set; }
        
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("source")]
        public string Source { get; private set; }
        
        [JsonProperty("source_id")]
        public int SourceID { get; private set; }
        
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; private set; }
        
        [JsonProperty("bust")]
        public int Bust { get; private set; }
        
        [JsonProperty("waist")]
        public int Waist { get; private set; }
        
        [JsonProperty("hip")]
        public int Hip { get; private set; }
        
        [JsonProperty("age")]
        public int Age { get; private set; }
        
        [JsonProperty("birthdate")]
        public string Birthdate { get; private set; }
        
        [JsonProperty("birthplace")]
        public string Birthplace { get; private set; }
        
        [JsonProperty("height")]
        public int Height { get; private set; }
        
        [JsonProperty("weight")]
        public int Weight { get; private set; }
        
        [JsonProperty("bloodtype")]
        public string Bloodtype { get; private set; }
        
        [JsonProperty("description")]
        public string Description { get; private set; }
        
        [JsonProperty("approved")]
        public bool Approved { get; private set; }
        
        [JsonProperty("submitted_by")]
        public int AddedBy { get; private set; }
        
        [JsonProperty("is_trap")]
        public bool IsTrap { get; private set; }
        
        [JsonProperty("date_added")]
        public int DateAdded { get; private set; }
        
        [JsonProperty("headpats")]
        public int HeadpatCount { get; private set; }

        [JsonProperty("gender")]
        public string Gender { get; private set; }
#endregion

        public bool DataExists { get; set; } = false;

        public event EventHandler DataReceived;

        public void GetData()
        {
            Waifu newWaifu = WaifuAPI.ApiCall<Waifu>("https://www.mywaifu.net/api.php?type=waifudata&q="+ID);
            newWaifu.DataExists = true;
            //TODO: Apply all new data to existing object in a graceful manner, we want it to be expandable without too much hassle
        }

        //TODO: Events for data management
        public void OnDataReceived(EventArgs e)
        {
            EventHandler handler = DataReceived;
            handler?.Invoke(this, e);
        }
    }
}