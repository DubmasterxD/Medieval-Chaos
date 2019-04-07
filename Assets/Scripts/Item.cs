using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [Header("General")]
    [SerializeField] private string name;
    [SerializeField] private int ID;
    [SerializeField] private Sprite image;
    [SerializeField] private int level;
    [SerializeField] Stats.elementals element;
    [SerializeField] ItemsList.itemTypes type;
    [SerializeField] ItemsList.itemRarity rarity;
    [SerializeField] private int maxDurability;
    private int currDurability;
    [SerializeField] private Item[] dismantleResources;
    [SerializeField] private int sellPrice;
    [SerializeField] private int buyPrice;
    private int nextUpgradeCost;
    private int currUpgradesDone;
    [Header("Defence")]
    [SerializeField] private int HP;
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

    public Sprite Image { get => image; set => image = value; }
    public string ItemDescription { get => itemDescription; set => itemDescription = value; }

    public string StatsDescription()
    {
        string stats = rarity + name + "\n" + " Level: " + level + "\nDurability: "+currDurability+"/"+maxDurability;
        if(HP!=0)
        {
            stats += "\nHP: " + HP;
        }
        if(armor!=0)
        {
            stats += "\nArmor: " + armor;
        }
        if (chanceToBlock != 0)
        {
            stats += "\nChance To Block: " + chanceToBlock + "%";
        }
        if (critResist != 0)
        {
            stats += "\nCrit Resists: " + critResist + "%";
        }
        if (fireResist != 0)
        {
            stats += "\nFire Resists: " + fireResist + "%";
        }
        if (iceResist != 0)
        {
            stats += "\nIce Resists: " + iceResist + "%";
        }
        if (earthResist != 0)
        {
            stats += "\nEarth Resists: " + earthResist + "%";
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
            stats += "\nChance To Crit: " + critChance + "%";
        }
        if (critMultiplier != 0)
        {
            stats += "\nCrit Multiplier: " + critMultiplier + "%";
        }
        if (armorPenetration != 0)
        {
            stats += "\nArmor Penetration: " + armorPenetration;
        }
        if (physicalToElementalDamage != 0)
        {
            stats += "\nPhysical To Elemental Damage: " + physicalToElementalDamage+"%";
        }
        if (damageReflected != 0)
        {
            stats += "\nDamage Reflected: " + damageReflected + "%";
        }
        if (lifeSteal != 0)
        {
            stats += "\nLife Steal: " + lifeSteal + "%";
        }
        if (chanceToSurviveOn1HP != 0)
        {
            stats += "\nChance To Survive On 1 HP: " + chanceToSurviveOn1HP + "%";
        }
        if (chanceToGainShield != 0)
        {
            stats += "\nChance To Gain Shield: " + chanceToGainShield + "%";
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
