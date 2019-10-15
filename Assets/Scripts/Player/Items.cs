using UnityEngine;
using Medieval.Core;
using Medieval.UI;

namespace Medieval.Player
{
    public class Items : MonoBehaviour
    {
        [SerializeField] int inventoryItemSlots = 50;
        [SerializeField] int stashItemSlots = 10;
        [SerializeField] Item equippedWeapon = null;
        [SerializeField] Item equippedArmor = null;
        [SerializeField] Item equippedShield = null;
        [SerializeField] Item equippedRing = null;
        [SerializeField] Item equippedNeckle = null;
        [SerializeField] Item equippedBoots = null;
        [SerializeField] Item equippedGloves = null;
        [SerializeField] Item equippedArtifact = null;
        [SerializeField] Item equippedHelmet = null;
        Item[] equippedItems;
        [SerializeField] Item[] inventoryItems = null;
        [SerializeField] Item[] stashItems = null;
        [SerializeField] Item[] referenceItems = null;
        Manager player;

        public Item EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }
        public Item EquippedArmor { get => equippedArmor; set => equippedArmor = value; }
        public Item EquippedShield { get => equippedShield; set => equippedShield = value; }
        public Item EquippedRing { get => equippedRing; set => equippedRing = value; }
        public Item EquippedNeckle { get => equippedNeckle; set => equippedNeckle = value; }
        public Item EquippedBoots { get => equippedBoots; set => equippedBoots = value; }
        public Item EquippedGloves { get => equippedGloves; set => equippedGloves = value; }
        public Item[] EquippedItems { get => equippedItems; set => equippedItems = value; }
        public Item EquippedArtifact { get => equippedArtifact; set => equippedArtifact = value; }
        public Item EquippedHelmet { get => equippedHelmet; set => equippedHelmet = value; }
        public int InventoryItemSlots { get => inventoryItemSlots; set => inventoryItemSlots = value; }
        public int StashItemSlots { get => stashItemSlots; set => stashItemSlots = value; }
        public Item[] InventoryItems { get => inventoryItems; set => inventoryItems = value; }
        public Item[] StashItems { get => stashItems; set => stashItems = value; }

        private void Start()
        {
            player = FindObjectOfType<Manager>();
            //inventoryItems = new Item[itemSlots];
            UpdateStats();
        }

        public void UpdateStats()
        {
            equippedItems = new Item[] { equippedWeapon, equippedArmor, equippedShield, equippedRing, equippedNeckle, equippedBoots, equippedGloves, equippedArtifact, equippedHelmet };
            player.Stats.ResetStats();
            if (equippedWeapon != null)
            {
                player.Stats.Element = equippedWeapon.Element;
            }
            else
            {
                player.Stats.Element = Elemental.None;
            }
            foreach (Item item in equippedItems)
            {
                if (item != null)
                {
                    player.Stats.IncreaseMaxHP(item.Health);
                    player.Stats.IncreaseArmor(item.Armor);
                    player.Stats.IncreaseChanceToBlock(item.ChanceToBlock);
                    player.Stats.IncreaseCritResists(item.CritResist);
                    player.Stats.IncreaseFireResists(item.FireResist);
                    player.Stats.IncreaseIceResists(item.IceResist);
                    player.Stats.IncreaseEarthResists(item.EarthResist);
                    player.Stats.IncreaseAttackSpeed(item.AttackSpeed);
                    player.Stats.IncreaseCritChance(item.CritChance);
                    player.Stats.IncreaseCritMultiplier(item.CritMultiplier);
                    player.Stats.IncreaseArmorPenetration(item.ArmorPenetration);
                    player.Stats.IncreasePhysicalToElementalDamage(item.PhysicalToElementalDamage);
                    player.Stats.IncreaseDamageReflected(item.DamageReflected);
                    player.Stats.IncreaseLifeSteal(item.LifeSteal);
                    player.Stats.IncreaseChanceToSurviveOn1HP(item.ChanceToSurviveOn1HP);
                    player.Stats.IncreaseChanceToGainShield(item.ChanceToGainShield);
                    player.Stats.IncreaseMaxShield(item.Shield);
                    if (item.Element == Elemental.None)
                    {
                        player.Stats.IncreaseMinDamage(item.MinDamage);
                        player.Stats.IncreaseMaxDamage(item.MaxDamage);
                    }
                    else if (item.Element == player.Stats.Element)
                    {
                        player.Stats.IncreaseMinElementalDamage(item.MinDamage);
                        player.Stats.IncreaseMaxElementalDamage(item.MaxDamage);
                    }
                }
            }
            player.Stats.IncreaseMinElementalDamage(Mathf.RoundToInt(player.Stats.MinDamage * player.Stats.PhysicalToElementalDamage));
            player.Stats.IncreaseMaxElementalDamage(Mathf.RoundToInt(player.Stats.MaxDamage * player.Stats.PhysicalToElementalDamage));
            player.Stats.IncreaseMinDamage(-Mathf.RoundToInt(player.Stats.MinDamage * player.Stats.PhysicalToElementalDamage));
            player.Stats.IncreaseMaxDamage(-Mathf.RoundToInt(player.Stats.MaxDamage * player.Stats.PhysicalToElementalDamage));
        }

        public int GetNumberOfInventorySlotsUsed()
        {
            int used = 0;
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (inventoryItems[i] != null)
                {
                    used++;
                }
            }
            return used;
        }

        public int GetNumberOfStashSlotsUsed()
        {
            int used = 0;
            for (int i = 0; i < stashItems.Length; i++)
            {
                if (stashItems[i] != null)
                {
                    used++;
                }
            }
            return used;
        }

        public void EquipItem(int selectedItemIndex)
        {
            Item itemToEquip = InventoryItems[selectedItemIndex];
            switch (itemToEquip.Type)
            {
                case ItemType.Weapon:
                    if (EquippedWeapon == null)
                    {
                        InventoryItems[selectedItemIndex] = null;
                    }
                    else
                    {
                        InventoryItems[selectedItemIndex] = EquippedWeapon;
                    }
                    EquippedWeapon = itemToEquip;
                    break;
                case ItemType.Armor:
                    if (EquippedArmor == null)
                    {
                        InventoryItems[selectedItemIndex] = null;
                    }
                    else
                    {
                        InventoryItems[selectedItemIndex] = EquippedArmor;
                    }
                    EquippedArmor = itemToEquip;
                    break;
                case ItemType.Shield:
                    if (EquippedShield == null)
                    {
                        InventoryItems[selectedItemIndex] = null;
                    }
                    else
                    {
                        InventoryItems[selectedItemIndex] = EquippedShield;
                    }
                    EquippedShield = itemToEquip;
                    break;
                case ItemType.Helmet:
                    if (EquippedHelmet == null)
                    {
                        InventoryItems[selectedItemIndex] = null;
                    }
                    else
                    {
                        InventoryItems[selectedItemIndex] = EquippedHelmet;
                    }
                    EquippedHelmet = itemToEquip;
                    break;
                case ItemType.Boots:
                    if (EquippedBoots == null)
                    {
                        InventoryItems[selectedItemIndex] = null;
                    }
                    else
                    {
                        InventoryItems[selectedItemIndex] = EquippedBoots;
                    }
                    EquippedBoots = itemToEquip;
                    break;
                case ItemType.Gloves:
                    if (EquippedGloves == null)
                    {
                        InventoryItems[selectedItemIndex] = null;
                    }
                    else
                    {
                        InventoryItems[selectedItemIndex] = EquippedGloves;
                    }
                    EquippedGloves = itemToEquip;
                    break;
                case ItemType.Neckle:
                    if (EquippedNeckle == null)
                    {
                        InventoryItems[selectedItemIndex] = null;
                    }
                    else
                    {
                        InventoryItems[selectedItemIndex] = EquippedNeckle;
                    }
                    EquippedNeckle = itemToEquip;
                    break;
                case ItemType.Ring:
                    if (EquippedRing == null)
                    {
                        InventoryItems[selectedItemIndex] = null;
                    }
                    else
                    {
                        InventoryItems[selectedItemIndex] = EquippedRing;
                    }
                    EquippedRing = itemToEquip;
                    break;
                case ItemType.Artifact:
                    if (EquippedArtifact == null)
                    {
                        InventoryItems[selectedItemIndex] = null;
                    }
                    else
                    {
                        InventoryItems[selectedItemIndex] = EquippedArtifact;
                    }
                    EquippedArtifact = itemToEquip;
                    break;
                case ItemType.Misc:
                    break;
                default:
                    break;
            }
            UpdateStats();
            FindObjectOfType<Side>().ShowEquippedItems();
        }

        public void SortInventory()
        {
            for (int i = 1; i < inventoryItems.Length; i++)
            {
                Item key = inventoryItems[i];
                if (key != null)
                {
                    int j = i - 1;
                    while (j >= 0 && key.CompareTo(inventoryItems[j]) < 0)
                    {
                        inventoryItems[j + 1] = inventoryItems[j];
                        j = j - 1;
                    }
                    j++;
                    inventoryItems[j] = key;
                }
            }
        }

        public void SortStash()
        {
            for (int i = 1; i < stashItems.Length; i++)
            {
                Item key = stashItems[i];
                if (key != null)
                {
                    int j = i - 1;
                    while (j >= 0 && key.CompareTo(stashItems[j]) < 0)
                    {
                        stashItems[j + 1] = stashItems[j];
                        j = j - 1;
                    }
                    j++;
                    stashItems[j] = key;
                }
            }
        }

        public void DestroyItemFromInventory(int index)
        {
            inventoryItems[index] = null;
        }
    }
}