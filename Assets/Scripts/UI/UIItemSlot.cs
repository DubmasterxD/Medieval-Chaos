using UnityEngine;

public class UIItemSlot : MonoBehaviour
{
    public int index = 0;

    UIItemsInventory itemsInventory;

    private void Awake()
    {
        itemsInventory = FindObjectOfType<UIItemsInventory>();
    }

    public void SelectItem()
    {
        itemsInventory.SelectItem(index);
    }
}
