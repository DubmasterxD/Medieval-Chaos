using UnityEngine;

public class InformationsMenu : MonoBehaviour
{
    public enum InfoTypes { Dismantle, Sell};
    public InfoTypes currentType = default;

    CityMenu cityMenu;

    private void Start()
    {
        cityMenu = FindObjectOfType<CityMenu>();
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
