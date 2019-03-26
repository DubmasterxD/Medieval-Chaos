using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private enum elementals { Fire, Ice, Earth };
    [Header("Defence")]
    private int maxHP;
    private int currHp;
    private int armor;
    private float chanceToBlock;
    private float critResist;
    private float fireResist;
    private float iceResist;
    private float earthResist;
    [Header("Attack")]
    private int minDamage;
    private int maxDamage;
    private int attackSpeed;
    private int critChance;
    private float critMultiplier;
    private int armorPenetration;
    private int minElementalDamage;
    private int maxElementalDamage;
    private float physicalToElementalDamage;
    [Header("Special")]
    private float damageReflected;
    private float lifeSteal;
    private float chanceToSurviveOn1HP;
    private float chanceToGainShield;
    private int maxShield;
    private int currShield;
}
