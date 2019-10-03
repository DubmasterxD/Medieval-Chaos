using UnityEngine;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour
{
    [SerializeField] Text goldText = null;
    [SerializeField] Text premiumText = null;
    [SerializeField] Text movesText = null;

    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        goldText.text = player.currency.gold.ToString();
        premiumText.text = player.currency.premium.ToString();
        movesText.text = player.currency.movesLeft + "/" + player.currency.maxMoves;
    }
}
