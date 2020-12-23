using System;
using UnityEngine;

namespace Assets.Code
{
    [System.Serializable]
    public class Waifu : IWaifuApiObject
    {
        public int id;
        public string name;
        public string source;
        public int source_id;
        public string thumbnail;
        public int bust;
        public int waist;
        public int hip;
        public int age;
        public string birthdate;
        public string birthplace;
        public int height;
        public int weight;
        public string bloodtype;
        public string description;
        public int approved;
        public int submitted_by;
        public int is_trap;
        public int date_added;
        public int headpats;
        public string gender;

        public bool data_exists = false;

        public event EventHandler DataReceived;

        public void GetData()
        {
            Waifu newWaifu = WaifuAPI.ApiCall<Waifu>("https://www.mywaifu.net/api.php?type=waifudata&q="+id);
            newWaifu.data_exists = true;
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