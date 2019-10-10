using UnityEngine;

public class UIItemSlot : MonoBehaviour
{
    public int index { get; set; } = 0;

    EventsManager eventsManager;

    private void Awake()
    {
        eventsManager = FindObjectOfType<EventsManager>();
    }

    public void SelectItem()
    {
        eventsManager.SelectItem(index);
    }
}
