using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Assets.Code
{
    public class WaifuDisplayPanel : MonoBehaviour
    {
        [SerializeField]
        private Image panelImageField;
    
        [SerializeField]
        private TMP_Text panelNameField;

        [SerializeField]
        private Waifu attachedWaifu;
    
        public void SetImage(string url)
        {
            panelImageField.preserveAspect = true;
            StartCoroutine(InternalSetImage(url));
        }

        private IEnumerator InternalSetImage(string url)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            panelImageField.sprite = SpriteFromTexture2D(((DownloadHandlerTexture) www.downloadHandler).texture);
        }

        public void SetName(string text)
        {
            panelNameField.text = text;
        }

        public void AttachWaifu(Waifu waifu)
        {
            this.attachedWaifu = waifu;
        }
        
        static Sprite SpriteFromTexture2D(Texture2D texture) {

            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }

    }
}
