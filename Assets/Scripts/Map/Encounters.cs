using UnityEngine;
using Medieval.Core;

namespace Medieval.Map
{
    [CreateAssetMenu]
    public class Encounters : ScriptableObject
    {
        [SerializeField] string areaName ="";
        [SerializeField] Enemy[] enemies = null;
        [SerializeField] float[] enemiesChances = null;
        [SerializeField] Item[] items = null;
        [SerializeField] float[] itemsChances = null;
        [SerializeField] Enemy rareEncounter = null;
        [SerializeField] float chanceToEnemy = 0;
        [SerializeField] float chanceToItem = 0;

        public string AreaName { get => areaName; set => areaName = value; }
        public Enemy RareEncounter { get => rareEncounter; set => rareEncounter = value; }

        public bool IsNewEncounterItem()
        {
            float random = Random.Range(0f, 1f);
            if (random > chanceToEnemy)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Item NewTreasure()
        {
            float random = Random.Range(0f, 1f);
            int i = -1;
            float sum = 0;
            do
            {
                i++;
                sum += itemsChances[i];
            } while (sum < random);
            return items[i];
        }

        public Enemy NewEnemy()
        {
            float random = Random.Range(0f, 1f);
            int i = -1;
            float sum = 0;
            do
            {
                i++;
                sum += enemiesChances[i];
            } while (sum < random);
            return enemies[i];
        }
    }
}