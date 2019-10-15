using UnityEngine;
using UnityEngine.UI;
using Medieval.Core;
using Medieval.Player;

namespace Medieval.UI.Inventory
{
    public class Items : InventoryTab
    {
        [SerializeField] SelectedItem selectedItem = null;
        [SerializeField] UI.Items items = null;
        [SerializeField] Text slotsUsed = null;

        Manager player;
        Informations informations;
        Events eventsManager;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
            informations = FindObjectOfType<Informations>();
            eventsManager = FindObjectOfType<Events>();
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
            items.OpenItemsTab(0);
            ActualizeSlotsUsedText();
            SelectItem(0);
        }

        private void ActualizeSlotsUsedText()
        {
            slotsUsed.text = "Slots used: " + player.items.GetNumberOfInventorySlotsUsed() + "/" + player.items.InventoryItemSlots;
        }

        private void SelectItem(int index)
        {
            if (items.CanSelect(index))
            {
                selectedItem.SelectItem(player.items.InventoryItems[index]);
                items.SelectedItemIndex = index;
            }
            else
            {
                selectedItem.SelectItem(null);
            }
        }

        public void EquipSelectedItem()
        {
            Item itemToEquip = player.items.InventoryItems[items.SelectedItemIndex];
            if (CanEquip(itemToEquip))
            {
                player.items.EquipItem(items.SelectedItemIndex);
                RefreshItemSlots();
            }
            else
            {
                ShowInfo("Your level is too low to equip this " + itemToEquip.Type.ToString() + ".");
            }
        }

        public void DestroySelectedItem()
        {
            player.items.DestroyItemFromInventory(items.SelectedItemIndex);
            RefreshItemSlots();
        }

        private bool CanEquip(Item itemToEquip)
        {
            return itemToEquip.Level <= player.Stats.Level;
        }

        private void RefreshItemSlots()
        {
            ActualizeSlotsUsedText();
            items.OpenItemsTab(0);
        }

        private void ShowInfo(string info)
        {
            informations.ToggleActive(true);
            informations.ChangeInformation(info);
            informations.SetButtons(false);
        }
    }
}