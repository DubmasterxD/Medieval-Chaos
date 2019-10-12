using UnityEngine;
using UnityEngine.UI;

public class UIItemsInventory : UIInventory
{
    [SerializeField] UISelectedItem selectedItem = null;
    [SerializeField] UIItems itemsUI = null;
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
        itemsUI.OpenItemsTab(0);
        ActualizeSlotsUsedText();
        SelectItem(0);
    }

    private void ActualizeSlotsUsedText()
    {
        slotsUsed.text = "Slots used: " + player.items.GetNumberOfInventorySlotsUsed() + "/" + player.items.InventoryItemSlots;
    }

    private void SelectItem(int index)
    {
        if (itemsUI.CanSelect(index))
        {
            selectedItem.SelectItem(player.items.InventoryItems[index]);
            itemsUI.SelectedItemIndex = index;
        }
        else
        {
            selectedItem.SelectItem(null);
        }
    }

    public void EquipSelectedItem()
    {
        Item itemToEquip = player.items.InventoryItems[itemsUI.SelectedItemIndex];
        if (CanEquip(itemToEquip))
        {
            player.items.EquipItem(itemsUI.SelectedItemIndex);
            RefreshItemSlots();
        }
        else
        {
            ShowInfo("Your level is too low to equip this " + itemToEquip.Type.ToString() + ".");
        }
    }

    public void DestroySelectedItem()
    {
        player.items.DestroyItemFromInventory(itemsUI.SelectedItemIndex);
        RefreshItemSlots();
    }

    private bool CanEquip(Item itemToEquip)
    {
        return itemToEquip.Level <= player.stats.Level;
    }

    private void RefreshItemSlots()
    {
        ActualizeSlotsUsedText();
        itemsUI.OpenItemsTab(0);
    }

    private void ShowInfo(string info)
    {
        informations.ToggleActive(true);
        informations.ChangeInformation(info);
        informations.SetButtons(false);
    }
}
