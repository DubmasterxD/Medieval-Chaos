using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [Header("Overlay")]
    [SerializeField] GameObject overlayMenu = null;
    [SerializeField] GameObject profileMenu = null;
    [SerializeField] GameObject topMenu = null;
    [SerializeField] GameObject sideMenu = null;
    [SerializeField] GameObject arrowsMenu = null;
    [SerializeField] GameObject minimapMenu = null;

    ProfileMenu profileMenuScript = null;
    TopMenu topMenuScript = null;
    SideMenu sideMenuScript = null;
    MoveArrows arrowsMenuScript = null;

    [Header("Windows")]
    [SerializeField] GameObject windowsMenu = null;
    [SerializeField] GameObject settingsMenu = null;
    [SerializeField] GameObject premiumShopMenu = null;
    [SerializeField] GameObject itemEquipMenu = null;
    [SerializeField] GameObject inventoryMenu = null;
    [SerializeField] GameObject questLogMenu = null;

    ItemEquipMenu itemEquipMenuScript = null;
    InventoryMenu inventoryMenuScript = null;
    ItemsInventoryMenu itemsInventoryMenuScript = null;
    StatsInventoryMenu statsInventoryMenuScript = null;
    AchievementsInventoryMenu achievementsInventoryMenuScript = null;
    GalleryInventoryMenu galleryInventoryMenuScript = null;
    QuestLogMenu questLogMenuScript = null;

    [Header("City")]
    [SerializeField] GameObject cityMenu = null;

    CityMenu cityMenuScript = null;
    ItemsCityMenu itemsCityMenuScript = null;
    ShopCityMenu shopCityMenuScript = null;
    BlacksmithCityMenu blacksmithCityMenuScript = null;
    StashCityMenu stashCityMenuScript = null;

    [Header("Map")]
    [SerializeField] GameObject mapMenu = null;

    [Header("Action")]
    [SerializeField] GameObject actionMenu = null;
    [SerializeField] GameObject actionInfoMenu = null;
    [SerializeField] GameObject fightMenu = null;
    [SerializeField] GameObject treasureMenu = null;
    [SerializeField] GameObject rewardMenu = null;

    ActionMenu actionMenuScript = null;

    [Header("Quest")]
    [SerializeField] GameObject questMenu = null;

    [Header("Informations")]
    [SerializeField] GameObject informationsMenu = null;
    [SerializeField] GameObject confirmInfoMenu = null;
    [SerializeField] GameObject infoMenu = null;

    InformationsMenu informationsMenuScript = null;

    public GameObject OverlayMenu { get => overlayMenu; set => overlayMenu = value; }
    public GameObject ProfileMenu { get => profileMenu; set => profileMenu = value; }
    public GameObject TopMenu { get => topMenu; set => topMenu = value; }
    public GameObject SideMenu { get => sideMenu; set => sideMenu = value; }
    public GameObject ArrowsMenu { get => arrowsMenu; set => arrowsMenu = value; }
    public GameObject MinimapMenu { get => minimapMenu; set => minimapMenu = value; }
    public ProfileMenu ProfileMenuScript { get => profileMenuScript; set => profileMenuScript = value; }
    public TopMenu TopMenuScript { get => topMenuScript; set => topMenuScript = value; }
    public SideMenu SideMenuScript { get => sideMenuScript; set => sideMenuScript = value; }
    public MoveArrows ArrowsMenuScript { get => arrowsMenuScript; set => arrowsMenuScript = value; }
    public GameObject WindowsMenu { get => windowsMenu; set => windowsMenu = value; }
    public GameObject SettingsMenu { get => settingsMenu; set => settingsMenu = value; }
    public GameObject PremiumShopMenu { get => premiumShopMenu; set => premiumShopMenu = value; }
    public GameObject ItemEquipMenu { get => itemEquipMenu; set => itemEquipMenu = value; }
    public GameObject InventoryMenu { get => inventoryMenu; set => inventoryMenu = value; }
    public GameObject QuestLogMenu { get => questLogMenu; set => questLogMenu = value; }
    public ItemEquipMenu ItemEquipMenuScript { get => itemEquipMenuScript; set => itemEquipMenuScript = value; }
    public InventoryMenu InventoryMenuScript { get => inventoryMenuScript; set => inventoryMenuScript = value; }
    public ItemsInventoryMenu ItemsInventoryMenuScript { get => itemsInventoryMenuScript; set => itemsInventoryMenuScript = value; }
    public StatsInventoryMenu StatsInventoryMenuScript { get => statsInventoryMenuScript; set => statsInventoryMenuScript = value; }
    public AchievementsInventoryMenu AchievementsInventoryMenuScript { get => achievementsInventoryMenuScript; set => achievementsInventoryMenuScript = value; }
    public GalleryInventoryMenu GalleryInventoryMenuScript { get => galleryInventoryMenuScript; set => galleryInventoryMenuScript = value; }
    public QuestLogMenu QuestLogMenuScript { get => questLogMenuScript; set => questLogMenuScript = value; }
    public GameObject CityMenu { get => cityMenu; set => cityMenu = value; }
    public CityMenu CityMenuScript { get => cityMenuScript; set => cityMenuScript = value; }
    public ItemsCityMenu ItemsCityMenuScript { get => itemsCityMenuScript; set => itemsCityMenuScript = value; }
    public ShopCityMenu ShopCityMenuScript { get => shopCityMenuScript; set => shopCityMenuScript = value; }
    public BlacksmithCityMenu BlacksmithCityMenuScript { get => blacksmithCityMenuScript; set => blacksmithCityMenuScript = value; }
    public StashCityMenu StashCityMenuScript { get => stashCityMenuScript; set => stashCityMenuScript = value; }
    public GameObject MapMenu { get => mapMenu; set => mapMenu = value; }
    public GameObject ActionMenu { get => actionMenu; set => actionMenu = value; }
    public GameObject ActionInfoMenu { get => actionInfoMenu; set => actionInfoMenu = value; }
    public GameObject FightMenu { get => fightMenu; set => fightMenu = value; }
    public GameObject TreasureMenu { get => treasureMenu; set => treasureMenu = value; }
    public GameObject RewardMenu { get => rewardMenu; set => rewardMenu = value; }
    public ActionMenu ActionMenuScript { get => actionMenuScript; set => actionMenuScript = value; }
    public GameObject QuestMenu { get => questMenu; set => questMenu = value; }
    public GameObject InformationsMenu { get => informationsMenu; set => informationsMenu = value; }
    public GameObject ConfirmInfoMenu { get => confirmInfoMenu; set => confirmInfoMenu = value; }
    public GameObject InfoMenu { get => infoMenu; set => infoMenu = value; }
    public InformationsMenu InformationsMenuScript { get => informationsMenuScript; set => informationsMenuScript = value; }

    private void Awake()
    {
        SetScripts();
    }

    private void SetScripts()
    {
        achievementsInventoryMenuScript = windowsMenu.GetComponent<AchievementsInventoryMenu>();
        actionMenuScript=actionMenu.GetComponent<ActionMenu>();
        arrowsMenuScript=overlayMenu.GetComponent<MoveArrows>();
        blacksmithCityMenuScript=cityMenu.GetComponent<BlacksmithCityMenu>();
        cityMenuScript=cityMenu.GetComponent<CityMenu>();
        galleryInventoryMenuScript=windowsMenu.GetComponent<GalleryInventoryMenu>();
        informationsMenuScript=informationsMenu.GetComponent<InformationsMenu>();
        inventoryMenuScript=windowsMenu.GetComponent<InventoryMenu>();
        itemEquipMenuScript=windowsMenu.GetComponent<ItemEquipMenu>();
        itemsCityMenuScript=cityMenu.GetComponent<ItemsCityMenu>();
        itemsInventoryMenuScript=windowsMenu.GetComponent<ItemsInventoryMenu>();
        profileMenuScript=overlayMenu.GetComponent<ProfileMenu>();
        questLogMenuScript=windowsMenu.GetComponent<QuestLogMenu>();
        shopCityMenuScript=cityMenu.GetComponent<ShopCityMenu>();
        sideMenuScript=overlayMenu.GetComponent<SideMenu>();
        stashCityMenuScript=cityMenu.GetComponent<StashCityMenu>();
        statsInventoryMenuScript=windowsMenu.GetComponent<StatsInventoryMenu>();
        topMenuScript = overlayMenu.GetComponent<TopMenu>();
    }
}
