using UnityEngine;
using UnityEngine.UI;

namespace Medieval.UI
{
    public class Tab : MonoBehaviour
    {
        [SerializeField] Image highlight = null;

        public void ToggleHighlightActive(bool isAvtive)
        {
            highlight.gameObject.SetActive(isAvtive);
        }
    }
}