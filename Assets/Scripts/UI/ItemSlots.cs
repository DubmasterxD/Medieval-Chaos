using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Medieval.Core;
using Medieval.Player;

namespace Medieval.UI
{
    public class ItemSlots : MonoBehaviour
    {
        [SerializeField] ItemSlot itemSlotPrefab = null;
        List<ItemSlot> itemSlots = null;

        public int selectedItemIndex { get; set; } = 0;

        bool created = false;

        Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
        }

        public void CreateItemSlots()
        {
            if (!created) //TODO find better way when possibility to increase slots number is added
            {
                itemSlots = new List<ItemSlot>();
                for (int i = 0; i < player.items.InventoryItemSlots; i++)
                {
                    ItemSlot itemSlot = Instantiate(itemSlotPrefab, transform);
                    itemSlot.index = i;
                    itemSlots.Add(itemSlot);
                }
                created = true;
            }
        }

        public void LoadItems()
        {
            player.items.SortInventory();
            for (int i = 0; i < player.items.InventoryItemSlots; i++)
            {
                itemSlots[i].ChangeItemAmount(0);
                if (player.items.InventoryItems[i] == null)
                {
                    itemSlots[i].ChangeSprite(null);
                }
                else
                {
                    itemSlots[i].ChangeSprite(player.items.InventoryItems[i].Image);
                    if (player.items.InventoryItems[i].Type == ItemType.Misc)
                    {
                        itemSlots[i].ChangeItemAmount(player.items.InventoryItems[i].Amount);
                    }
                }
            }
        }

        public void ShowSpecificItems(ItemType[] itemTypes)
        {
            for (int i = 0; i < player.items.InventoryItemSlots; i++)
            {
                if (player.items.InventoryItems[i] == null)
                {
                    itemSlots[i].ToggleSelectable(false);
                }
                else
                {
                    bool isOfSearchingType = ContainsType(itemTypes, player.items.InventoryItems[i].Type);
                    itemSlots[i].ToggleSelectable(isOfSearchingType);
                }
            }
        }

        private bool ContainsType(ItemType[] itemTypes, ItemType type)
        {
            foreach (ItemType itemType in itemTypes)
            {
                if (itemType == type)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CanSelect(int index)
        {
            return player.items.InventoryItems[index] == null || itemSlots[index].GetComponentsInChildren<Image>()[1].color != Color.black;
        }
    }
}