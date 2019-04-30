using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour
{
    [SerializeField] Text goldText = null;
    [SerializeField] Text premiumText = null;
    [SerializeField] Text movesText = null;

    void Start()
    {
        goldText.text = Player.instance.currency.gold.ToString();
        premiumText.text = Player.instance.currency.premium.ToString();
        movesText.text = Player.instance.currency.movesLeft + "/" + Player.instance.currency.maxMoves;
    }
}
