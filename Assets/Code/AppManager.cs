using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Code
{
    public class AppManager : MonoBehaviour
    {
        [Header("Waifu Search")] [SerializeField]
        private TMP_InputField waifuSearchInput;
        
        [SerializeField]
        private GameObject waifuSearchGroup;

        [SerializeField]
        private GameObject waifuPanelPrefab;
        void Start()
        {
            
        }

        public void WaifuSearchInputFinished()
        {
            if (waifuSearchInput.text.Length > 2)
            {
                WaifuSearch(waifuSearchInput.text);
            }
        }

        private void WaifuSearch(string query)
        {
            List<WaifuResponse> response = WaifuAPI.ApiCall<List<WaifuResponse>>("https://www.mywaifu.net/api.php?type=waifu&q="+query);
            List<Waifu> waifuList = new List<Waifu>();
            foreach (WaifuResponse wr in response)
            {
                waifuList.Add(wr.GetWaifu());
            }
            BuildWaifuSearchResult(waifuList);
        }
        
        public void BuildWaifuSearchResult(List<Waifu> waifus)
        {
            //Clear out existing results
            Transform[] children = waifuSearchGroup.transform.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in children)
                if(child!=waifuSearchGroup.transform)
                    Destroy(child.gameObject);

            //Fill in results
            foreach (Waifu waifu in waifus)
            {
                //waifu.DataReceived += (s, e) => Debug.Log("Received data on " + s);
                BuildWaifuSearchCard(waifu);
            }
        }

        private GameObject BuildWaifuSearchCard(Waifu waifu)
        {
            GameObject go = Instantiate(waifuPanelPrefab);
            go.transform.SetParent(waifuSearchGroup.transform);
            go.transform.localScale = Vector3.one;
            go.name = "SearchResult_"+waifu.Name;

            WaifuDisplayPanel wdp = go.GetComponent<WaifuDisplayPanel>();
            wdp.AttachWaifu(waifu);
            wdp.SetName(waifu.Name);
            wdp.SetImage(waifu.Thumbnail);
            return go;
        }
    }
}