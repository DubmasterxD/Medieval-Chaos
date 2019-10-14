using UnityEngine;
using Medieval.Core;

namespace Medieval.UI
{
    public class Items : MonoBehaviour
    {
        [SerializeField] UIItemTab[] itemTabs = null;
        [SerializeField] ItemSlots itemSlots = null;

        [System.Serializable]
        public class UIItemTab
        {
            public Tab tab = null;
            public ItemType[] itemTypes = null;
        }

        public int SelectedItemIndex { get => itemSlots.selectedItemIndex; set => itemSlots.selectedItemIndex = value; }

        public void OpenItemsTab(int index)
        {
            itemSlots.CreateItemSlots();
            itemSlots.LoadItems();
            SetAllItemsMenuHighlightInactive();
            itemTabs[index].tab.ToggleHighlightActive(true);
            itemSlots.ShowSpecificItems(itemTabs[index].itemTypes);
        }

        private void SetAllItemsMenuHighlightInactive()
        {
            foreach (UIItemTab itemTab in itemTabs)
            {
                itemTab.tab.ToggleHighlightActive(false);
            }
        }

        public bool CanSelect(int index)
        {
            return itemSlots.CanSelect(index);
        }
    }
}