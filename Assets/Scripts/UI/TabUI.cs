using UnityEngine;
using UnityEngine.UI;

public class TabUI : MonoBehaviour
{
    [SerializeField] Image highlight = null;

    public void ToggleHighlightActive(bool isAvtive)
    {
        highlight.gameObject.SetActive(isAvtive);
    }
}
