using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] Text levelText = null;
    [SerializeField] Text expValueText = null;
    [SerializeField] Slider expSlider = null;

    private Player player;

    public void RefreshStats()
    {
        levelText.text = "Lvl: " + player.stats.Level;
        expValueText.text = player.stats.currExp + "/" + player.stats.expToNextLevel;
        expSlider.value = player.stats.currExp / player.stats.expToNextLevel;
    }
}
