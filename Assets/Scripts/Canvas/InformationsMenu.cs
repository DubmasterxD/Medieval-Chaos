using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationsMenu : MonoBehaviour
{
    public enum InfoTypes { Dismantle, Sell};
    public InfoTypes currentType = default;

    CityMenu cityMenu;

    private void Start()
    {
        cityMenu = GameCanvas.instance.City.GetComponent<CityMenu>();
    }

    public void Confirm()
    {
        switch (currentType)
        {
            case InfoTypes.Dismantle:
                cityMenu.DismantleSelectedItem();
                break;
            case InfoTypes.Sell:
                cityMenu.SellSelectedItem();
                break;
            default:
                break;
        }
    }
}
