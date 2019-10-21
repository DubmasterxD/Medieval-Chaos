using UnityEngine;
using UnityEngine.UI;
using Medieval.Player;

namespace Medieval.UI.Inventory
{
    public class Stats : InventoryTab
    {
        [SerializeField] Profile profile = null;
        [SerializeField] Currency currency = null;
        [SerializeField] UI.Stats stats = null;

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
            currency.Refresh();
            profile.Refresh();
            stats.Refresh();
        }
    }
}