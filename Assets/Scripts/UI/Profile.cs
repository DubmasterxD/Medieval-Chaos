using UnityEngine;
using UnityEngine.UI;
using Medieval.Player;

namespace Medieval.UI
{
    public class Profile : MonoBehaviour
    {
        [SerializeField] Text nicknameText = null;
        [SerializeField] Text levelText = null;
        [SerializeField] Text expValueText = null;
        [SerializeField] Slider expSlider = null;

        Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
        }

        private void Start()
        {
            nicknameText.text = player.Nickname;
            levelText.text = "Lvl: " + player.stats.Level;
            expValueText.text = player.stats.currExp + "/" + player.stats.expToNextLevel;
            expSlider.value = player.stats.currExp / player.stats.expToNextLevel;
        }
    }
}