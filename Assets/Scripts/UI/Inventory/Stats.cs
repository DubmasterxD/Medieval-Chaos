using UnityEngine;
using UnityEngine.UI;
using Medieval.Player;

namespace Medieval.UI.Inventory
{
    public class Stats : InventoryTab
    {
        [SerializeField] Text nicknameText = null;
        [SerializeField] Level levelUI = null;
        [SerializeField] Text goldText = null;
        [SerializeField] UI.Stats statsUI = null;

        private Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
        }

        public override void OpenTab()
        {
            RefreshStats();
        }

        public void RefreshStats()
        {
            RefreshProfileStats();
            levelUI.RefreshStats();
            statsUI.RefreshStats();
        }

        private void RefreshProfileStats()
        {
            nicknameText.text = player.Nickname;
            goldText.text = player.currency.gold.ToString();
        }
    }
}