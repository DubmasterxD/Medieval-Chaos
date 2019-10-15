using UnityEngine;
using Medieval.Core;

namespace Medieval.Combat
{
    [System.Serializable]
    public class Stats
    {
        [Header("Basic Stats")]
        [SerializeField] Elemental elemental = default;
        [SerializeField] int level = 0;
        public int expToNextLevel { get; set; } = 10;
        public int currExp { get; set; } = 0;
        [SerializeField] int basicHP = 10;
        [SerializeField] int basicDamage = 1;
        [SerializeField] float basicCritMultiplier = 1;
        [SerializeField] int basicAttackSpeed = 50;
        [Header("Defence")]
        [SerializeField] int maxHP;
        public int currHp { get; set; }
        [SerializeField] int armor;
        [Range(0, 1)] [SerializeField] float chanceToBlock;
        [Range(0, 1)] [SerializeField] float critResist;
        [Range(-1, 1)] [SerializeField] float fireResist;
        [Range(-1, 1)] [SerializeField] float iceResist;
        [Range(-1, 1)] [SerializeField] float earthResist;
        [Header("Attack")]
        [SerializeField] int minDamage;
        [SerializeField] int maxDamage;
        [Range(0, 50)] [SerializeField] int attackSpeed;
        [Range(0, 1)] [SerializeField] float critChance;
        [SerializeField] float critMultiplier;
        [SerializeField] int armorPenetration;
        [SerializeField] int minElementalDamage;
        [SerializeField] int maxElementalDamage;
        [Range(0, 1)] [SerializeField] float physicalToElementalDamage;
        [Header("Special")]
        [Range(0, 1)] [SerializeField] float damageReflected;
        [Range(0, 1)] [SerializeField] float lifeSteal;
        [Range(0, 1)] [SerializeField] float chanceToSurviveOn1HP;
        [Range(0, 1)] [SerializeField] float chanceToGainShield;
        [SerializeField] int maxShield;
        public int currShield { get; set; }

        public int Level { get => level; }
        public Elemental Element { get => elemental; set => elemental = value; }
        public int MaxHP { get => maxHP; }
        public int Armor { get => armor; }
        public float ChanceToBlock { get => chanceToBlock; }
        public float CritResist { get => critResist; }
        public float FireResist { get => fireResist; }
        public float IceResist { get => iceResist; }
        public float EarthResist { get => earthResist; }
        public int MinDamage { get => minDamage; }
        public int MaxDamage { get => maxDamage; }
        public int AttackSpeed { get => attackSpeed; }
        public float CritChance { get => critChance; }
        public float CritMultiplier { get => critMultiplier; }
        public int ArmorPenetration { get => armorPenetration; }
        public int MinElementalDamage { get => minElementalDamage; }
        public int MaxElementalDamage { get => maxElementalDamage; }
        public float PhysicalToElementalDamage { get => physicalToElementalDamage; }
        public float DamageReflected { get => damageReflected; }
        public float LifeSteal { get => lifeSteal; }
        public float ChanceToSurviveOn1HP { get => chanceToSurviveOn1HP; }
        public float ChanceToGainShield { get => chanceToGainShield; }
        public int MaxShield { get => maxShield; }

        public void IncreaseMaxHP(int value)
        {
            maxHP += value;
        }

        public void IncreaseArmor(int value)
        {
            armor += value;
        }

        public void IncreaseChanceToBlock(float value)
        {
            chanceToBlock += value;
            if (chanceToBlock > 1)
            {
                chanceToBlock = 1;
            }
        }

        public void IncreaseCritResists(float value)
        {
            critResist += value;
            if (critResist > 1)
            {
                critResist = 1;
            }
        }

        public void IncreaseFireResists(float value)
        {
            fireResist += value;
            if (fireResist > 1)
            {
                fireResist = 1;
            }
            if (fireResist < -1)
            {
                fireResist = -1;
            }
        }

        public void IncreaseIceResists(float value)
        {
            iceResist += value;
            if (iceResist > 1)
            {
                iceResist = 1;
            }
            if (iceResist < -1)
            {
                iceResist = -1;
            }
        }

        public void IncreaseEarthResists(float value)
        {
            earthResist += value;
            if (earthResist > 1)
            {
                earthResist = 1;
            }
            if (earthResist < -1)
            {
                earthResist = -1;
            }
        }

        public void IncreaseMinDamage(int value)
        {
            minDamage += value;
        }

        public void IncreaseMaxDamage(int value)
        {
            maxDamage += value;
        }

        public void IncreaseAttackSpeed(int value)
        {
            attackSpeed += value;
        }

        public void IncreaseCritChance(float value)
        {
            critChance += value;
            if (critChance > 1)
            {
                critChance = 1;
            }
        }

        public void IncreaseCritMultiplier(float value)
        {
            critMultiplier += value;
        }

        public void IncreaseArmorPenetration(int value)
        {
            armorPenetration += value;
        }

        public void IncreaseMinElementalDamage(int value)
        {
            minElementalDamage += value;
        }

        public void IncreaseMaxElementalDamage(int value)
        {
            maxElementalDamage += value;
        }

        public void IncreasePhysicalToElementalDamage(float value)
        {
            physicalToElementalDamage += value;
            if (physicalToElementalDamage > 1)
            {
                physicalToElementalDamage = 1;
            }
        }

        public void IncreaseDamageReflected(float value)
        {
            damageReflected += value;
            if (damageReflected > 1)
            {
                damageReflected = 1;
            }
        }

        public void IncreaseLifeSteal(float value)
        {
            lifeSteal += value;
            if (lifeSteal > 1)
            {
                lifeSteal = 1;
            }
        }

        public void IncreaseChanceToSurviveOn1HP(float value)
        {
            chanceToSurviveOn1HP += value;
            if (chanceToSurviveOn1HP > 1)
            {
                chanceToSurviveOn1HP = 1;
            }
        }

        public void IncreaseChanceToGainShield(float value)
        {
            chanceToGainShield += value;
            if (chanceToGainShield > 1)
            {
                chanceToGainShield = 1;
            }
        }

        public void IncreaseMaxShield(int value)
        {
            maxShield += value;
        }

        public void ResetStats()
        {
            maxHP = basicHP;
            currHp = maxHP;
            armor = 0;
            chanceToBlock = 0;
            critResist = 0;
            fireResist = 0;
            iceResist = 0;
            earthResist = 0;
            minDamage = basicDamage;
            maxDamage = basicDamage;
            attackSpeed = basicAttackSpeed;
            critChance = 0;
            critMultiplier = basicCritMultiplier;
            armorPenetration = 0;
            minElementalDamage = 0;
            maxElementalDamage = 0;
            physicalToElementalDamage = 0;
            damageReflected = 0;
            lifeSteal = 0;
            chanceToSurviveOn1HP = 0;
            chanceToGainShield = 0;
            maxShield = 0;
        }
    }
}