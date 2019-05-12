using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityMenu : MonoBehaviour
{
    enum CityTabs {Inventory, Sell, Buy, Blacksmith, Stash };
    CityTabs currentTab = default;
    [SerializeField] GameObject shopTabs = null;
    [SerializeField] GameObject tabs = null;
    [SerializeField] GameObject sellItemsShopButtonHighlight = null;
    [SerializeField] GameObject buyItemsShopButtonHighlight = null;
    [SerializeField] GameObject allItemsMenuButtonHighlight = null;
    [SerializeField] GameObject weaponItemsMenuButtonHighlight = null;
    [SerializeField] GameObject armorItemsMenuButtonHighlight = null;
    [SerializeField] GameObject accessoryItemsMenuButtonHighlight = null;
    [SerializeField] GameObject miscItemsMenuButtonHighlight = null;
    [SerializeField] Text slotsText = null;
    [SerializeField] GameObject moneyArea = null;
    [SerializeField] Text ownedMoneyText = null;
    [SerializeField] Text itemCostText = null;
    [SerializeField] GameObject[] itemSlots = null;
    [SerializeField] GameObject itemDescription = null;
    [SerializeField] GameObject itemBlacksmithDescription = null;
    [SerializeField] Image selectedItemImage = null;
    [SerializeField] Text selectedItemName = null;
    [SerializeField] Text selectedItemDescription = null;
    [SerializeField] Text selectedItemBlacksmithDescription = null;
    [SerializeField] Text selectedItemBlacksmithUpgrade = null;
    [SerializeField] Button button1 = null;
    [SerializeField] Button button2 = null;
    [Header("Info")]
    [SerializeField] Text info = null;
    [SerializeField] Text DismantleInfo = null;

    private PlayerStats playerStats;
    private ItemsList playerItems;
    int selectedItemIndex = 0;

    private void Start()
    {
        playerStats = Player.instance.stats;
        playerItems = Player.instance.items;
        OpenInventory();
    }

    public void OpenStash()
    {
        currentTab = CityTabs.Stash;
        ChangeMenu("To Inventory", "");
    }

    public void OpenBlacksmith()
    {
        currentTab = CityTabs.Blacksmith;
        ChangeMenu("Upgrade", "Dismantle");
    }

    public void OpenShop()
    {
        currentTab = CityTabs.Sell;
        ChangeMenu("Sell", "Dismantle");
    }

    public void OpenInventory()
    {
        currentTab = CityTabs.Inventory;
        ChangeMenu("Equip", "To Stash");
    }

    private void ChangeMenu(string button1Text, string button2Text)
    {
        bool isShop = (currentTab == CityTabs.Buy || currentTab == CityTabs.Sell);
        bool isBlacksmith = currentTab == CityTabs.Blacksmith;
        bool isStash = currentTab == CityTabs.Stash;
        tabs.SetActive(!isShop);
        shopTabs.SetActive(isShop);
        SetHighlightsInactive();
        allItemsMenuButtonHighlight.SetActive(true);
        sellItemsShopButtonHighlight.SetActive(true);
        SetItemSlots();
        if(isShop || isBlacksmith)
        {
            slotsText.gameObject.SetActive(false);
            moneyArea.SetActive(true);
        }
        else
        {
            moneyArea.SetActive(false);
            slotsText.gameObject.SetActive(true);
        }
        ShowAllItems();
        SelectItem(0);
        itemDescription.SetActive(!isBlacksmith);
        itemBlacksmithDescription.SetActive(isBlacksmith);
        button1.GetComponentInChildren<Text>().text = button1Text;
        button2.gameObject.SetActive(!isStash);
        button2.GetComponentInChildren<Text>().text = button2Text;
    }

    public void SetHighlightsInactive()
    {
        accessoryItemsMenuButtonHighlight.SetActive(false);
        allItemsMenuButtonHighlight.SetActive(false);
        armorItemsMenuButtonHighlight.SetActive(false);
        buyItemsShopButtonHighlight.SetActive(false);
        miscItemsMenuButtonHighlight.SetActive(false);
        sellItemsShopButtonHighlight.SetActive(false);
        weaponItemsMenuButtonHighlight.SetActive(false);
    }

    public void ShowMerchantItems()
    {
        //TODO show merchant items
    }

    public void ShowAllItems()
    {
        Sort();
        SetHighlightsInactive();
        sellItemsShopButtonHighlight.SetActive(true);
        allItemsMenuButtonHighlight.SetActive(true);
        if (currentTab == CityTabs.Stash)
        {
            ShowItems(playerItems.StashItems, playerItems.StashItemSlots);
        }
        else
        {
            ShowItems(playerItems.InventoryItems, playerItems.InventoryItemSlots);
        }
        SelectItem(0);
    }

    private void Sort()
    {
        if (currentTab == CityTabs.Stash)
        {
            playerItems.SortStash();
        }
        else
        {
            playerItems.SortInventory();
        }
    }

    private void ShowItems(Item[] items, int slots)
    {
        for (int i = 0; i < slots; i++)
        {
            itemSlots[i].GetComponentInChildren<Text>().text = "";
            if (items[i] == null)
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].sprite = null;
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].sprite = items[i].Image;
                if (items[i].Type == ItemsList.itemTypes.Misc)
                {
                    itemSlots[i].GetComponentInChildren<Text>().text = items[i].Amount.ToString();
                }
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.white;
            }
        }
    }

    public void ShowWeaponItems()
    {
        SetHighlightsInactive();
        weaponItemsMenuButtonHighlight.SetActive(true);
        ItemsList.itemTypes[] types = { ItemsList.itemTypes.Weapon, ItemsList.itemTypes.Shield };
        ShowSpecificItems(types);
    }

    public void ShowArmorItems()
    {
        SetHighlightsInactive();
        armorItemsMenuButtonHighlight.SetActive(true);
        ItemsList.itemTypes[] types = { ItemsList.itemTypes.Armor, ItemsList.itemTypes.Helmet, ItemsList.itemTypes.Boots, ItemsList.itemTypes.Gloves };
        ShowSpecificItems(types);
    }

    public void ShowAccessoryItems()
    {
        SetHighlightsInactive();
        accessoryItemsMenuButtonHighlight.SetActive(true);
        ItemsList.itemTypes[] types = { ItemsList.itemTypes.Artifact, ItemsList.itemTypes.Neckle, ItemsList.itemTypes.Ring };
        ShowSpecificItems(types);
    }

    public void ShowMiscItems()
    {
        SetHighlightsInactive();
        miscItemsMenuButtonHighlight.SetActive(true);
        ItemsList.itemTypes[] types = { ItemsList.itemTypes.Misc };
        ShowSpecificItems(types);
    }

    public void ShowSpecificItems(ItemsList.itemTypes[] itemTypes)
    {
        bool selected = false;
        Item[] items;
        int slots;
        if (currentTab == CityTabs.Stash)
        {
            items = playerItems.StashItems;
            slots = playerItems.StashItemSlots;
        }
        else
        {
            items = playerItems.InventoryItems;
            slots = playerItems.InventoryItemSlots;
        }
        for (int i = 0; i < slots; i++)
        {

            if (items[i] == null)
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                bool isOfSearchingType = false;
                foreach (ItemsList.itemTypes type in itemTypes)
                {
                    if (items[i].Type == type)
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

    public void SelectItem(int index)
    {
        selectedItemIndex = index;
        if (itemSlots[index].GetComponentsInChildren<Image>()[1].color != Color.black)
        {
            if (playerItems.InventoryItems[index] == null)
            {
                selectedItemImage.sprite = null;
                selectedItemName.text = "None";
                selectedItemDescription.text = "No item selected";
                selectedItemBlacksmithDescription.text = "No item selected";
                selectedItemBlacksmithUpgrade.text = "";
            }
            else
            {
                if (currentTab == CityTabs.Stash)
                {
                    selectedItemImage.sprite = playerItems.StashItems[index].Image;
                    selectedItemName.text = playerItems.StashItems[index].Rarity + " " + playerItems.StashItems[index].Name;
                    selectedItemDescription.text = playerItems.StashItems[index].GetStatsDescription();
                }
                else if (currentTab == CityTabs.Buy)
                {
                    //TODO merchant items info
                }
                else
                {
                    selectedItemImage.sprite = playerItems.InventoryItems[index].Image;
                    selectedItemName.text = playerItems.InventoryItems[index].Rarity + " " + playerItems.InventoryItems[index].Name;
                    selectedItemDescription.text = playerItems.InventoryItems[index].GetStatsDescription();
                    if (currentTab == CityTabs.Blacksmith)
                    {
                        Item itemToUpgrade = playerItems.InventoryItems[selectedItemIndex];
                        selectedItemBlacksmithDescription.text = playerItems.InventoryItems[index].GetStatsDescription();
                        selectedItemBlacksmithUpgrade.text = "Materials required :";
                        foreach (Item item in itemToUpgrade.UpgradeResources)
                        {
                            if (item.Type == ItemsList.itemTypes.Misc)
                            {
                                selectedItemBlacksmithUpgrade.text += "\n- " + item.Amount + "x ";
                            }
                            else
                            {
                                selectedItemBlacksmithUpgrade.text += "\n- 1x ";
                            }
                            selectedItemBlacksmithUpgrade.text += item.Name;
                        }
                        selectedItemBlacksmithUpgrade.text += "\n" + playerItems.InventoryItems[index].nextUpgradeCost + " Gold";
                    }
                }
            }
        }
    }

    public void ShowDismantleInfo()
    {
        Item itemToDismantle = playerItems.InventoryItems[selectedItemIndex];
        DismantleInfo.text = "Are you sure that you want to dismantle " + itemToDismantle.Rarity + " " + itemToDismantle.Name + " ?\nYou will get:";
        if (itemToDismantle.DismantleResources.Length == 0)
        {
            DismantleInfo.text += "\nnothing";
        }
        foreach (Item item in itemToDismantle.DismantleResources)
        {
            if (item.Type == ItemsList.itemTypes.Misc)
            {
                DismantleInfo.text += "\n- " + item.Amount + "x ";
            }
            else
            {
                DismantleInfo.text += "\n- 1x ";
            }
            DismantleInfo.text += item.Name;
        }
        DismantleInfo.transform.parent.gameObject.SetActive(true);
    }

    public void DismantleSelectedItem()
    {
        Item itemToDismantle = playerItems.InventoryItems[selectedItemIndex];
        if (playerItems.InventoryItemSlots - playerItems.GetNumberOfInventorySlotsUsed() >= itemToDismantle.DismantleResources.Length - 1)
        {
            playerItems.InventoryItems[selectedItemIndex] = null;
            int i = 0;
            int j = 0;
            while (i < itemToDismantle.DismantleResources.Length)
            {
                if (itemToDismantle.DismantleResources[i].Type == ItemsList.itemTypes.Misc)
                {
                    int k = 0;
                    while (k < playerItems.InventoryItemSlots && playerItems.InventoryItems[k].Name != itemToDismantle.DismantleResources[i].Name)
                    {
                        k++;
                    }
                    if (playerItems.InventoryItems[k] == null)
                    {
                        playerItems.InventoryItems[k] = itemToDismantle.DismantleResources[i];
                    }
                    else
                    {
                        playerItems.InventoryItems[k].Amount += itemToDismantle.DismantleResources[i].Amount;
                    }
                    i++;
                    j--;
                }
                if (playerItems.InventoryItems[j] == null)
                {
                    playerItems.InventoryItems[j] = itemToDismantle.DismantleResources[i];
                    i++;
                }
                j++;
            }
            SetItemSlots();
            ShowAllItems();
        }
        else
        {
            info.text = "You don't have enough space in inventory to dismantle this item.";
            info.transform.parent.gameObject.SetActive(true);
        }
        DismantleInfo.transform.parent.gameObject.SetActive(false);
    }

    public void SetItemSlots()
    {
        if (currentTab == CityTabs.Stash)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (i < playerItems.StashItemSlots)
                {
                    itemSlots[i].SetActive(true);
                }
                else
                {
                    itemSlots[i].SetActive(false);
                }
            }
        }
        else if (currentTab == CityTabs.Buy)
        {
            //TODO merchants
        }
        else
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (i < playerItems.InventoryItemSlots)
                {
                    itemSlots[i].SetActive(true);
                }
                else
                {
                    itemSlots[i].SetActive(false);
                }
            }
        }
        if (currentTab == CityTabs.Inventory || currentTab == CityTabs.Stash)
        {
            slotsText.text = "Slots used: " + playerItems.GetNumberOfInventorySlotsUsed() + "/" + playerItems.InventoryItemSlots;
        }
        else
        {
            ownedMoneyText.text = Player.instance.currency.gold.ToString();
            itemCostText.text = "Upgrade for : " + playerItems.InventoryItems[selectedItemIndex].nextUpgradeCost;
        }
    }

    public void Button1Use()
    {
        //TODO button 1 use
    }

    public void Button2Use()
    {
        //TODO button 2 use
    }

    public void ExitCity()
    {
        gameObject.SetActive(false);
    }
}
