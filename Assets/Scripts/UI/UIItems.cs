
using UnityEngine;

public class UIItems : MonoBehaviour
{
    [SerializeField] UIItemTab[] itemTabs = null;
    [SerializeField] UIItemSlots itemSlots = null;

    [System.Serializable]
    public class UIItemTab
    {
        public UITab tab = null;
        public ItemsList.itemTypes[] itemTypes = null;
    }

    public int SelectedItemIndex { get => itemSlots.selectedItemIndex ; set => itemSlots.selectedItemIndex = value; }

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
