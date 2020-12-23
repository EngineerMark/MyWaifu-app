using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class AppManager : MonoBehaviour
    {
        public List<Waifu> testList;
        
        void Start()
        {
            
            List<Waifu> test = WaifuAPI.TestApi<List<Waifu>>("https://www.mywaifu.net/api.php?type=waifu&q=nakano");
            testList = test;
        }

        void Update()
        {
        
        }
    }
}
