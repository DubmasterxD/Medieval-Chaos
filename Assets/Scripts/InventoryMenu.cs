using UnityEngine;

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

    Player player;
    ItemsInventoryMenu itemsInventoryMenu;
    StatsInventoryMenu statsInventoryMenu;
    GalleryInventoryMenu galleryInventoryMenu;
    AchievementsInventoryMenu achievementsInventoryMenu;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        itemsInventoryMenu = FindObjectOfType<ItemsInventoryMenu>();
        statsInventoryMenu = FindObjectOfType<StatsInventoryMenu>();
        galleryInventoryMenu = FindObjectOfType<GalleryInventoryMenu>();
        achievementsInventoryMenu = FindObjectOfType<AchievementsInventoryMenu>();
    }

    public void ShowItemsMenu()
    {
        SetAllTopMenuInactive();
        itemsMenu.SetActive(true);
        itemsMenuButtonHighlight.SetActive(true);
        itemsInventoryMenu.SetItemSlots();
        itemsInventoryMenu.ShowAllItems();
    }

    public void ShowStatsMenu()
    {
        statsInventoryMenu.RefreshStats();
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
        galleryInventoryMenu.ShowAllGallery();
    }

    public void DestroySelectedItem()
    {
        //TODO destroy item
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

    public void CloseWindow()
    {
        inventoryMenu.SetActive(false);
    }
}
