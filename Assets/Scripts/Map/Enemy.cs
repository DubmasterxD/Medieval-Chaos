using UnityEngine;
using Medieval.Core;

namespace Medieval.Map
{
    [CreateAssetMenu]
    public class Enemy : ScriptableObject
    {
        [Header("Basic Stats")]
        [SerializeField] private string enemyName;
        [SerializeField] private Sprite sprite = null;
        [SerializeField] private Elementals element;
        [SerializeField] private int level;
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
        [Range(0, 1)] [SerializeField] private float critChance;
        [SerializeField] private float critMultiplier;
        [SerializeField] private int armorPenetration;
        [Header("Special")]
        [Range(0, 1)] [SerializeField] private float lifeSteal;
        [Range(0, 1)] [SerializeField] private float chanceToSurviveOn1HP;
        [Range(0, 1)] [SerializeField] private float chanceToGainShield;
        [SerializeField] private int maxShield;
        public int currShield { get; set; }
        [SerializeField] Item[] possibleDropItems;
        [SerializeField] float[] dropChances;
    }
}