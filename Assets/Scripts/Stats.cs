using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private enum elementals { None, Fire, Ice, Earth };
    [SerializeField] private elementals element;
    [SerializeField] private int level;
    public int expToNextLevel { get; set; } = 10;
    public int currExp { get; set; } = 0;
    [Header("Defence")]
    [SerializeField] private int maxHP;
    private int currHp;
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
    private int currShield;

    public int Level { get => level; set => level = value; }
}
