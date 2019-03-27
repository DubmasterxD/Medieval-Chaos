using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu;
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
    [Header("Gallery Menu")]
    [SerializeField] GameObject allGalleryMenuButtonHighlight = null;
    [SerializeField] GameObject weaponGalleryMenuButtonHighlight = null;
    [SerializeField] GameObject armorGalleryMenuButtonHighlight = null;
    [SerializeField] GameObject accessoryGalleryMenuButtonHighlight = null;

    public void ShowItemsMenu()
    {
        SetAllTopMenuInactive();
        itemsMenu.SetActive(true);
        itemsMenuButtonHighlight.SetActive(true);
        ShowAllItems();
    }

    public void ShowStatsMenu()
    {
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
        SetAllItemsMenuHighlightInactive();
        allItemsMenuButtonHighlight.SetActive(true);
    }

    public void ShowWeaponItems()
    {
        SetAllItemsMenuHighlightInactive();
        weaponItemsMenuButtonHighlight.SetActive(true);
    }

    public void ShowArmorItems()
    {
        SetAllItemsMenuHighlightInactive();
        armorItemsMenuButtonHighlight.SetActive(true);
    }

    public void ShowAccessoryItems()
    {
        SetAllItemsMenuHighlightInactive();
        accessoryItemsMenuButtonHighlight.SetActive(true);
    }

    public void ShowMiscItems()
    {
        SetAllItemsMenuHighlightInactive();
        miscItemsMenuButtonHighlight.SetActive(true);
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

    public void CloseWindow()
    {
        ShowItemsMenu();
        inventoryMenu.SetActive(false);
    }
}
