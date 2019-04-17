using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu = null;
    [Header("Top Menu")]
    [SerializeField] GameObject itemsMenu = null;
    [SerializeField] GameObject statsMenu = null;
    [SerializeField] GameObject achievementsMenu = null;
    [SerializeField] GameObject galleryMenu = null;
    [SerializeField] GameObject itemsMenuButtonHighlight = null;
    [SerializeField] GameObject statsMenuButtonHighlight = null;
    [SerializeField] GameObject achievementsMenuButtonHighlight = null;
    [SerializeField] GameObject galleryMenuButtonHighlight = null;
    [Header("Items Menu")]
    [SerializeField] GameObject allItemsMenuButtonHighlight = null;
    [SerializeField] GameObject weaponItemsMenuButtonHighlight = null;
    [SerializeField] GameObject armorItemsMenuButtonHighlight = null;
    [SerializeField] GameObject accessoryItemsMenuButtonHighlight = null;
    [SerializeField] GameObject miscItemsMenuButtonHighlight = null;
    [SerializeField] Text SlotsText = null;
    [SerializeField] GameObject[] itemSlots = null;
    [SerializeField] Image selectedItemImage = null;
    [SerializeField] Text selectedItemName = null;
    [SerializeField] Text selectedItemDescription = null;
    [Header("Stats Menu")]
    [SerializeField] Text nicknameText = null;
    [SerializeField] Text levelText = null;
    [SerializeField] Text expValueText = null;
    [SerializeField] Slider expSlider = null;
    [SerializeField] Text goldText = null;
    [SerializeField] Text attackStatsText = null;
    [SerializeField] Text defenceStatsText = null;
    [SerializeField] Text specialStatsText = null;
    [Header("Gallery Menu")]
    [SerializeField] GameObject allGalleryMenuButtonHighlight = null;
    [SerializeField] GameObject weaponGalleryMenuButtonHighlight = null;
    [SerializeField] GameObject armorGalleryMenuButtonHighlight = null;
    [SerializeField] GameObject accessoryGalleryMenuButtonHighlight = null;
    [Header("Info")]
    [SerializeField] Text info = null;
    [SerializeField] Text DismantleInfo = null;
    int selectedItemIndex = 0;

    private PlayerStats playerStats;
    private ItemsList playerItems;

    private void Start()
    {
        playerStats = Player.instance.stats;
        playerItems = Player.instance.items;
    }

    public void ShowItemsMenu()
    {
        SetAllTopMenuInactive();
        itemsMenu.SetActive(true);
        itemsMenuButtonHighlight.SetActive(true);
        SetItemSlots();
        ShowAllItems();
    }

    public void SetItemSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < playerItems.ItemSlots)
            {
                itemSlots[i].SetActive(true);
            }
            else
            {
                itemSlots[i].SetActive(false);
            }
        }
        SlotsText.text = "Slots used: " + playerItems.GetNumberOfSlotsUsed() + "/" + playerItems.ItemSlots;
    }

    public void ShowStatsMenu()
    {
        RefreshStats();
        SetAllTopMenuInactive();
        statsMenu.SetActive(true);
        statsMenuButtonHighlight.SetActive(true);
    }

    public void ShowAchievementsMenu()
    {
        SetAllTopMenuInactive();
        achievementsMenu.SetActive(true);
        achievementsMenuButtonHighlight.SetActive(true);
    }

    public void ShowGalleryMenu()
    {
        SetAllTopMenuInactive();
        galleryMenu.SetActive(true);
        galleryMenuButtonHighlight.SetActive(true);
        ShowAllGallery();
    }

    public void ShowAllItems()
    {
        playerItems.SortInventory();
        SetAllItemsMenuHighlightInactive();
        allItemsMenuButtonHighlight.SetActive(true);
        for (int i = 0; i < playerItems.ItemSlots; i++)
        {
            itemSlots[i].GetComponentInChildren<Text>().text = "";
            if (playerItems.InventoryItems[i] == null)
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].sprite = null;
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].sprite = playerItems.InventoryItems[i].Image;
                if (playerItems.InventoryItems[i].Type == ItemsList.itemTypes.Misc)
                {
                    itemSlots[i].GetComponentInChildren<Text>().text = playerItems.InventoryItems[i].Amount.ToString();
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
        bool selected = false;
        for (int i = 0; i < playerItems.ItemSlots; i++)
        {
            if (playerItems.InventoryItems[i] == null || (playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Weapon && playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Shield))
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.white;
                if (selected == false)
                {
                    SelectItem(i);
                    selected = true;
                }
            }
        }
    }

    public void ShowArmorItems()
    {
        SetAllItemsMenuHighlightInactive();
        armorItemsMenuButtonHighlight.SetActive(true);
        bool selected = false;
        for (int i = 0; i < playerItems.ItemSlots; i++)
        {
            if (playerItems.InventoryItems[i] == null || (playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Armor && playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Helmet && playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Boots && playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Gloves))
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.white;
                if (selected == false)
                {
                    SelectItem(i);
                    selected = true;
                }
            }
        }
    }

    public void ShowAccessoryItems()
    {
        SetAllItemsMenuHighlightInactive();
        accessoryItemsMenuButtonHighlight.SetActive(true);
        bool selected = false;
        for (int i = 0; i < playerItems.ItemSlots; i++)
        {
            if (playerItems.InventoryItems[i] == null || (playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Artifact && playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Neckle && playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Ring))
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.white;
                if (selected == false)
                {
                    SelectItem(i);
                    selected = true;
                }
            }
        }
    }

    public void ShowMiscItems()
    {
        SetAllItemsMenuHighlightInactive();
        miscItemsMenuButtonHighlight.SetActive(true);
        bool selected = false;
        for (int i = 0; i < playerItems.ItemSlots; i++)
        {
            if (playerItems.InventoryItems[i] == null || (playerItems.InventoryItems[i].Type != ItemsList.itemTypes.Misc))
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.white;
                if (selected == false)
                {
                    SelectItem(i);
                    selected = true;
                }
            }
        }
    }

    public void EquipSelectedItem()
    {
        Item itemToEquip = playerItems.InventoryItems[selectedItemIndex];
        if (itemToEquip.Level > playerStats.Level)
        {
            info.text = "Your level is too low to equip this " + itemToEquip.Type.ToString() + ".";
            info.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            playerItems.EquipItem(selectedItemIndex);
            SetItemSlots();
            ShowAllItems();
        }
    }

    public void ShowDismantleInfo()
    {
        Item itemToDismantle = playerItems.InventoryItems[selectedItemIndex];
        DismantleInfo.text = "Are you sure that you want to dismantle " + itemToDismantle.Rarity + " " + itemToDismantle.Name + " ?\nYou will get:";
        if(itemToDismantle.DismantleResources.Length==0)
        {
            DismantleInfo.text += "\nnothing";
        }
        foreach(Item item in itemToDismantle.DismantleResources)
        {
            if(item.Type== ItemsList.itemTypes.Misc)
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
        if (playerItems.ItemSlots - playerItems.GetNumberOfSlotsUsed() >= itemToDismantle.DismantleResources.Length - 1)
        {
            playerItems.InventoryItems[selectedItemIndex] = null;
            int i = 0;
            int j = 0;
            while(i<itemToDismantle.DismantleResources.Length)
            {
                if(itemToDismantle.DismantleResources[i].Type== ItemsList.itemTypes.Misc)
                {
                    int k = 0;
                    while(k<playerItems.ItemSlots && playerItems.InventoryItems[k].Name!=itemToDismantle.DismantleResources[i].Name)
                    {
                        k++;
                    }
                    if(playerItems.InventoryItems[k]==null)
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
                if(playerItems.InventoryItems[j]==null)
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

    public void ShowAllGallery()
    {
        SetAllGalleryMenuHighlightInactive();
        allGalleryMenuButtonHighlight.SetActive(true);
    }

    public void ShowWeaponGallery()
    {
        SetAllGalleryMenuHighlightInactive();
        weaponGalleryMenuButtonHighlight.SetActive(true);
    }

    public void ShowArmorGallery()
    {
        SetAllGalleryMenuHighlightInactive();
        armorGalleryMenuButtonHighlight.SetActive(true);
    }

    public void ShowAccessoryGallery()
    {
        SetAllGalleryMenuHighlightInactive();
        accessoryGalleryMenuButtonHighlight.SetActive(true);
    }

    private void SetAllTopMenuInactive()
    {
        itemsMenu.SetActive(false);
        itemsMenuButtonHighlight.SetActive(false);
        statsMenu.SetActive(false);
        statsMenuButtonHighlight.SetActive(false);
        achievementsMenu.SetActive(false);
        achievementsMenuButtonHighlight.SetActive(false);
        galleryMenu.SetActive(false);
        galleryMenuButtonHighlight.SetActive(false);
    }

    private void SetAllItemsMenuHighlightInactive()
    {
        allItemsMenuButtonHighlight.SetActive(false);
        weaponItemsMenuButtonHighlight.SetActive(false);
        armorItemsMenuButtonHighlight.SetActive(false);
        accessoryItemsMenuButtonHighlight.SetActive(false);
        miscItemsMenuButtonHighlight.SetActive(false);
    }

    private void SetAllGalleryMenuHighlightInactive()
    {
        allGalleryMenuButtonHighlight.SetActive(false);
        weaponGalleryMenuButtonHighlight.SetActive(false);
        armorGalleryMenuButtonHighlight.SetActive(false);
        accessoryGalleryMenuButtonHighlight.SetActive(false);
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
            }
            else
            {
                selectedItemImage.sprite = playerItems.InventoryItems[index].Image;
                selectedItemName.text = playerItems.InventoryItems[index].Rarity + " " + playerItems.InventoryItems[index].Name;
                selectedItemDescription.text = playerItems.InventoryItems[index].GetStatsDescription();
            }
        }
    }

    private void RefreshStats()
    {
        RefreshProfileStats();
        RefreshAttackStats();
        RefreshDefenceStats();
        RefreshSpecialStats();
    }

    private void RefreshProfileStats()
    {
        nicknameText.text = Player.instance.Nickname;
        levelText.text = "Lvl: " + playerStats.Level;
        expValueText.text = playerStats.currExp + "/" + playerStats.expToNextLevel;
        expSlider.value = playerStats.currExp / playerStats.expToNextLevel;
        goldText.text = Player.instance.currency.gold.ToString();
    }

    private void RefreshAttackStats()
    {
        attackStatsText.text = "Damage: " + playerStats.MinDamage + " - " + playerStats.MaxDamage;
        attackStatsText.text += "\nAttack Speed: " + playerStats.AttackSpeed;
        if (playerStats.CritChance != 0)
        {
            attackStatsText.text += "\nCritical Hit Chance: " + (playerStats.CritChance * 100) + "%";
            attackStatsText.text += "\nCritical Hit Multiplier: " + playerStats.CritMultiplier;
        }
        if (playerStats.ArmorPenetration != 0)
        {
            attackStatsText.text += "\nArmor Penetration: " + playerStats.ArmorPenetration;
        }
        if (playerStats.Element != PlayerStats.elementals.None)
        {
            attackStatsText.text += "\n" + playerStats.Element.ToString() + " Damage: " + playerStats.MinElementalDamage + " - " + playerStats.MaxElementalDamage;
            attackStatsText.text += "\nPhysical To " + playerStats.Element + " Damage: " + playerStats.PhysicalToElementalDamage;
        }
    }

    private void RefreshDefenceStats()
    {
        defenceStatsText.text = "Health: " + playerStats.MaxHP;
        defenceStatsText.text += "\nArmor: " + playerStats.Armor;
        if (playerStats.ChanceToBlock != 0)
        {
            defenceStatsText.text += "\nChance To Block: " + (playerStats.ChanceToBlock * 100) + "%";
        }
        if (playerStats.CritResist != 0)
        {
            defenceStatsText.text += "\nCritical Damage Resists: " + (playerStats.CritResist * 100) + "%";
        }
        defenceStatsText.text += "\nFire Resists: " + (playerStats.FireResist * 100) + "%";
        defenceStatsText.text += "\nIce Resists: " + (playerStats.IceResist * 100) + "%";
        defenceStatsText.text += "\nEarth Resists: " + (playerStats.EarthResist * 100) + "%";
    }

    private void RefreshSpecialStats()
    {
        specialStatsText.text = "";
        if (playerStats.LifeSteal != 0)
        {
            specialStatsText.text = "\nLife Steal: " + (playerStats.LifeSteal * 100) + "%";
        }
        if (playerStats.DamageReflected != 0)
        {
            specialStatsText.text += "\nDamage Reflection: " + (playerStats.DamageReflected * 100) + "%";
        }
        if (playerStats.ChanceToSurviveOn1HP != 0)
        {
            specialStatsText.text += "\nChance To Cheat Death: " + (playerStats.ChanceToSurviveOn1HP * 100) + "%";
        }
        if (playerStats.ChanceToGainShield != 0)
        {
            specialStatsText.text += "\nChance To Gain Shield: " + (playerStats.ChanceToGainShield * 100) + "%";
            specialStatsText.text += "\nAmount Of Gained Shield: " + playerStats.MaxShield;
        }
        if (specialStatsText.text != "")
        {
            specialStatsText.text = specialStatsText.text.Remove(0, 1);
        }
    }

    public void CloseWindow()
    {
        inventoryMenu.SetActive(false);
    }
}
