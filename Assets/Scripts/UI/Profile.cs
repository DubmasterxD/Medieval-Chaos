using UnityEngine;
using UnityEngine.UI;
using Medieval.Player;

namespace Medieval.UI
{
    public class Profile : MonoBehaviour
    {
        [SerializeField] Text nickname = null;
        [SerializeField] Text level = null;
        [SerializeField] Text experienceValue = null;
        [SerializeField] Slider experienceSlider = null;

        Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
        }

        private void Start()
        {
            Refresh();
        }

        public void Refresh()
        {
            SetNickname(player.Nickname);
            UpdateExperience();
        }

        private void  SetNickname(string newNickname)
        {
            nickname.text = newNickname;
        }

        private void UpdateExperience()
        {
            level.text = "Lvl: " + player.Stats.Level;
            experienceValue.text = player.Stats.currExp + "/" + player.Stats.expToNextLevel;
            experienceSlider.value = player.Stats.currExp / player.Stats.expToNextLevel;
        }
    }
}