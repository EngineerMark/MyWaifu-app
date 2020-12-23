using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class AppManager : MonoBehaviour
    {
        public List<Waifu> testList;

        void Start()
        {
            List<Waifu> test = WaifuAPI.ApiCall<List<Waifu>>("https://www.mywaifu.net/api.php?type=waifu&q=nakano");
            testList = test;

            foreach (Waifu waifu in test)
            {
                waifu.DataReceived += (s, e) => Debug.Log("Received data on " + s);
            }
            
            test[1].GetData();
        }

        void Update()
        {
        }
    }
}