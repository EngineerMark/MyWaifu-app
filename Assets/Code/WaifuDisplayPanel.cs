using System;
using System.Collections;
using System.IO;
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

        private Coroutine textureLoader;
    
        public void SetImage(string url)
        {
            panelImageField.preserveAspect = true;
            textureLoader = StartCoroutine(InternalSetImage(url));
        }

        private IEnumerator InternalSetImage(string url)
        {
            byte[] urlBytes = System.Text.Encoding.UTF8.GetBytes(attachedWaifu.ID+attachedWaifu.Name);
            string path = Path.Combine(Application.persistentDataPath, "cache", "textures");
            string file = Path.Combine(path, BitConverter.ToString(urlBytes).Replace("-", "")+".cache");
            Directory.CreateDirectory(path);
            Debug.Log(file);

            //TODO: Check if file is cached and its age
            Texture2D result = new Texture2D(2,2);
            bool useCache = File.Exists(file) && ((DateTime.Now - File.GetCreationTime(file)).Hours<2);

            if (!useCache)
            {
                UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
                yield return www.SendWebRequest();
                result = ((DownloadHandlerTexture) www.downloadHandler).texture;
                result.Apply(true);

                if (File.Exists(file))
                    File.Delete(file);

                using (FileStream fs = File.Create(file))
                {
                    byte[] texData = www.downloadHandler.data;
                    fs.Write(texData, 0, texData.Length);
                }
            }
            else
            {
                var fileData = File.ReadAllBytes(file);
                result.LoadImage(fileData);
                result.Apply(true);
            }
            
            Sprite sprite = SpriteFromTexture2D(result);
            panelImageField.sprite = sprite;
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
