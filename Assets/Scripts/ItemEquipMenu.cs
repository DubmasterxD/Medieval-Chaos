using UnityEngine;
using UnityEngine.UI;

public class ItemEquipMenu : MonoBehaviour
{
    [SerializeField] GameObject itemEquipMenu = null;
    [SerializeField] Image equippedItemImage = null;
    [SerializeField] Image selectedItemImage = null;
    [SerializeField] Text equippedItemInfo = null;
    [SerializeField] Text selectedItemInfo = null;
    [SerializeField] GameObject[] itemSlots = null;
    [SerializeField] Text info = null;
    int[] itemsIndexes;
    ItemsList.itemTypes itemsType;
    int selectedItemIndex = 0;

    ItemsList playerItems;

    private void Start()
    {
        playerItems = Player.instance.items;
    }

    public void LoadInfo(ItemsList.itemTypes newItemType)
    {
        playerItems.SortInventory();
        itemsType = newItemType;
        ShowItems();
        SelectItem(-1);
        Item equippedItem = null;
        switch (itemsType)
        {
            case ItemsList.itemTypes.Weapon:
                equippedItem = playerItems.EquippedWeapon;
                break;
            case ItemsList.itemTypes.Armor:
                equippedItem = playerItems.EquippedArmor;
                break;
            case ItemsList.itemTypes.Shield:
                equippedItem = playerItems.EquippedShield;
                break;
            case ItemsList.itemTypes.Helmet:
                equippedItem = playerItems.EquippedHelmet;
                break;
            case ItemsList.itemTypes.Boots:
                equippedItem = playerItems.EquippedBoots;
                break;
            case ItemsList.itemTypes.Gloves:
                equippedItem = playerItems.EquippedGloves;
                break;
            case ItemsList.itemTypes.Neckle:
                equippedItem = playerItems.EquippedNeckle;
                break;
            case ItemsList.itemTypes.Ring:
                equippedItem = playerItems.EquippedRing;
                break;
            case ItemsList.itemTypes.Artifact:
                equippedItem = playerItems.EquippedArtifact;
                break;
            case ItemsList.itemTypes.Misc:
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
            equippedItemInfo.text = "No "+itemsType.ToString()+" equipped";
        }
    }

    public void ShowItems()
    {
        itemsIndexes = new int[playerItems.InventoryItemSlots];
        for(int i=0; i<itemSlots.Length;i++)
        {
            itemSlots[i].SetActive(false);
        }
        int j = 0;
        for(int i=0; i<playerItems.InventoryItemSlots; i++)
        {
            if (playerItems.InventoryItems[i] != null)
            {
                if (playerItems.InventoryItems[i].Type == itemsType)
                {
                    itemSlots[j].SetActive(true);
                    itemsIndexes[j] = i;
                    itemSlots[j].GetComponentsInChildren<Image>()[1].sprite = playerItems.InventoryItems[i].Image;
                    j++;
                }
            }
        }
    }

    public void SelectItem(int index)
    {
        selectedItemIndex = index;
        if(selectedItemIndex==-1)
        {
            selectedItemImage.sprite = null;
            selectedItemInfo.text = "No " + itemsType.ToString() + " selected.";
        }
        else
        {
            Item selectedItem = playerItems.InventoryItems[itemsIndexes[index]];
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
            Item itemToEquip = playerItems.InventoryItems[itemsIndexes[selectedItemIndex]];
            if (itemToEquip.Level > Player.instance.stats.Level)
            {
                info.text = "Your level is too low to equip this " + itemsType.ToString() + ".";
                info.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                playerItems.EquipItem(itemsIndexes[selectedItemIndex]);
                CloseWindow();
            }
        }
    }

    public void UnequipItem()
    {
        if(playerItems.InventoryItemSlots-playerItems.GetNumberOfInventorySlotsUsed()!=0)
        {
            Item itemToUnequip = null;
            switch (itemsType)
            {
                case ItemsList.itemTypes.Weapon:
                    itemToUnequip = playerItems.EquippedWeapon;
                    playerItems.EquippedWeapon = null;
                    break;
                case ItemsList.itemTypes.Armor:
                    itemToUnequip = playerItems.EquippedArmor;
                    playerItems.EquippedArmor = null;
                    break;
                case ItemsList.itemTypes.Shield:
                    itemToUnequip = playerItems.EquippedShield;
                    playerItems.EquippedShield = null;
                    break;
                case ItemsList.itemTypes.Helmet:
                    itemToUnequip = playerItems.EquippedHelmet;
                    playerItems.EquippedHelmet = null;
                    break;
                case ItemsList.itemTypes.Boots:
                    itemToUnequip = playerItems.EquippedBoots;
                    playerItems.EquippedBoots = null;
                    break;
                case ItemsList.itemTypes.Gloves:
                    itemToUnequip = playerItems.EquippedGloves;
                    playerItems.EquippedGloves = null;
                    break;
                case ItemsList.itemTypes.Neckle:
                    itemToUnequip = playerItems.EquippedNeckle;
                    playerItems.EquippedNeckle = null;
                    break;
                case ItemsList.itemTypes.Ring:
                    itemToUnequip = playerItems.EquippedRing;
                    playerItems.EquippedRing = null;
                    break;
                case ItemsList.itemTypes.Artifact:
                    itemToUnequip = playerItems.EquippedArtifact;
                    playerItems.EquippedArtifact = null;
                    break;
                case ItemsList.itemTypes.Misc:
                    break;
                default:
                    break;
            }
            if (itemToUnequip != null)
            {
                playerItems.InventoryItems[playerItems.InventoryItemSlots - 1] = itemToUnequip;
                playerItems.UpdateStats();
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
        gameObject.transform.parent.gameObject.GetComponentInChildren<SideMenu>().ShowEquippedItems();
        itemEquipMenu.SetActive(false);
    }
}
