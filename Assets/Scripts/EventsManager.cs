using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public delegate void IntInVoidOut(int value);

    public event IntInVoidOut onItemSelected;
    public event Action onConfirm;

    public void SelectItem(int index)
    {
        if (onItemSelected != null)
        {
            onItemSelected(index);
        }
    }

    public void Confirm()
    {
        if (onConfirm != null)
        {
            onConfirm();
        }
    }
}
