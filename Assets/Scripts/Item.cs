using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [Header("General")]
    [SerializeField] private string itemName;
    [SerializeField] private int IDnumber;
    [SerializeField] private Sprite image;
    [SerializeField] private int level;
    [SerializeField] Stats.elementals element;
    [SerializeField] ItemsList.itemTypes type;
    [SerializeField] ItemsList.itemRarity rarity;
    [SerializeField] private int maxDurability;
    public int currDurability { get; set; }
    [SerializeField] private Item[] dismantleResources;
    [SerializeField] private int sellPrice;
    [SerializeField] private int buyPrice;
    public int nextUpgradeCost { get; set; }
    public int currUpgradesDone { get; set; }
    [Header("Defence")]
    [SerializeField] private int health;
    [SerializeField] private int armor;
    [Range(0, 1)] [SerializeField] private float chanceToBlock;
    [Range(0, 1)] [SerializeField] private float critResist;
    [Range(-1, 1)] [SerializeField] private float fireResist;
    [Range(-1, 1)] [SerializeField] private float iceResist;
    [Range(-1, 1)] [SerializeField] private float earthResist;
    [Header("Attack")]
    [SerializeField] private int minDamage;
    [SerializeField] private int maxDamage;
    [Range(0, 50)] [SerializeField] private int attackSpeed;
    [Range(0, 1)] [SerializeField] private float critChance;
    [SerializeField] private float critMultiplier;
    [SerializeField] private int armorPenetration;
    [Range(0, 1)] [SerializeField] private float physicalToElementalDamage;
    [Header("Special")]
    [Range(0, 1)] [SerializeField] private float damageReflected;
    [Range(0, 1)] [SerializeField] private float lifeSteal;
    [Range(0, 1)] [SerializeField] private float chanceToSurviveOn1HP;
    [Range(0, 1)] [SerializeField] private float chanceToGainShield;
    [SerializeField] private int shield;
    [SerializeField] float movementSpeed;
    [Header("Description")]
    [Multiline(10)][SerializeField] string itemDescription;
    
    public string Name { get => itemName; set => itemName = value; }
    public int IDNumber { get => IDnumber; set => IDnumber = value; }
    public Sprite Image { get => image; set => image = value; }
    public int Level { get => level; set => level = value; }
    public Stats.elementals Element { get => element; set => element = value; }
    public ItemsList.itemTypes Type { get => type; set => type = value; }
    public ItemsList.itemRarity Rarity { get => rarity; set => rarity = value; }
    public int MaxDurability { get => maxDurability; set => maxDurability = value; }
    public Item[] DismantleResources { get => dismantleResources; set => dismantleResources = value; }
    public int SellPrice { get => sellPrice; set => sellPrice = value; }
    public int BuyPrice { get => buyPrice; set => buyPrice = value; }
    public int Health { get => health; set => health = value; }
    public int Armor { get => armor; set => armor = value; }
    public float ChanceToBlock { get => chanceToBlock; set => chanceToBlock = value; }
    public float CritResist { get => critResist; set => critResist = value; }
    public float FireResist { get => fireResist; set => fireResist = value; }
    public float IceResist { get => iceResist; set => iceResist = value; }
    public float EarthResist { get => earthResist; set => earthResist = value; }
    public int MinDamage { get => minDamage; set => minDamage = value; }
    public int MaxDamage { get => maxDamage; set => maxDamage = value; }
    public int AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float CritChance { get => critChance; set => critChance = value; }
    public float CritMultiplier { get => critMultiplier; set => critMultiplier = value; }
    public int ArmorPenetration { get => armorPenetration; set => armorPenetration = value; }
    public float PhysicalToElementalDamage { get => physicalToElementalDamage; set => physicalToElementalDamage = value; }
    public float DamageReflected { get => damageReflected; set => damageReflected = value; }
    public float LifeSteal { get => lifeSteal; set => lifeSteal = value; }
    public float ChanceToSurviveOn1HP { get => chanceToSurviveOn1HP; set => chanceToSurviveOn1HP = value; }
    public float ChanceToGainShield { get => chanceToGainShield; set => chanceToGainShield = value; }
    public int Shield { get => shield; set => shield = value; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public string ItemDescription { get => itemDescription; set => itemDescription = value; }

    public string GetStatsDescription()
    {
        string stats = rarity + itemName + "\n" + " Level: " + level + "\nDurability: "+currDurability+"/"+maxDurability;
        if(health!=0)
        {
            stats += "\nHP: " + health;
        }
        if(armor!=0)
        {
            stats += "\nArmor: " + armor;
        }
        if (chanceToBlock != 0)
        {
            stats += "\nChance To Block: " + (chanceToBlock*100) + "%";
        }
        if (critResist != 0)
        {
            stats += "\nCrit Resists: " + (critResist * 100) + "%";
        }
        if (fireResist != 0)
        {
            stats += "\nFire Resists: " + (fireResist * 100) + "%";
        }
        if (iceResist != 0)
        {
            stats += "\nIce Resists: " + (iceResist * 100) + "%";
        }
        if (earthResist != 0)
        {
            stats += "\nEarth Resists: " + (earthResist * 100) + "%";
        }
        if (maxDamage != 0)
        {
            switch (element)
            {
                case Stats.elementals.None:
                    stats += "\n";
                    break;
                case Stats.elementals.Fire:
                    stats += "\nFire ";
                    break;
                case Stats.elementals.Ice:
                    stats += "\nIce ";
                    break;
                case Stats.elementals.Earth:
                    stats += "\nEarth ";
                    break;
                default:
                    break;
            }
            stats += "Damage: " + minDamage +"-"+maxDamage;
        }
        if (attackSpeed != 0)
        {
            stats += "\nAttack Speed: " + attackSpeed;
        }
        if (critChance != 0)
        {
            stats += "\nChance To Crit: " + (critChance * 100) + "%";
        }
        if (critMultiplier != 0)
        {
            stats += "\nCrit Multiplier: " + (critMultiplier * 100) + "%";
        }
        if (armorPenetration != 0)
        {
            stats += "\nArmor Penetration: " + armorPenetration;
        }
        if (physicalToElementalDamage != 0)
        {
            stats += "\nPhysical To Elemental: " + (physicalToElementalDamage * 100)+"%";
        }
        if (damageReflected != 0)
        {
            stats += "\nDamage Reflected: " + (damageReflected * 100) + "%";
        }
        if (lifeSteal != 0)
        {
            stats += "\nLife Steal: " + (lifeSteal * 100) + "%";
        }
        if (chanceToSurviveOn1HP != 0)
        {
            stats += "\nChance To Survive Death: " + (chanceToSurviveOn1HP * 100) + "%";
        }
        if (chanceToGainShield != 0)
        {
            stats += "\nChance To Gain Shield: " + (chanceToGainShield * 100) + "%";
        }
        if (shield != 0)
        {
            stats += "\nShield Strength: " + shield;
        }
        if (movementSpeed != 0)
        {
            stats += "\nMovement Speed: " + movementSpeed;
        }
        return stats;
    }
}
