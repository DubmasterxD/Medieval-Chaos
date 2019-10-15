using UnityEngine;
using UnityEngine.UI;
using Medieval.Player;

namespace Medieval.UI
{
    public class Currency : MonoBehaviour
    {
        [SerializeField] Text gold = null;
        [SerializeField] Text premium = null;
        [SerializeField] Text moves = null;

        Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
        }

        void Start()
        {
            gold.text = player.currency.gold.ToString();
            premium.text = player.currency.premium.ToString();
            moves.text = player.currency.movesLeft + "/" + player.currency.maxMoves;
        }
    }
}