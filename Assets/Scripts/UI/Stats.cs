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

        public void Refresh()
        {
            RefreshAttackStats();
            RefreshDefenceStats();
            RefreshSpecialStats();
        }

        private void RefreshAttackStats()
        {
            attackStatsText.text = "Damage: " + player.Stats.MinDamage + " - " + player.Stats.MaxDamage;
            attackStatsText.text += "\nAttack Speed: " + player.Stats.AttackSpeed;
            if (player.Stats.CritChance != 0)
            {
                attackStatsText.text += "\nCritical Hit Chance: " + (player.Stats.CritChance * 100) + "%";
                attackStatsText.text += "\nCritical Hit Multiplier: " + player.Stats.CritMultiplier;
            }
            if (player.Stats.ArmorPenetration != 0)
            {
                attackStatsText.text += "\nArmor Penetration: " + player.Stats.ArmorPenetration;
            }
            if (player.Stats.Element != Elemental.None)
            {
                attackStatsText.text += "\n" + player.Stats.Element.ToString() + " Damage: " + player.Stats.MinElementalDamage + " - " + player.Stats.MaxElementalDamage;
                attackStatsText.text += "\nPhysical To " + player.Stats.Element + " Damage: " + player.Stats.PhysicalToElementalDamage;
            }
        }

        private void RefreshDefenceStats()
        {
            defenceStatsText.text = "Health: " + player.Stats.MaxHP;
            defenceStatsText.text += "\nArmor: " + player.Stats.Armor;
            if (player.Stats.ChanceToBlock != 0)
            {
                defenceStatsText.text += "\nChance To Block: " + (player.Stats.ChanceToBlock * 100) + "%";
            }
            if (player.Stats.CritResist != 0)
            {
                defenceStatsText.text += "\nCritical Damage Resists: " + (player.Stats.CritResist * 100) + "%";
            }
            defenceStatsText.text += "\nFire Resists: " + (player.Stats.FireResist * 100) + "%";
            defenceStatsText.text += "\nIce Resists: " + (player.Stats.IceResist * 100) + "%";
            defenceStatsText.text += "\nEarth Resists: " + (player.Stats.EarthResist * 100) + "%";
        }

        private void RefreshSpecialStats()
        {
            specialStatsText.text = "";
            if (player.Stats.LifeSteal != 0)
            {
                specialStatsText.text = "\nLife Steal: " + (player.Stats.LifeSteal * 100) + "%";
            }
            if (player.Stats.DamageReflected != 0)
            {
                specialStatsText.text += "\nDamage Reflection: " + (player.Stats.DamageReflected * 100) + "%";
            }
            if (player.Stats.ChanceToSurviveOn1HP != 0)
            {
                specialStatsText.text += "\nChance To Cheat Death: " + (player.Stats.ChanceToSurviveOn1HP * 100) + "%";
            }
            if (player.Stats.ChanceToGainShield != 0)
            {
                specialStatsText.text += "\nChance To Gain Shield: " + (player.Stats.ChanceToGainShield * 100) + "%";
                specialStatsText.text += "\nAmount Of Gained Shield: " + player.Stats.MaxShield;
            }
            if (specialStatsText.text != "")
            {
                specialStatsText.text = specialStatsText.text.Remove(0, 1);
            }
        }
    }
}