using UnityEngine;
using Medieval.Core;
using Medieval.Combat;

namespace Medieval.Map
{
    [CreateAssetMenu]
    public class Enemy : ScriptableObject
    {
        [SerializeField] string enemyName;
        [SerializeField] Sprite sprite = null;

        [SerializeField] Stats stats = null;
        
        [SerializeField] Item[] possibleDropItems;
        [SerializeField] float[] dropChances;
    }
}