using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [Header("General")]
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
    [Range(0, 1)] [SerializeField] private int critChance;
    [Range(1.5f, 3)] [SerializeField] private float critMultiplier;
    [Range(0, 1)] [SerializeField] private int armorPenetration;
    [SerializeField] private int minElementalDamage;
    [SerializeField] private int maxElementalDamage;
    [Range(0, 1)] [SerializeField] private float physicalToElementalDamage;
    [Header("Special")]
    [Range(0, 1)] [SerializeField] private float damageReflected;
    [Range(0, 1)] [SerializeField] private float lifeSteal;
    [Range(0, 1)] [SerializeField] private float chanceToSurviveOn1HP;
    [Range(0, 1)] [SerializeField] private float chanceToGainShield;
    [SerializeField] private int Shield;
}
