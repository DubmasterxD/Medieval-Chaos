using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideMenu : MonoBehaviour
{
    Player player;

    [SerializeField] GameObject itemsSideMenu = null;
    [SerializeField] GameObject infoSideMenu = null;
    [SerializeField] GameObject inventoryMenu = null;
    [SerializeField] GameObject itemEquipMenu = null;
    [SerializeField] GameObject actionMenu = null;
    [SerializeField] GameObject questLogMenu = null;
    [Header("Equipped items")]
    [SerializeField] Image WeaponSlot = null;
    [SerializeField] Image ArmorSlot = null;
    [SerializeField] Image ShieldSlot = null;
    [SerializeField] Image NeckleSlot = null;
    [SerializeField] Image RingSlot = null;
    [SerializeField] Image HelmetSlot = null;
    [SerializeField] Image BootsSlot = null;
    [SerializeField] Image GlovesSlot = null;
    [SerializeField] Image ArtifactSlot = null;
    [SerializeField] Text selectedItemInfo = null;
    ItemsList items;

    private void Start()
    {
        player = Player.instance;
        items = player.GetComponent<ItemsList>();
        ShowEquippedItems();
    }

    public void ShowItemInfo(string itemType)
    {
        itemsSideMenu.SetActive(false);
        infoSideMenu.SetActive(true);
        switch (itemType)
        {
            case "Weapon":
                if(items.EquippedWeapon==null)
                {
                    selectedItemInfo.text = "No weapon equipped";
                }
                else
                {
                    selectedItemInfo.text = items.EquippedWeapon.GetStatsDescription();
                }
                break;
            case "Armor":
                if (items.EquippedArmor == null)
                {
                    selectedItemInfo.text = "No armor equipped";
                }
                else
                {
                    selectedItemInfo.text = items.EquippedArmor.GetStatsDescription();
                }
                break;
            case "Shield":
                if (items.EquippedShield == null)
                {
                    selectedItemInfo.text = "No shield equipped";
                }
                else
                {
                    selectedItemInfo.text = items.EquippedShield.GetStatsDescription();
                }
                break;
            case "Neckle":
                if (items.EquippedNeckle == null)
                {
                    selectedItemInfo.text = "No neckle equipped";
                }
                else
                {
                    selectedItemInfo.text = items.EquippedNeckle.GetStatsDescription();
                }
                break;
            case "Ring":
                if (items.EquippedRing == null)
                {
                    selectedItemInfo.text = "No ring equipped";
                }
                else
                {
                    selectedItemInfo.text = items.EquippedRing.GetStatsDescription();
                }
                break;
            case "Helmet":
                if (items.EquippedHelmet == null)
                {
                    selectedItemInfo.text = "No helmet equipped";
                }
                else
                {
                    selectedItemInfo.text = items.EquippedHelmet.GetStatsDescription();
                }
                break;
            case "Boots":
                if (items.EquippedBoots == null)
                {
                    selectedItemInfo.text = "No boots equipped";
                }
                else
                {
                    selectedItemInfo.text = items.EquippedBoots.GetStatsDescription();
                }
                break;
            case "Gloves":
                if (items.EquippedGloves == null)
                {
                    selectedItemInfo.text = "No gloves equipped";
                }
                else
                {
                    selectedItemInfo.text = items.EquippedGloves.GetStatsDescription();
                }
                break;
            case "Artifact":
                if (items.EquippedArtifact == null)
                {
                    selectedItemInfo.text = "No artifact equipped";
                }
                else
                {
                    selectedItemInfo.text = items.EquippedArtifact.GetStatsDescription();
                }
                break;
            default:
                break;
        }
    }

    public void ShowEquippedItems()
    {
        itemsSideMenu.SetActive(true);
        infoSideMenu.SetActive(false);
        WeaponSlot.gameObject.SetActive(false);
        ArmorSlot.gameObject.SetActive(false);
        ShieldSlot.gameObject.SetActive(false);
        NeckleSlot.gameObject.SetActive(false);
        RingSlot.gameObject.SetActive(false);
        HelmetSlot.gameObject.SetActive(false);
        BootsSlot.gameObject.SetActive(false);
        GlovesSlot.gameObject.SetActive(false);
        ArtifactSlot.gameObject.SetActive(false);
        if (items.EquippedWeapon != null)
        {
            WeaponSlot.gameObject.SetActive(true);
            WeaponSlot.sprite = items.EquippedWeapon.Image;
        }
        if (items.EquippedArmor != null)
        {
            ArmorSlot.gameObject.SetActive(true);
            ArmorSlot.sprite = items.EquippedArmor.Image;
        }
        if (items.EquippedShield != null)
        {
            ShieldSlot.gameObject.SetActive(true);
            ShieldSlot.sprite = items.EquippedShield.Image;
        }
        if (items.EquippedNeckle != null)
        {
            NeckleSlot.gameObject.SetActive(true);
            NeckleSlot.sprite = items.EquippedNeckle.Image;
        }
        if (items.EquippedRing != null)
        {
            RingSlot.gameObject.SetActive(true);
            RingSlot.sprite = items.EquippedRing.Image;
        }
        if (items.EquippedHelmet != null)
        {
            HelmetSlot.gameObject.SetActive(true);
            HelmetSlot.sprite = items.EquippedHelmet.Image;
        }
        if (items.EquippedBoots != null)
        {
            BootsSlot.gameObject.SetActive(true);
            BootsSlot.sprite = items.EquippedBoots.Image;
        }
        if (items.EquippedGloves != null)
        {
            GlovesSlot.gameObject.SetActive(true);
            GlovesSlot.sprite = items.EquippedGloves.Image;
        }
        if (items.EquippedArtifact != null)
        {
            ArtifactSlot.gameObject.SetActive(true);
            ArtifactSlot.sprite = items.EquippedArtifact.Image;
        }
    }

    public void OpenItemChangeMenu()
    {
        if (!player.movement.isMoving)
        {
            ShowEquippedItems();
            itemEquipMenu.SetActive(true);
        }
    }

    public void OpenInventory()
    {
        if (!player.movement.isMoving)
        {
            inventoryMenu.SetActive(true);
            gameObject.transform.parent.GetComponentInChildren<InventoryMenu>().ShowItemsMenu();
        }
    }

    public void OpenQuestLog()
    {
        if (!player.movement.isMoving)
        {
            questLogMenu.SetActive(true);
            gameObject.transform.parent.GetComponentInChildren<QuestLogMenu>().ShowMainQuests();
        }
    }
    
    public void OpenActionDetailsMenu()
    {
        if (!player.movement.isMoving)
        {
            actionMenu.SetActive(true);
        }
    }
}
