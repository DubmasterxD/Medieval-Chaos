using UnityEngine;
using UnityEngine.UI;
using Medieval.Player;

namespace Medieval.UI
{
    public class Level : MonoBehaviour
    {
        [SerializeField] Text levelText = null;
        [SerializeField] Text expValueText = null;
        [SerializeField] Slider expSlider = null;

        private Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
        }

        public void RefreshStats()
        {
            levelText.text = "Lvl: " + player.Stats.Level;
            expValueText.text = player.Stats.currExp + "/" + player.Stats.expToNextLevel;
            expSlider.value = player.Stats.currExp / player.Stats.expToNextLevel;
        }
    }
}