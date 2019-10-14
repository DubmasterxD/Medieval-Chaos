using UnityEngine;
using UnityEngine.UI;
using Medieval.Player;

namespace Medieval.UI
{
    public class Currency : MonoBehaviour
    {
        [SerializeField] Text goldText = null;
        [SerializeField] Text premiumText = null;
        [SerializeField] Text movesText = null;

        Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
        }

        void Start()
        {
            goldText.text = player.currency.gold.ToString();
            premiumText.text = player.currency.premium.ToString();
            movesText.text = player.currency.movesLeft + "/" + player.currency.maxMoves;
        }
    }
}