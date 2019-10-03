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

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void LoadInfo(ItemsList.itemTypes newItemType)
    {
        player.items.SortInventory();
        itemsType = newItemType;
        ShowItems();
        SelectItem(-1);
        Item equippedItem = null;
        switch (itemsType)
        {
            case ItemsList.itemTypes.Weapon:
                equippedItem = player.items.EquippedWeapon;
                break;
            case ItemsList.itemTypes.Armor:
                equippedItem = player.items.EquippedArmor;
                break;
            case ItemsList.itemTypes.Shield:
                equippedItem = player.items.EquippedShield;
                break;
            case ItemsList.itemTypes.Helmet:
                equippedItem = player.items.EquippedHelmet;
                break;
            case ItemsList.itemTypes.Boots:
                equippedItem = player.items.EquippedBoots;
                break;
            case ItemsList.itemTypes.Gloves:
                equippedItem = player.items.EquippedGloves;
                break;
            case ItemsList.itemTypes.Neckle:
                equippedItem = player.items.EquippedNeckle;
                break;
            case ItemsList.itemTypes.Ring:
                equippedItem = player.items.EquippedRing;
                break;
            case ItemsList.itemTypes.Artifact:
                equippedItem = player.items.EquippedArtifact;
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
        itemsIndexes = new int[player.items.InventoryItemSlots];
        for(int i=0; i<itemSlots.Length;i++)
        {
            itemSlots[i].SetActive(false);
        }
        int j = 0;
        for(int i=0; i< player.items.InventoryItemSlots; i++)
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
        if(selectedItemIndex==-1)
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
            if (itemToEquip.Level > player.stats.Level)
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
        if(player.items.InventoryItemSlots- player.items.GetNumberOfInventorySlotsUsed()!=0)
        {
            Item itemToUnequip = null;
            switch (itemsType)
            {
                case ItemsList.itemTypes.Weapon:
                    itemToUnequip = player.items.EquippedWeapon;
                    player.items.EquippedWeapon = null;
                    break;
                case ItemsList.itemTypes.Armor:
                    itemToUnequip = player.items.EquippedArmor;
                    player.items.EquippedArmor = null;
                    break;
                case ItemsList.itemTypes.Shield:
                    itemToUnequip = player.items.EquippedShield;
                    player.items.EquippedShield = null;
                    break;
                case ItemsList.itemTypes.Helmet:
                    itemToUnequip = player.items.EquippedHelmet;
                    player.items.EquippedHelmet = null;
                    break;
                case ItemsList.itemTypes.Boots:
                    itemToUnequip = player.items.EquippedBoots;
                    player.items.EquippedBoots = null;
                    break;
                case ItemsList.itemTypes.Gloves:
                    itemToUnequip = player.items.EquippedGloves;
                    player.items.EquippedGloves = null;
                    break;
                case ItemsList.itemTypes.Neckle:
                    itemToUnequip = player.items.EquippedNeckle;
                    player.items.EquippedNeckle = null;
                    break;
                case ItemsList.itemTypes.Ring:
                    itemToUnequip = player.items.EquippedRing;
                    player.items.EquippedRing = null;
                    break;
                case ItemsList.itemTypes.Artifact:
                    itemToUnequip = player.items.EquippedArtifact;
                    player.items.EquippedArtifact = null;
                    break;
                case ItemsList.itemTypes.Misc:
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
        gameObject.transform.parent.gameObject.GetComponentInChildren<SideMenu>().ShowEquippedItems();
        itemEquipMenu.SetActive(false);
    }
}
