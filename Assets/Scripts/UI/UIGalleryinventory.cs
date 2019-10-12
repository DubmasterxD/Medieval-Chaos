using UnityEngine;

public class UIGalleryinventory : UIInventory
{
    [SerializeField] UIItems itemsUI = null;

    public override void OpenTab()
    {
        itemsUI.OpenItemsTab(0);
    }
}
