using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public int gold { get; set; }
    public int maxMoves { get; private set; }
    public int movesLeft { get; private set; }
    public int premium { get; set; }
}
