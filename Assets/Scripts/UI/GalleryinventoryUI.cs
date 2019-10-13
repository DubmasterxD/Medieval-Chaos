using UnityEngine;

public class GalleryinventoryUI : InventoryUI
{
    [SerializeField] ItemsUI itemsUI = null;

    public override void OpenTab()
    {
        itemsUI.OpenItemsTab(0);
    }
}
