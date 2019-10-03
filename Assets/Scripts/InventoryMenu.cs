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
    [SerializeField] Text slotsText = null;
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
    int selectedItemIndex = 0;

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
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

    public void DestroySelectedItem()
    {
        //TODO destroy item
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

    private void RefreshStats()
    {
        RefreshProfileStats();
        RefreshAttackStats();
        RefreshDefenceStats();
        RefreshSpecialStats();
    }

    private void RefreshProfileStats()
    {
        nicknameText.text = player.Nickname;
        levelText.text = "Lvl: " + player.stats.Level;
        expValueText.text = player.stats.currExp + "/" + player.stats.expToNextLevel;
        expSlider.value = player.stats.currExp / player.stats.expToNextLevel;
        goldText.text = player.currency.gold.ToString();
    }

    private void RefreshAttackStats()
    {
        attackStatsText.text = "Damage: " + player.stats.MinDamage + " - " + player.stats.MaxDamage;
        attackStatsText.text += "\nAttack Speed: " + player.stats.AttackSpeed;
        if (player.stats.CritChance != 0)
        {
            attackStatsText.text += "\nCritical Hit Chance: " + (player.stats.CritChance * 100) + "%";
            attackStatsText.text += "\nCritical Hit Multiplier: " + player.stats.CritMultiplier;
        }
        if (player.stats.ArmorPenetration != 0)
        {
            attackStatsText.text += "\nArmor Penetration: " + player.stats.ArmorPenetration;
        }
        if (player.stats.Element != PlayerStats.elementals.None)
        {
            attackStatsText.text += "\n" + player.stats.Element.ToString() + " Damage: " + player.stats.MinElementalDamage + " - " + player.stats.MaxElementalDamage;
            attackStatsText.text += "\nPhysical To " + player.stats.Element + " Damage: " + player.stats.PhysicalToElementalDamage;
        }
    }

    private void RefreshDefenceStats()
    {
        defenceStatsText.text = "Health: " + player.stats.MaxHP;
        defenceStatsText.text += "\nArmor: " + player.stats.Armor;
        if (player.stats.ChanceToBlock != 0)
        {
            defenceStatsText.text += "\nChance To Block: " + (player.stats.ChanceToBlock * 100) + "%";
        }
        if (player.stats.CritResist != 0)
        {
            defenceStatsText.text += "\nCritical Damage Resists: " + (player.stats.CritResist * 100) + "%";
        }
        defenceStatsText.text += "\nFire Resists: " + (player.stats.FireResist * 100) + "%";
        defenceStatsText.text += "\nIce Resists: " + (player.stats.IceResist * 100) + "%";
        defenceStatsText.text += "\nEarth Resists: " + (player.stats.EarthResist * 100) + "%";
    }

    private void RefreshSpecialStats()
    {
        specialStatsText.text = "";
        if (player.stats.LifeSteal != 0)
        {
            specialStatsText.text = "\nLife Steal: " + (player.stats.LifeSteal * 100) + "%";
        }
        if (player.stats.DamageReflected != 0)
        {
            specialStatsText.text += "\nDamage Reflection: " + (player.stats.DamageReflected * 100) + "%";
        }
        if (player.stats.ChanceToSurviveOn1HP != 0)
        {
            specialStatsText.text += "\nChance To Cheat Death: " + (player.stats.ChanceToSurviveOn1HP * 100) + "%";
        }
        if (player.stats.ChanceToGainShield != 0)
        {
            specialStatsText.text += "\nChance To Gain Shield: " + (player.stats.ChanceToGainShield * 100) + "%";
            specialStatsText.text += "\nAmount Of Gained Shield: " + player.stats.MaxShield;
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
