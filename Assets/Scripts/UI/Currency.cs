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
            Refresh();
        }

        public void Refresh()
        {
            if (gold != null)
            {
                gold.text = player.currency.gold.ToString();
            }
            if (premium != null)
            {
                premium.text = player.currency.premium.ToString();
            }
            if (moves != null)
            {
                moves.text = player.currency.movesLeft + "/" + player.currency.maxMoves;
            }
        }
    }
}