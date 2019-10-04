using UnityEngine;
using UnityEngine.UI;

public class ItemsInventoryMenu : MonoBehaviour
{
    [SerializeField] GameObject allItemsMenuButtonHighlight = null;
    [SerializeField] GameObject weaponItemsMenuButtonHighlight = null;
    [SerializeField] GameObject armorItemsMenuButtonHighlight = null;
    [SerializeField] GameObject accessoryItemsMenuButtonHighlight = null;
    [SerializeField] GameObject miscItemsMenuButtonHighlight = null;
    [SerializeField] Text slotsText = null;
    [SerializeField] GameObject[] itemSlots = null;
    [SerializeField] Image selectedItemImage = null;
    [SerializeField] Text selectedItemName = null;
    [SerializeField] Text selectedItemDescription = null;
    [Header("Info")]
    [SerializeField] Text info = null;

    int selectedItemIndex = 0;

    private Player player;

    public void SetItemSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < player.items.InventoryItemSlots)
            {
                itemSlots[i].SetActive(true);
            }
            else
            {
                itemSlots[i].SetActive(false);
            }
        }
        slotsText.text = "Slots used: " + player.items.GetNumberOfInventorySlotsUsed() + "/" + player.items.InventoryItemSlots;
    }

    public void ShowAllItems()
    {
        player.items.SortInventory();
        SetAllItemsMenuHighlightInactive();
        allItemsMenuButtonHighlight.SetActive(true);
        for (int i = 0; i < player.items.InventoryItemSlots; i++)
        {
            itemSlots[i].GetComponentInChildren<Text>().text = "";
            if (player.items.InventoryItems[i] == null)
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].sprite = null;
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].sprite = player.items.InventoryItems[i].Image;
                if (player.items.InventoryItems[i].Type == ItemsList.itemTypes.Misc)
                {
                    itemSlots[i].GetComponentInChildren<Text>().text = player.items.InventoryItems[i].Amount.ToString();
                }
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.white;
            }
        }
        SelectItem(0);
    }

    public void ShowWeaponItems()
    {
        SetAllItemsMenuHighlightInactive();
        weaponItemsMenuButtonHighlight.SetActive(true);
        ItemsList.itemTypes[] types = { ItemsList.itemTypes.Weapon, ItemsList.itemTypes.Shield };
        ShowSpecificItems(types);
    }

    public void ShowArmorItems()
    {
        SetAllItemsMenuHighlightInactive();
        armorItemsMenuButtonHighlight.SetActive(true);
        ItemsList.itemTypes[] types = { ItemsList.itemTypes.Armor, ItemsList.itemTypes.Helmet, ItemsList.itemTypes.Boots, ItemsList.itemTypes.Gloves };
        ShowSpecificItems(types);
    }

    public void ShowAccessoryItems()
    {
        SetAllItemsMenuHighlightInactive();
        accessoryItemsMenuButtonHighlight.SetActive(true);
        ItemsList.itemTypes[] types = { ItemsList.itemTypes.Artifact, ItemsList.itemTypes.Neckle, ItemsList.itemTypes.Ring };
        ShowSpecificItems(types);
    }

    public void ShowMiscItems()
    {
        SetAllItemsMenuHighlightInactive();
        miscItemsMenuButtonHighlight.SetActive(true);
        ItemsList.itemTypes[] types = { ItemsList.itemTypes.Misc };
        ShowSpecificItems(types);
    }

    public void ShowSpecificItems(ItemsList.itemTypes[] itemTypes)
    {
        bool selected = false;
        for (int i = 0; i < player.items.InventoryItemSlots; i++)
        {
            if (player.items.InventoryItems[i] == null)
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                bool isOfSearchingType = false;
                foreach (ItemsList.itemTypes type in itemTypes)
                {
                    if (player.items.InventoryItems[i].Type == type)
                    {
                        isOfSearchingType = true;
                    }
                }
                if (isOfSearchingType)
                {
                    itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.white;
                    if (selected == false)
                    {
                        SelectItem(i);
                        selected = true;
                    }
                }
                else
                {
                    itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
                }
            }
        }
    }

    private void SetAllItemsMenuHighlightInactive()
    {
        allItemsMenuButtonHighlight.SetActive(false);
        weaponItemsMenuButtonHighlight.SetActive(false);
        armorItemsMenuButtonHighlight.SetActive(false);
        accessoryItemsMenuButtonHighlight.SetActive(false);
        miscItemsMenuButtonHighlight.SetActive(false);
    }

    public void SelectItem(int index)
    {
        selectedItemIndex = index;
        if (itemSlots[index].GetComponentsInChildren<Image>()[1].color != Color.black)
        {
            if (player.items.InventoryItems[index] == null)
            {
                selectedItemImage.sprite = null;
                selectedItemName.text = "None";
                selectedItemDescription.text = "No item selected";
            }
            else
            {
                selectedItemImage.sprite = player.items.InventoryItems[index].Image;
                selectedItemName.text = player.items.InventoryItems[index].Rarity + " " + player.items.InventoryItems[index].Name;
                selectedItemDescription.text = player.items.InventoryItems[index].GetStatsDescription();
            }
        }
    }

    public void EquipSelectedItem()
    {
        Item itemToEquip = player.items.InventoryItems[selectedItemIndex];
        if (itemToEquip.Level > player.stats.Level)
        {
            info.text = "Your level is too low to equip this " + itemToEquip.Type.ToString() + ".";
            info.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            player.items.EquipItem(selectedItemIndex);
            SetItemSlots();
            ShowAllItems();
        }
    }
}
