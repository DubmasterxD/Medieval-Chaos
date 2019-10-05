using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [Header("Top Menu")]
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
        itemsInventoryMenu = GetComponentInChildren<ItemsInventoryMenu>();
        statsInventoryMenu = GetComponentInChildren<StatsInventoryMenu>();
        galleryInventoryMenu = GetComponentInChildren<GalleryInventoryMenu>();
        achievementsInventoryMenu = GetComponentInChildren<AchievementsInventoryMenu>();
    }

    public void ShowItemsMenu()
    {
        SetAllTopMenuInactive();
        itemsInventoryMenu.gameObject.SetActive(true);
        itemsMenuButtonHighlight.SetActive(true);
        itemsInventoryMenu.SetItemSlots();
        itemsInventoryMenu.ShowAllItems();
    }

    public void ShowStatsMenu()
    {
        statsInventoryMenu.RefreshStats();
        SetAllTopMenuInactive();
        statsInventoryMenu.gameObject.SetActive(true);
        statsMenuButtonHighlight.SetActive(true);
    }

    public void ShowAchievementsMenu()
    {
        SetAllTopMenuInactive();
        achievementsInventoryMenu.gameObject.SetActive(true);
        achievementsMenuButtonHighlight.SetActive(true);
    }

    public void ShowGalleryMenu()
    {
        SetAllTopMenuInactive();
        galleryInventoryMenu.gameObject.SetActive(true);
        galleryMenuButtonHighlight.SetActive(true);
        galleryInventoryMenu.ShowAllGallery();
    }

    public void DestroySelectedItem()
    {
        //TODO destroy item
    }

    private void SetAllTopMenuInactive()
    {
        itemsInventoryMenu.gameObject.SetActive(false);
        itemsMenuButtonHighlight.SetActive(false);
        statsInventoryMenu.gameObject.SetActive(false);
        statsMenuButtonHighlight.SetActive(false);
        achievementsInventoryMenu.gameObject.SetActive(false);
        achievementsMenuButtonHighlight.SetActive(false);
        galleryInventoryMenu.gameObject.SetActive(false);
        galleryMenuButtonHighlight.SetActive(false);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
