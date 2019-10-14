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
            levelText.text = "Lvl: " + player.stats.Level;
            expValueText.text = player.stats.currExp + "/" + player.stats.expToNextLevel;
            expSlider.value = player.stats.currExp / player.stats.expToNextLevel;
        }
    }
}