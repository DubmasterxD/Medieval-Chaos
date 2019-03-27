using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileMenu : MonoBehaviour
{
    [SerializeField] Text nicknameText = null;
    [SerializeField] Text levelText = null;
    [SerializeField] Text expValueText = null;
    [SerializeField] Slider expSlider = null;

    private void Start()
    {
        nicknameText.text = Player.instance.Nickname;
        levelText.text = "Lvl: " + Player.instance.stats.Level;
        expValueText.text = Player.instance.stats.currExp + "/" + Player.instance.stats.expToNextLevel;
        expSlider.value = Player.instance.stats.currExp / Player.instance.stats.expToNextLevel;
    }
}
