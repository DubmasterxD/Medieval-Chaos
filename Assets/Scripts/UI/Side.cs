using UnityEngine;
using UnityEngine.UI;
using Medieval.Core;
using Medieval.Player;
using Medieval.Map;

namespace Medieval.UI
{
    public class Side : MonoBehaviour
    {
        Manager player;

        [SerializeField] GameObject inventoryMenu = null;
        [SerializeField] GameObject itemEquipMenu = null;
        [SerializeField] GameObject actionMenu = null;
        [SerializeField] GameObject questLogMenu = null;
        [SerializeField] GameObject cityMenu = null;
        [SerializeField] GameObject actionButton = null;
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

        GameObject actionInfo = null;
        GameObject actionFight = null;
        GameObject actionTreasure = null;
        Player.Items items;
        Actions actions;

        public GameObject ActionButton { get => actionButton; }

        private void Start()
        {
            player = FindObjectOfType<Manager>();
            actions = FindObjectOfType<Actions>();
            actionInfo = actionMenu.GetComponent<Action>().ActionInfo;
            actionFight = actionMenu.GetComponent<Action>().ActionFight;
            actionTreasure = actionMenu.GetComponent<Action>().ActionTreasure;
            items = player.GetComponent<Player.Items>();
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
                ItemType selectedItemType = default;
                switch (itemType)
                {
                    case "Weapon":
                        selectedItemType = ItemType.Weapon;
                        break;
                    case "Armor":
                        selectedItemType = ItemType.Armor;
                        break;
                    case "Shield":
                        selectedItemType = ItemType.Shield;
                        break;
                    case "Neckle":
                        selectedItemType = ItemType.Neckle;
                        break;
                    case "Ring":
                        selectedItemType = ItemType.Ring;
                        break;
                    case "Helmet":
                        selectedItemType = ItemType.Helmet;
                        break;
                    case "Boots":
                        selectedItemType = ItemType.Boots;
                        break;
                    case "Gloves":
                        selectedItemType = ItemType.Gloves;
                        break;
                    case "Artifact":
                        selectedItemType = ItemType.Artifact;
                        break;
                    default:
                        break;
                }
                gameObject.transform.parent.gameObject.GetComponentInChildren<ItemEquip>().LoadInfo(selectedItemType);
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

        public void ActionButtonPress()
        {
            if (actions.isBossNearby)
            {
                actionInfo.SetActive(true);
            }
            else if (actions.isInCity)
            {
                cityMenu.SetActive(true);
            }
            else if (actions.isSpecialEncounter)
            {
                actionInfo.SetActive(true);
            }
            else if (actions.isTreasure)
            {
                actionInfo.SetActive(true);
            }
            else
            {
                actionInfo.SetActive(true);
            }
        }
    }
}