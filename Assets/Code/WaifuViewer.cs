using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class WaifuViewer : MonoBehaviour
    {
        [SerializeField] private Image waifuThumbnail;
        [SerializeField] private TMP_Text waifuNameText;
        [SerializeField] private AspectRatioFitter arf;
        
        public void Set(WaifuDisplayPanel waifu)
        {
            waifuThumbnail.preserveAspect = true;
            waifuThumbnail.sprite = waifu.PanelImageField.sprite;
            
            if (waifu.Texture.width > waifu.Texture.height)
                arf.aspectRatio = 100f;
            else
                arf.aspectRatio = 0.001f;

            waifuNameText.text = waifu.AttachedWaifu.Name;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
