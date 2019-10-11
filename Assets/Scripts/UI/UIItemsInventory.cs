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

    [SerializeField] UISelectedItem selectedItem = null;
    [SerializeField] UIItemSlots itemSlots = null;
    [SerializeField] Text slotsUsed = null;

    Player player;
    UIInformations informations;
    EventsManager eventsManager;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        informations = FindObjectOfType<UIInformations>();
        eventsManager = FindObjectOfType<EventsManager>();
    }

    private void OnEnable()
    {
        eventsManager.onItemSelected += SelectItem;
        eventsManager.onConfirm += DestroySelectedItem;
    }

    private void OnDisable()
    {
        eventsManager.onItemSelected -= SelectItem;
        eventsManager.onConfirm -= DestroySelectedItem;
    }

    public override void OpenTab()
    {
        itemSlots.CreateItemSlots();
        ActualizeSlotsUsedText();
        itemSlots.LoadItems();
        OpenItemsTab(0);
    }

    public void OpenItemsTab(int index)
    {
        SetAllItemsMenuHighlightInactive();
        itemTabs[index].tab.ToggleHighlightActive(true);
        itemSlots.ShowSpecificItems(itemTabs[index].itemTypes);
        SelectItem(0);
    }

    private void ActualizeSlotsUsedText()
    {
        slotsUsed.text = "Slots used: " + player.items.GetNumberOfInventorySlotsUsed() + "/" + player.items.InventoryItemSlots;
    }

    private void SetAllItemsMenuHighlightInactive()
    {
        foreach(ItemTab itemTab in itemTabs)
        {
            itemTab.tab.ToggleHighlightActive(false);
        }
    }

    private void SelectItem(int index)
    {
        if (itemSlots.CanSelect(index))
        {
            selectedItem.SelectItem(player.items.InventoryItems[index]);
            itemSlots.selectedItemIndex = index;
        }
        else
        {
            selectedItem.SelectItem(null);
        }
    }

    public void EquipSelectedItem()
    {
        Item itemToEquip = player.items.InventoryItems[itemSlots.selectedItemIndex];
        if (CanEquip(itemToEquip))
        {
            player.items.EquipItem(itemSlots.selectedItemIndex);
            RefreshItemSlots();
        }
        else
        {
            ShowInfo("Your level is too low to equip this " + itemToEquip.Type.ToString() + ".");
        }
    }

    public void DestroySelectedItem()
    {
        player.items.DestroyItemFromInventory(itemSlots.selectedItemIndex);
        RefreshItemSlots();
    }

    private bool CanEquip(Item itemToEquip)
    {
        return itemToEquip.Level <= player.stats.Level;
    }

    private void RefreshItemSlots()
    {
        ActualizeSlotsUsedText();
        itemSlots.LoadItems();
        OpenItemsTab(0);
    }

    private void ShowInfo(string info)
    {
        informations.ToggleActive(true);
        informations.ChangeInformation(info);
        informations.SetButtons(false);
    }
}
