using UnityEngine;

namespace Medieval.Core
{
    public class Currency : MonoBehaviour
    {
        public int gold { get; set; }
        public int maxMoves { get; private set; }
        public int movesLeft { get; private set; }
        public int premium { get; set; }
    }
}