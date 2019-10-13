using UnityEngine;
using UnityEngine.UI;

public class StatsInventoryUI : InventoryUI
{
    [SerializeField] Text nicknameText = null;
    [SerializeField] LevelUI levelUI = null;
    [SerializeField] Text goldText = null;
    [SerializeField] StatsUI statsUI = null;

    private Player player;

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
