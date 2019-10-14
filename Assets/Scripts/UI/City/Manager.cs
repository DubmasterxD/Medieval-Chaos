using UnityEngine;
using UnityEngine.UI;
using Medieval.Core;
using Medieval.Player;

namespace Medieval.UI.City
{
    public class Manager : MonoBehaviour
    {
        enum CityTabs { Inventory, Sell, Buy, Blacksmith, Stash };
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
        [SerializeField] Text confirmText = null;

        private Player.Manager player;
        int selectedItemIndex = 0;

        private void Start()
        {
            player = FindObjectOfType<Player.Manager>();
            OpenInventory();
        }

        public void OpenStash()
        {
            ChangeMenu(CityTabs.Stash, "To Inventory", "");
        }

        public void OpenBlacksmith()
        {
            ChangeMenu(CityTabs.Blacksmith, "Upgrade", "Dismantle");
        }

        public void OpenShop()
        {
            ChangeMenu(CityTabs.Sell, "Sell", "Dismantle");
        }

        public void OpenInventory()
        {
            ChangeMenu(CityTabs.Inventory, "Equip", "To Stash");
        }

        private void ChangeMenu(CityTabs toTab, string button1Text, string button2Text)
        {
            currentTab = toTab;
            bool isShop = (currentTab == CityTabs.Buy || currentTab == CityTabs.Sell);
            bool isBlacksmith = currentTab == CityTabs.Blacksmith;
            bool isStash = currentTab == CityTabs.Stash;
            tabs.SetActive(!isShop);
            shopTabs.SetActive(isShop);
            SetHighlightsInactive();
            allItemsMenuButtonHighlight.SetActive(true);
            sellItemsShopButtonHighlight.SetActive(true);
            SetItemSlots();
            if (isShop || isBlacksmith)
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
                ShowItems(player.items.StashItems, player.items.StashItemSlots);
            }
            else
            {
                ShowItems(player.items.InventoryItems, player.items.InventoryItemSlots);
            }
            SelectItem(0);
        }

        private void Sort()
        {
            if (currentTab == CityTabs.Stash)
            {
                player.items.SortStash();
            }
            else
            {
                player.items.SortInventory();
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
                    if (items[i].Type == ItemType.Misc)
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
            ItemType[] types = { ItemType.Weapon, ItemType.Shield };
            ShowSpecificItems(types);
        }

        public void ShowArmorItems()
        {
            SetHighlightsInactive();
            armorItemsMenuButtonHighlight.SetActive(true);
            ItemType[] types = { ItemType.Armor, ItemType.Helmet, ItemType.Boots, ItemType.Gloves };
            ShowSpecificItems(types);
        }

        public void ShowAccessoryItems()
        {
            SetHighlightsInactive();
            accessoryItemsMenuButtonHighlight.SetActive(true);
            ItemType[] types = { ItemType.Artifact, ItemType.Neckle, ItemType.Ring };
            ShowSpecificItems(types);
        }

        public void ShowMiscItems()
        {
            SetHighlightsInactive();
            miscItemsMenuButtonHighlight.SetActive(true);
            ItemType[] types = { ItemType.Misc };
            ShowSpecificItems(types);
        }

        public void ShowSpecificItems(ItemType[] itemTypes)
        {
            bool selected = false;
            Item[] items;
            int slots;
            if (currentTab == CityTabs.Stash)
            {
                items = player.items.StashItems;
                slots = player.items.StashItemSlots;
            }
            else
            {
                items = player.items.InventoryItems;
                slots = player.items.InventoryItemSlots;
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
                    foreach (ItemType type in itemTypes)
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
                if (player.items.InventoryItems[index] == null)
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
                        selectedItemImage.sprite = player.items.StashItems[index].Image;
                        selectedItemName.text = player.items.StashItems[index].Rarity + " " + player.items.StashItems[index].Name;
                        selectedItemDescription.text = player.items.StashItems[index].GetStatsDescription();
                    }
                    else if (currentTab == CityTabs.Buy)
                    {
                        //TODO merchant items info
                    }
                    else
                    {
                        selectedItemImage.sprite = player.items.InventoryItems[index].Image;
                        selectedItemName.text = player.items.InventoryItems[index].Rarity + " " + player.items.InventoryItems[index].Name;
                        selectedItemDescription.text = player.items.InventoryItems[index].GetStatsDescription();
                        if (currentTab == CityTabs.Blacksmith)
                        {
                            Item itemToUpgrade = player.items.InventoryItems[selectedItemIndex];
                            selectedItemBlacksmithDescription.text = player.items.InventoryItems[index].GetStatsDescription();
                            selectedItemBlacksmithUpgrade.text = "Materials required :";
                            foreach (Item item in itemToUpgrade.UpgradeResources)
                            {
                                if (item.Type == ItemType.Misc)
                                {
                                    selectedItemBlacksmithUpgrade.text += "\n- " + item.Amount + "x ";
                                }
                                else
                                {
                                    selectedItemBlacksmithUpgrade.text += "\n- 1x ";
                                }
                                selectedItemBlacksmithUpgrade.text += item.Name;
                            }
                            selectedItemBlacksmithUpgrade.text += "\n" + player.items.InventoryItems[index].nextUpgradeCost + " Gold";
                        }
                    }
                }
            }
        }

        public void ShowSellInfo()
        {
            Item itemToSell = player.items.InventoryItems[selectedItemIndex];
            confirmText.text = "Are you sure that you want to sell " + itemToSell.Rarity + " " + itemToSell.Name + " for " + itemToSell.SellPrice + "?";
            confirmText.transform.parent.gameObject.SetActive(true);
            //confirmText.transform.parent.parent.GetComponent<InformationsUI>().currentType = InformationsUI.InfoTypes.Sell;
        }

        public void ShowDismantleInfo()
        {
            Item itemToDismantle = player.items.InventoryItems[selectedItemIndex];
            confirmText.text = "Are you sure that you want to dismantle " + itemToDismantle.Rarity + " " + itemToDismantle.Name + " ?\nYou will get:";
            if (itemToDismantle.DismantleResources.Length == 0)
            {
                confirmText.text += "\nnothing";
            }
            foreach (Item item in itemToDismantle.DismantleResources)
            {
                if (item.Type == ItemType.Misc)
                {
                    confirmText.text += "\n- " + item.Amount + "x ";
                }
                else
                {
                    confirmText.text += "\n- 1x ";
                }
                confirmText.text += item.Name;
            }
            confirmText.transform.parent.gameObject.SetActive(true);
            //confirmText.transform.parent.parent.GetComponent<InformationsUI>().currentType = InformationsUI.InfoTypes.Dismantle;
        }

        public void DismantleSelectedItem()
        {
            Item itemToDismantle = player.items.InventoryItems[selectedItemIndex];
            if (player.items.InventoryItemSlots - player.items.GetNumberOfInventorySlotsUsed() >= itemToDismantle.DismantleResources.Length - 1)
            {
                player.items.InventoryItems[selectedItemIndex] = null;
                int i = 0;
                int j = 0;
                while (i < itemToDismantle.DismantleResources.Length)
                {
                    if (itemToDismantle.DismantleResources[i].Type == ItemType.Misc)
                    {
                        int k = 0;
                        while (k < player.items.InventoryItemSlots && player.items.InventoryItems[k].Name != itemToDismantle.DismantleResources[i].Name)
                        {
                            k++;
                        }
                        if (player.items.InventoryItems[k] == null)
                        {
                            player.items.InventoryItems[k] = itemToDismantle.DismantleResources[i];
                        }
                        else
                        {
                            player.items.InventoryItems[k].Amount += itemToDismantle.DismantleResources[i].Amount;
                        }
                        i++;
                        j--;
                    }
                    if (player.items.InventoryItems[j] == null)
                    {
                        player.items.InventoryItems[j] = itemToDismantle.DismantleResources[i];
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
            confirmText.transform.parent.gameObject.SetActive(false);
        }

        public void SetItemSlots()
        {
            if (currentTab == CityTabs.Stash)
            {
                for (int i = 0; i < itemSlots.Length; i++)
                {
                    if (i < player.items.StashItemSlots)
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
                    if (i < player.items.InventoryItemSlots)
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
                slotsText.text = "Slots used: " + player.items.GetNumberOfInventorySlotsUsed() + "/" + player.items.InventoryItemSlots;
            }
            else
            {
                ownedMoneyText.text = player.currency.gold.ToString();
                if (player.items.InventoryItems[selectedItemIndex] != null)
                {
                    if (currentTab == CityTabs.Blacksmith)
                    {
                        itemCostText.text = "Upgrade for : " + player.items.InventoryItems[selectedItemIndex].nextUpgradeCost;
                    }
                    else if (currentTab == CityTabs.Sell)
                    {
                        itemCostText.text = "Sell for : " + player.items.InventoryItems[selectedItemIndex].SellPrice;
                    }
                    else
                    {
                        itemCostText.text = "Buy for : " + player.items.InventoryItems[selectedItemIndex].BuyPrice;
                    }
                }
                else
                {
                    itemCostText.text = "";
                }
            }
        }

        public void Button1Use()
        {
            switch (currentTab)
            {
                case CityTabs.Inventory:
                    EquipSelectedItem();
                    break;
                case CityTabs.Sell:
                    ShowSellInfo();
                    break;
                case CityTabs.Buy:
                    //TODO merchantsss
                    break;
                case CityTabs.Blacksmith:
                    //TODO upgrades
                    break;
                case CityTabs.Stash:
                    MoveSelectedItem();
                    break;
                default:
                    break;
            }
        }

        public void Button2Use()
        {
            switch (currentTab)
            {
                case CityTabs.Inventory:
                    MoveSelectedItem();
                    break;
                case CityTabs.Sell:
                    ShowDismantleInfo();
                    break;
                case CityTabs.Blacksmith:
                    ShowDismantleInfo();
                    break;
                default:
                    break;
            }
        }

        private void EquipSelectedItem()
        {
            Item itemToEquip = player.items.InventoryItems[selectedItemIndex];
            if (itemToEquip != null)
            {
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

        public void SellSelectedItem()
        {
            Item itemToSell = player.items.InventoryItems[selectedItemIndex];
            if (itemToSell.Type == ItemType.Misc)
            {
                player.currency.gold += itemToSell.Amount * itemToSell.SellPrice;
            }
            else
            {
                player.currency.gold += itemToSell.SellPrice;
            }
            player.items.InventoryItems[selectedItemIndex] = null;
            SetItemSlots();
            ShowAllItems();
            confirmText.transform.parent.gameObject.SetActive(false);
        }

        private void MoveSelectedItem()
        {
            int slotsUsed;
            int itemSlots;
            Item[] fromItems;
            Item[] toItems;
            if (currentTab == CityTabs.Inventory)
            {
                slotsUsed = player.items.GetNumberOfStashSlotsUsed();
                itemSlots = player.items.StashItemSlots;
                fromItems = player.items.InventoryItems;
                toItems = player.items.StashItems;
            }
            else
            {
                slotsUsed = player.items.GetNumberOfInventorySlotsUsed();
                itemSlots = player.items.InventoryItemSlots;
                fromItems = player.items.StashItems;
                toItems = player.items.InventoryItems;
            }
            if (slotsUsed < itemSlots)
            {
                Item itemToMove = fromItems[selectedItemIndex];
                fromItems[selectedItemIndex] = null;
                toItems[itemSlots - 1] = itemToMove;
                player.items.SortStash();
                player.items.SortInventory();
                ShowAllItems();
            }
            else
            {
                info.text = "Your stash is full!";
                info.transform.parent.gameObject.SetActive(true);
            }
        }

        public void ExitCity()
        {
            OpenInventory();
            gameObject.SetActive(false);
        }
    }
}