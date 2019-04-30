using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideMenu : MonoBehaviour
{
    Player player;
    
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
    ItemsList items;

    private void Start()
    {
        player = Player.instance;
        items = player.GetComponent<ItemsList>();
        ShowEquippedItems();
    }

    public void ShowEquippedItems()
    {
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

    public void OpenItemChangeMenu(string itemType)
    {
        if (!player.movement.isMoving)
        {
            ItemsList.itemTypes selectedItemType = default;
            switch (itemType)
            {
                case "Weapon":
                    selectedItemType = ItemsList.itemTypes.Weapon;
                    break;
                case "Armor":
                    selectedItemType = ItemsList.itemTypes.Armor;
                    break;
                case "Shield":
                    selectedItemType = ItemsList.itemTypes.Shield;
                    break;
                case "Neckle":
                    selectedItemType = ItemsList.itemTypes.Neckle;
                    break;
                case "Ring":
                    selectedItemType = ItemsList.itemTypes.Ring;
                    break;
                case "Helmet":
                    selectedItemType = ItemsList.itemTypes.Helmet;
                    break;
                case "Boots":
                    selectedItemType = ItemsList.itemTypes.Boots;
                    break;
                case "Gloves":
                    selectedItemType = ItemsList.itemTypes.Gloves;
                    break;
                case "Artifact":
                    selectedItemType = ItemsList.itemTypes.Artifact;
                    break;
                default:
                    break;
            }
            gameObject.transform.parent.gameObject.GetComponentInChildren<ItemEquipMenu>().LoadInfo(selectedItemType);
            itemEquipMenu.SetActive(true);
        }
    }

    public void OpenInventory()
    {
        if (!player.movement.isMoving)
        {
            inventoryMenu.SetActive(true);
        }
    }

    public void OpenQuestLog()
    {
        if (!player.movement.isMoving)
        {
            questLogMenu.SetActive(true);
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
