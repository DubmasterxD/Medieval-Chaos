using UnityEngine;

namespace Medieval.UI.Inventory
{
    public class Gallery : InventoryTab
    {
        [SerializeField] UI.Items items = null;

        public override void OpenTab()
        {
            items.OpenItemsTab(0);
        }
    }
}