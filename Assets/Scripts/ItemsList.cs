using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public enum itemTypes { Weapon, Shield, Armor, Neckle, Boots, Gloves, Ring, Helmet, Artifact };
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

    private void Start()
    {
        playerStats = Player.instance.GetComponent<Stats>();
        inventoryItems = new Item[itemSlots];
        equippedItems = new Item[] { equippedWeapon, equippedArmor, equippedShield, equippedRing, equippedNeckle, equippedBoots, equippedGloves, equippedArtifact, equippedHelmet };
        UpdateStats();
    }

    public void UpdateStats()
    {
        playerStats.ResetStats();
        playerStats.Element = equippedWeapon.Element;
        foreach(Item item in equippedItems)
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
}
