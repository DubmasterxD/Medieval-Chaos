using UnityEngine;
using UnityEngine.UI;
using Medieval.Player;
using Medieval.Core;

namespace Medieval.UI
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] Text attackStatsText = null;
        [SerializeField] Text defenceStatsText = null;
        [SerializeField] Text specialStatsText = null;

        private Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
        }

        public void RefreshStats()
        {
            RefreshAttackStats();
            RefreshDefenceStats();
            RefreshSpecialStats();
        }

        private void RefreshAttackStats()
        {
            attackStatsText.text = "Damage: " + player.stats.MinDamage + " - " + player.stats.MaxDamage;
            attackStatsText.text += "\nAttack Speed: " + player.stats.AttackSpeed;
            if (player.stats.CritChance != 0)
            {
                attackStatsText.text += "\nCritical Hit Chance: " + (player.stats.CritChance * 100) + "%";
                attackStatsText.text += "\nCritical Hit Multiplier: " + player.stats.CritMultiplier;
            }
            if (player.stats.ArmorPenetration != 0)
            {
                attackStatsText.text += "\nArmor Penetration: " + player.stats.ArmorPenetration;
            }
            if (player.stats.Element != Elementals.None)
            {
                attackStatsText.text += "\n" + player.stats.Element.ToString() + " Damage: " + player.stats.MinElementalDamage + " - " + player.stats.MaxElementalDamage;
                attackStatsText.text += "\nPhysical To " + player.stats.Element + " Damage: " + player.stats.PhysicalToElementalDamage;
            }
        }

        private void RefreshDefenceStats()
        {
            defenceStatsText.text = "Health: " + player.stats.MaxHP;
            defenceStatsText.text += "\nArmor: " + player.stats.Armor;
            if (player.stats.ChanceToBlock != 0)
            {
                defenceStatsText.text += "\nChance To Block: " + (player.stats.ChanceToBlock * 100) + "%";
            }
            if (player.stats.CritResist != 0)
            {
                defenceStatsText.text += "\nCritical Damage Resists: " + (player.stats.CritResist * 100) + "%";
            }
            defenceStatsText.text += "\nFire Resists: " + (player.stats.FireResist * 100) + "%";
            defenceStatsText.text += "\nIce Resists: " + (player.stats.IceResist * 100) + "%";
            defenceStatsText.text += "\nEarth Resists: " + (player.stats.EarthResist * 100) + "%";
        }

        private void RefreshSpecialStats()
        {
            specialStatsText.text = "";
            if (player.stats.LifeSteal != 0)
            {
                specialStatsText.text = "\nLife Steal: " + (player.stats.LifeSteal * 100) + "%";
            }
            if (player.stats.DamageReflected != 0)
            {
                specialStatsText.text += "\nDamage Reflection: " + (player.stats.DamageReflected * 100) + "%";
            }
            if (player.stats.ChanceToSurviveOn1HP != 0)
            {
                specialStatsText.text += "\nChance To Cheat Death: " + (player.stats.ChanceToSurviveOn1HP * 100) + "%";
            }
            if (player.stats.ChanceToGainShield != 0)
            {
                specialStatsText.text += "\nChance To Gain Shield: " + (player.stats.ChanceToGainShield * 100) + "%";
                specialStatsText.text += "\nAmount Of Gained Shield: " + player.stats.MaxShield;
            }
            if (specialStatsText.text != "")
            {
                specialStatsText.text = specialStatsText.text.Remove(0, 1);
            }
        }
    }
}