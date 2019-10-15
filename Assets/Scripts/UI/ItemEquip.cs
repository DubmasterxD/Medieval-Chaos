using UnityEngine;
using UnityEngine.UI;
using Medieval.Core;
using Medieval.Player;

namespace Medieval.UI
{
    public class ItemEquip : MonoBehaviour
    {
        [SerializeField] GameObject itemEquipMenu = null;
        [SerializeField] Image equippedItemImage = null;
        [SerializeField] Image selectedItemImage = null;
        [SerializeField] Text equippedItemInfo = null;
        [SerializeField] Text selectedItemInfo = null;
        [SerializeField] GameObject[] itemSlots = null;
        [SerializeField] Text info = null;
        int[] itemsIndexes;
        ItemType itemsType;
        int selectedItemIndex = 0;

        Manager player;

        private void Start()
        {
            player = FindObjectOfType<Manager>();
        }

        public void LoadInfo(ItemType newItemType)
        {
            player.items.SortInventory();
            itemsType = newItemType;
            ShowItems();
            SelectItem(-1);
            Item equippedItem = null;
            switch (itemsType)
            {
                case ItemType.Weapon:
                    equippedItem = player.items.EquippedWeapon;
                    break;
                case ItemType.Armor:
                    equippedItem = player.items.EquippedArmor;
                    break;
                case ItemType.Shield:
                    equippedItem = player.items.EquippedShield;
                    break;
                case ItemType.Helmet:
                    equippedItem = player.items.EquippedHelmet;
                    break;
                case ItemType.Boots:
                    equippedItem = player.items.EquippedBoots;
                    break;
                case ItemType.Gloves:
                    equippedItem = player.items.EquippedGloves;
                    break;
                case ItemType.Neckle:
                    equippedItem = player.items.EquippedNeckle;
                    break;
                case ItemType.Ring:
                    equippedItem = player.items.EquippedRing;
                    break;
                case ItemType.Artifact:
                    equippedItem = player.items.EquippedArtifact;
                    break;
                case ItemType.Misc:
                    break;
                default:
                    break;
            }
            if (equippedItem != null)
            {
                equippedItemImage.sprite = equippedItem.Image;
                equippedItemInfo.text = equippedItem.GetStatsDescription();
            }
            else
            {
                equippedItemImage.sprite = null;
                equippedItemInfo.text = "No " + itemsType.ToString() + " equipped";
            }
        }

        public void ShowItems()
        {
            itemsIndexes = new int[player.items.InventoryItemSlots];
            for (int i = 0; i < itemSlots.Length; i++)
            {
                itemSlots[i].SetActive(false);
            }
            int j = 0;
            for (int i = 0; i < player.items.InventoryItemSlots; i++)
            {
                if (player.items.InventoryItems[i] != null)
                {
                    if (player.items.InventoryItems[i].Type == itemsType)
                    {
                        itemSlots[j].SetActive(true);
                        itemsIndexes[j] = i;
                        itemSlots[j].GetComponentsInChildren<Image>()[1].sprite = player.items.InventoryItems[i].Image;
                        j++;
                    }
                }
            }
        }

        public void SelectItem(int index)
        {
            selectedItemIndex = index;
            if (selectedItemIndex == -1)
            {
                selectedItemImage.sprite = null;
                selectedItemInfo.text = "No " + itemsType.ToString() + " selected.";
            }
            else
            {
                Item selectedItem = player.items.InventoryItems[itemsIndexes[index]];
                selectedItemImage.sprite = selectedItem.Image;
                selectedItemInfo.text = selectedItem.GetStatsDescription();
            }
        }

        public void EquipSelectedItem()
        {
            if (selectedItemIndex == -1)
            {
                info.text = "No " + itemsType.ToString() + " selected.";
                info.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                Item itemToEquip = player.items.InventoryItems[itemsIndexes[selectedItemIndex]];
                if (itemToEquip.Level > player.Stats.Level)
                {
                    info.text = "Your level is too low to equip this " + itemsType.ToString() + ".";
                    info.transform.parent.gameObject.SetActive(true);
                }
                else
                {
                    player.items.EquipItem(itemsIndexes[selectedItemIndex]);
                    CloseWindow();
                }
            }
        }

        public void UnequipItem()
        {
            if (player.items.InventoryItemSlots - player.items.GetNumberOfInventorySlotsUsed() != 0)
            {
                Item itemToUnequip = null;
                switch (itemsType)
                {
                    case ItemType.Weapon:
                        itemToUnequip = player.items.EquippedWeapon;
                        player.items.EquippedWeapon = null;
                        break;
                    case ItemType.Armor:
                        itemToUnequip = player.items.EquippedArmor;
                        player.items.EquippedArmor = null;
                        break;
                    case ItemType.Shield:
                        itemToUnequip = player.items.EquippedShield;
                        player.items.EquippedShield = null;
                        break;
                    case ItemType.Helmet:
                        itemToUnequip = player.items.EquippedHelmet;
                        player.items.EquippedHelmet = null;
                        break;
                    case ItemType.Boots:
                        itemToUnequip = player.items.EquippedBoots;
                        player.items.EquippedBoots = null;
                        break;
                    case ItemType.Gloves:
                        itemToUnequip = player.items.EquippedGloves;
                        player.items.EquippedGloves = null;
                        break;
                    case ItemType.Neckle:
                        itemToUnequip = player.items.EquippedNeckle;
                        player.items.EquippedNeckle = null;
                        break;
                    case ItemType.Ring:
                        itemToUnequip = player.items.EquippedRing;
                        player.items.EquippedRing = null;
                        break;
                    case ItemType.Artifact:
                        itemToUnequip = player.items.EquippedArtifact;
                        player.items.EquippedArtifact = null;
                        break;
                    case ItemType.Misc:
                        break;
                    default:
                        break;
                }
                if (itemToUnequip != null)
                {
                    player.items.InventoryItems[player.items.InventoryItemSlots - 1] = itemToUnequip;
                    player.items.UpdateStats();
                    CloseWindow();
                }
                else
                {
                    info.text = "There is no " + itemsType.ToString() + " equipped.";
                    info.transform.parent.gameObject.SetActive(true);
                }
            }
            else
            {
                info.text = "You don't have enough space in inventory to unequip this " + itemsType.ToString() + ".";
                info.transform.parent.gameObject.SetActive(true);
            }
        }

        public void CloseWindow()
        {
            gameObject.transform.parent.gameObject.GetComponentInChildren<Side>().ShowEquippedItems();
            itemEquipMenu.SetActive(false);
        }
    }
}