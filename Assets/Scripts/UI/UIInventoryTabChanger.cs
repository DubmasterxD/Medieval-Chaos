using UnityEngine;

public class UIInventoryTabChanger : MonoBehaviour
{
    [SerializeField] UITab[] topTabs = null;

    UIInventory[] inventoryTabs = null;

    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        InitializeInventoryTabs();
    }

    private void Start()
    {
        CloseAllTabs();
        OpenTab(0);
    }

    private void InitializeInventoryTabs()
    {
        inventoryTabs = new UIInventory[topTabs.Length];
        foreach(UIInventory tab in GetComponentsInChildren<UIInventory>())
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
        for(int i=0; i < topTabs.Length; i++)
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
