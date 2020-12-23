using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Code
{
    public struct WaifuResponse
    {
        public int id;
        public string name;

        public Waifu GetWaifu()
        {
            Waifu newWaifu = WaifuAPI.ApiCall<Waifu>("https://www.mywaifu.net/api.php?type=waifudata&q="+id);
            return newWaifu;
        }
    }
    
    [System.Serializable]
    public class Waifu
    {
        
#region PROPERTIES
        [JsonProperty("id")]
        public int ID { get; private set; }
        
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("source")]
        public string Source { get; private set; }
        
        [JsonProperty("source_id")]
        public string SourceID { get; private set; }
        
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; private set; }
        
        [JsonProperty("bust")]
        public string Bust { get; private set; }
        
        [JsonProperty("waist")]
        public string Waist { get; private set; }
        
        [JsonProperty("hip")]
        public string Hip { get; private set; }
        
        [JsonProperty("age")]
        public string Age { get; private set; }
        
        [JsonProperty("birthdate")]
        public string Birthdate { get; private set; }
        
        [JsonProperty("birthplace")]
        public string Birthplace { get; private set; }
        
        [JsonProperty("height")]
        public string Height { get; private set; }
        
        [JsonProperty("weight")]
        public string Weight { get; private set; }
        
        [JsonProperty("bloodtype")]
        public string Bloodtype { get; private set; }
        
        [JsonProperty("description")]
        public string Description { get; private set; }
        
        [JsonProperty("approved")]
        public string Approved { get; private set; }
        
        [JsonProperty("submitted_by")]
        public string AddedBy { get; private set; }
        
        [JsonProperty("is_trap")]
        public string IsTrap { get; private set; }
        
        [JsonProperty("date_added")]
        public string DateAdded { get; private set; }
        
        [JsonProperty("headpats")]
        public string HeadpatCount { get; private set; }

        [JsonProperty("gender")]
        public string Gender { get; private set; }
#endregion
    }
}