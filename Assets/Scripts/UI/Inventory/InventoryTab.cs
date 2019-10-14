using UnityEngine;

namespace Medieval.UI.Inventory
{
    public abstract class InventoryTab : MonoBehaviour
    {
        [SerializeField] int index = 0;

        public int Index { get => index; }

        public abstract void OpenTab();
    }
}