using UnityEngine;
using UnityEngine.UI;

public class ProfileMenu : MonoBehaviour
{
    [SerializeField] Text nicknameText = null;
    [SerializeField] Text levelText = null;
    [SerializeField] Text expValueText = null;
    [SerializeField] Slider expSlider = null;

    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        nicknameText.text = player.Nickname;
        levelText.text = "Lvl: " + player.stats.Level;
        expValueText.text = player.stats.currExp + "/" + player.stats.expToNextLevel;
        expSlider.value = player.stats.currExp / player.stats.expToNextLevel;
    }
}
