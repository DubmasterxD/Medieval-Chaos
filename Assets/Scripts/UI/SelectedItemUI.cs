using UnityEngine;
using UnityEngine.UI;

public class SelectedItemUI : MonoBehaviour
{
    [SerializeField] Image selectedItemImage = null;
    [SerializeField] Text selectedItemName = null;
    [SerializeField] Text selectedItemDescription = null;

    public void SelectItem(Item item)
    {
        if (item == null)
        {
            selectedItemImage.sprite = null;
            selectedItemName.text = "None";
            selectedItemDescription.text = "No item selected";
        }
        else
        {
            selectedItemImage.sprite = item.Image;
            selectedItemName.text = item.Rarity + " " + item.Name;
            selectedItemDescription.text = item.GetStatsDescription();
        }
    }
}
