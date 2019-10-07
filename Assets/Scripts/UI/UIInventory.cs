using UnityEngine;

public abstract class UIInventory : MonoBehaviour
{
    [SerializeField] int index = 0;

    public int Index { get => index; }

    public abstract void OpenTab();
}
