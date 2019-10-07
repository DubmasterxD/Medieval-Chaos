using UnityEngine;
using UnityEngine.UI;

public class UITab : MonoBehaviour
{
    [SerializeField] Image highlight = null;

    public void ToggleHighlightActive(bool isAvtive)
    {
        highlight.gameObject.SetActive(isAvtive);
    }
}
