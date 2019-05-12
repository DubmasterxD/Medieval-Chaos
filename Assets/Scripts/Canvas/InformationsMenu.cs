using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationsMenu : MonoBehaviour
{
    public enum InfoTypes { Dismantle, Sell};
    public InfoTypes currentType = default;

    public void Confirm()
    {
        switch (currentType)
        {
            case InfoTypes.Dismantle:
                break;
            case InfoTypes.Sell:
                break;
            default:
                break;
        }
    }
}
