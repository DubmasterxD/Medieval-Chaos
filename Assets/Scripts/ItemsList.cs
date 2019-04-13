using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public enum itemTypes { Weapon, Armor, Shield, Helmet, Boots, Gloves, Neckle, Ring, Artifact, Misc };
    public enum itemRarity { Common, Uncommon, Rare, Legendary, Unique };
    [SerializeField] int itemSlots = 50;
    [SerializeField] Item equippedWeapon;
    [SerializeField] Item equippedArmor;
    [SerializeField] Item equippedShield;
    [SerializeField] Item equippedRing;
    [SerializeField] Item equippedNeckle;
    [SerializeField] Item equippedBoots;
    [SerializeField] Item equippedGloves;
    [SerializeField] Item equippedArtifact;
    [SerializeField] Item equippedHelmet;
    Item[] equippedItems;
    [SerializeField] Item[] inventoryItems;
    [SerializeField] Item[] referenceItems;
    Stats playerStats;

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
    public int ItemSlots { get => itemSlots; set => itemSlots = value; }
    public Item[] InventoryItems { get => inventoryItems; set => inventoryItems = value; }

    private void Start()
    {
        playerStats = Player.instance.GetComponent<Stats>();
        //inventoryItems = new Item[itemSlots];
        UpdateStats();
    }

    public void UpdateStats()
    {
        equippedItems = new Item[] { equippedWeapon, equippedArmor, equippedShield, equippedRing, equippedNeckle, equippedBoots, equippedGloves, equippedArtifact, equippedHelmet };
        playerStats.ResetStats();
        playerStats.Element = equippedWeapon.Element;
        foreach (Item item in equippedItems)
        {
            if (item != null)
            {
                playerStats.IncreaseMaxHP(item.Health);
                playerStats.IncreaseArmor(item.Armor);
                playerStats.IncreaseChanceToBlock(item.ChanceToBlock);
                playerStats.IncreaseCritResists(item.CritResist);
                playerStats.IncreaseFireResists(item.FireResist);
                playerStats.IncreaseIceResists(item.IceResist);
                playerStats.IncreaseEarthResists(item.EarthResist);
                playerStats.IncreaseAttackSpeed(item.AttackSpeed);
                playerStats.IncreaseCritChance(item.CritChance);
                playerStats.IncreaseCritMultiplier(item.CritMultiplier);
                playerStats.IncreaseArmorPenetration(item.ArmorPenetration);
                playerStats.IncreasePhysicalToElementalDamage(item.PhysicalToElementalDamage);
                playerStats.IncreaseDamageReflected(item.DamageReflected);
                playerStats.IncreaseLifeSteal(item.LifeSteal);
                playerStats.IncreaseChanceToSurviveOn1HP(item.ChanceToSurviveOn1HP);
                playerStats.IncreaseChanceToGainShield(item.ChanceToGainShield);
                playerStats.IncreaseMaxShield(item.Shield);
                if (item.Element == Stats.elementals.None)
                {
                    playerStats.IncreaseMinDamage(item.MinDamage);
                    playerStats.IncreaseMaxDamage(item.MaxDamage);
                }
                else if (item.Element == playerStats.Element)
                {
                    playerStats.IncreaseMinElementalDamage(item.MinDamage);
                    playerStats.IncreaseMaxElementalDamage(item.MaxDamage);
                }
            }
        }
        playerStats.IncreaseMinElementalDamage(Mathf.RoundToInt(playerStats.MinDamage * playerStats.PhysicalToElementalDamage));
        playerStats.IncreaseMaxElementalDamage(Mathf.RoundToInt(playerStats.MaxDamage * playerStats.PhysicalToElementalDamage));
        playerStats.IncreaseMinDamage(-Mathf.RoundToInt(playerStats.MinDamage * playerStats.PhysicalToElementalDamage));
        playerStats.IncreaseMaxDamage(-Mathf.RoundToInt(playerStats.MaxDamage * playerStats.PhysicalToElementalDamage));
    }

    public int GetNumberOfSlotsUsed()
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
}
