using UnityEngine;
using Medieval.Player;

namespace Medieval.UI.Inventory
{
    public class TabChanger : MonoBehaviour
    {
        [SerializeField] Tab[] topTabs = null;

        InventoryTab[] inventoryTabs = null;

        Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
            InitializeInventoryTabs();
        }

        private void Start()
        {
            CloseAllTabs();
            OpenTab(0);
        }

        private void InitializeInventoryTabs()
        {
            inventoryTabs = new InventoryTab[topTabs.Length];
            foreach (InventoryTab tab in GetComponentsInChildren<InventoryTab>())
            {
                if (tab.Index < topTabs.Length)
                {
                    inventoryTabs[tab.Index] = tab;
                }
            }
        }

        public void OpenTab(int index)
        {
            if (index < inventoryTabs.Length)
            {
                CloseAllTabs();
                inventoryTabs[index].OpenTab();
                inventoryTabs[index].gameObject.SetActive(true);
                topTabs[index].ToggleHighlightActive(true);
            }
        }

        private void CloseAllTabs()
        {
            for (int i = 0; i < topTabs.Length; i++)
            {
                topTabs[i].ToggleHighlightActive(false);
                inventoryTabs[i].gameObject.SetActive(false);
            }
        }

        public void CloseWindow()
        {
            gameObject.SetActive(false);
        }
    }
}