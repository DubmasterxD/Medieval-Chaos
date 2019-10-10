using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public delegate void IntInVoidOut(int value);

    public event IntInVoidOut onItemSelected;

    public void SelectItem(int index)
    {
        if (onItemSelected != null)
        {
            onItemSelected(index);
        }
    }
}
