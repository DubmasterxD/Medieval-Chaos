using UnityEngine;
using UnityEngine.UI;

public class UIItemsInventory : UIInventory
{
    [SerializeField] ItemTab[] itemTabs = null;

    [System.Serializable]
    class ItemTab
    {
        public UITab tab = null;
        public ItemsList.itemTypes[] itemTypes = null;
    }

    [SerializeField] UIItemSlots itemSlots = null;
    [SerializeField] Text slotsUsed = null;
    [SerializeField] UISelectedItem selectedItem = null;

    int selectedItemIndex = 0;

    Player player;
    UIInformations informations;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        informations = FindObjectOfType<UIInformations>();
    }

    public override void OpenTab()
    {
        itemSlots.CreateItemSlots();
        ActualizeSlotsUsedText();
        itemSlots.LoadItems();
        SelectItem(0);
    }

    public void ActualizeSlotsUsedText()
    {
        slotsUsed.text = "Slots used: " + player.items.GetNumberOfInventorySlotsUsed() + "/" + player.items.InventoryItemSlots;
    }

    public void OpenItemsTab(int index)
    {
        SetAllItemsMenuHighlightInactive();
        itemTabs[index].tab.ToggleHighlightActive(true);
        itemSlots.ShowSpecificItems(itemTabs[index].itemTypes);
        SelectItem(selectedItemIndex);
    }

    private void SetAllItemsMenuHighlightInactive()
    {
        foreach(ItemTab itemTab in itemTabs)
        {
            itemTab.tab.ToggleHighlightActive(false);
        }
    }

    public void SelectItem(int index)
    {
        selectedItemIndex = index;
        if (!itemSlots.CanSelect(index))
        {
            selectedItem.SelectItem(null);
        }
        else
        {
            selectedItem.SelectItem(player.items.InventoryItems[index]);
        }
    }

    public void DestroySelectedItem()
    {
        //TODO destroy item
    }

    public void EquipSelectedItem()
    {
        Item itemToEquip = player.items.InventoryItems[selectedItemIndex];
        if (itemToEquip.Level > player.stats.Level)
        {
            informations.ToggleActive(true);
            string newInfo = "Your level is too low to equip this " + itemToEquip.Type.ToString() + ".";
            informations.ChangeInformation(newInfo);
            informations.SetButtons(false);
        }
        else
        {
            player.items.EquipItem(selectedItemIndex);
            ActualizeSlotsUsedText();
            itemSlots.LoadItems();
        }
    }
}
