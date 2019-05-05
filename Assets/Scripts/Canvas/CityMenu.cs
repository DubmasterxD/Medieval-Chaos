using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityMenu : MonoBehaviour
{
    enum CityTabs {Inventory, Shop, Blacksmith, Stash };
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

    private PlayerStats playerStats;
    private ItemsList playerItems;

    private void Start()
    {
        playerStats = Player.instance.stats;
        playerItems = Player.instance.items;
    }

    public void OpenStash()
    {
        currentTab = CityTabs.Stash;
        shopTabs.SetActive(false);
        tabs.SetActive(true);
        SetHighlightsInactive();
        allItemsMenuButtonHighlight.SetActive(true);
        //TODO count slots
        moneyArea.SetActive(false);
        slotsText.gameObject.SetActive(true);
        //TODO show items in stash
        //TODO change info
        itemBlacksmithDescription.SetActive(false);
        itemDescription.SetActive(true);
        button1.GetComponentInChildren<Text>().text = "To Inventory";
        button2.gameObject.SetActive(false);
    }

    public void OpenBlacksmith()
    {
        currentTab = CityTabs.Blacksmith;
        shopTabs.SetActive(false);
        tabs.SetActive(true);
        SetHighlightsInactive();
        allItemsMenuButtonHighlight.SetActive(true);
        //TODO count money
        slotsText.gameObject.SetActive(false);
        moneyArea.SetActive(true);
        //TODO show items in inventory
        //TODO change info
        itemDescription.SetActive(false);
        itemBlacksmithDescription.SetActive(true);
        button1.GetComponentInChildren<Text>().text = "Upgrade";
        button2.gameObject.SetActive(true);
        button2.GetComponentInChildren<Text>().text = "Dismantle";
    }

    public void OpenShop()
    {
        currentTab = CityTabs.Shop;
        tabs.SetActive(false);
        shopTabs.SetActive(true);
        SetHighlightsInactive();
        sellItemsShopButtonHighlight.SetActive(true);
        //TODO count money
        slotsText.gameObject.SetActive(false);
        moneyArea.SetActive(true);
        //TODO show items in inventory
        //TODO change info
        itemBlacksmithDescription.SetActive(false);
        itemDescription.SetActive(true);
        button1.GetComponentInChildren<Text>().text = "Sell";
        button2.gameObject.SetActive(true);
        button2.GetComponentInChildren<Text>().text = "Dismantle";
    }

    public void OpenInventory()
    {
        currentTab = CityTabs.Inventory;
        shopTabs.SetActive(false);
        tabs.SetActive(true);
        SetHighlightsInactive();
        allItemsMenuButtonHighlight.SetActive(true);
        //TODO count slots
        moneyArea.SetActive(false);
        slotsText.gameObject.SetActive(true);
        //TODO show items in inventory
        //TODO change info
        itemBlacksmithDescription.SetActive(false);
        itemDescription.SetActive(true);
        button1.GetComponentInChildren<Text>().text = "Equip";
        button2.gameObject.SetActive(true);
        button2.GetComponentInChildren<Text>().text = "To Stash";
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

    public void ExitCity()
    {
        this.gameObject.SetActive(false);
    }
}
