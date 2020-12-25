using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class WaifuViewer : MonoBehaviour
    {
        [SerializeField] private Image waifuThumbnail;
        [SerializeField] private TMP_Text waifuNameText;
        
        public void Set(WaifuDisplayPanel waifu)
        {
            waifuThumbnail.preserveAspect = true;
            waifuThumbnail.sprite = waifu.PanelImageField.sprite;

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
