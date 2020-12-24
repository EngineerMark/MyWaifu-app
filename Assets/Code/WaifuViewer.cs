using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class WaifuViewer : MonoBehaviour
    {
        [SerializeField]
        private Image waifuThumbnail;

        public void Set(WaifuDisplayPanel waifu)
        {
            waifuThumbnail.preserveAspect = true;
            waifuThumbnail.sprite = waifu.PanelImageField.sprite;
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
