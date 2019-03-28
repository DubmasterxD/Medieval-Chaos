using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public enum elementals { None, Fire, Ice, Earth };
    [SerializeField] private elementals element;
    [SerializeField] private int level;
    public int expToNextLevel { get; set; } = 10;
    public int currExp { get; set; } = 0;
    [Header("Defence")]
    [SerializeField] private int maxHP;
    public int currHp { get; set; }
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
    [SerializeField] private int maxShield;
    public int currShield { get; set; }

    public int Level { get => level; set => level = value; }
    public elementals Element { get => element; set => element = value; }
    public int MaxHP { get => maxHP; set => maxHP = value; }
    public int Armor { get => armor; set => armor = value; }
    public float ChanceToBlock { get => chanceToBlock; set => chanceToBlock = value; }
    public float CritResist { get => critResist; set => critResist = value; }
    public float FireResist { get => fireResist; set => fireResist = value; }
    public float IceResist { get => iceResist; set => iceResist = value; }
    public float EarthResist { get => earthResist; set => earthResist = value; }
    public int MinDamage { get => minDamage; set => minDamage = value; }
    public int MaxDamage { get => maxDamage; set => maxDamage = value; }
    public int AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int CritChance { get => critChance; set => critChance = value; }
    public float CritMultiplier { get => critMultiplier; set => critMultiplier = value; }
    public int ArmorPenetration { get => armorPenetration; set => armorPenetration = value; }
    public int MinElementalDamage { get => minElementalDamage; set => minElementalDamage = value; }
    public int MaxElementalDamage { get => maxElementalDamage; set => maxElementalDamage = value; }
    public float PhysicalToElementalDamage { get => physicalToElementalDamage; set => physicalToElementalDamage = value; }
    public float DamageReflected { get => damageReflected; set => damageReflected = value; }
    public float LifeSteal { get => lifeSteal; set => lifeSteal = value; }
    public float ChanceToSurviveOn1HP { get => chanceToSurviveOn1HP; set => chanceToSurviveOn1HP = value; }
    public float ChanceToGainShield { get => chanceToGainShield; set => chanceToGainShield = value; }
    public int MaxShield { get => maxShield; set => maxShield = value; }
}
