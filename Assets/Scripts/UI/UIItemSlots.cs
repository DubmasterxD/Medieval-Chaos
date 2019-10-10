using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlots : MonoBehaviour
{
    [SerializeField] UIItemSlot itemSlotPrefab = null;
    List<UIItemSlot> itemSlots = null;

    public int selectedItemIndex { get; set; } = 0;
    bool created = false;

    Player player;
    
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void CreateItemSlots()
    {
        if (!created)
        {
            itemSlots = new List<UIItemSlot>();
            for (int i = 0; i < player.items.InventoryItemSlots; i++)
            {
                UIItemSlot itemSlot = Instantiate(itemSlotPrefab, transform);
                itemSlot.index = i;
                itemSlots.Add(itemSlot);
            }
            created = true;
        }
    }

    public void LoadItems()
    {
        player.items.SortInventory();
        for (int i = 0; i < player.items.InventoryItemSlots; i++)
        {
            itemSlots[i].GetComponentInChildren<Text>().text = "";
            if (player.items.InventoryItems[i] == null)
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].sprite = null;
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].sprite = player.items.InventoryItems[i].Image;
                if (player.items.InventoryItems[i].Type == ItemsList.itemTypes.Misc)
                {
                    itemSlots[i].GetComponentInChildren<Text>().text = player.items.InventoryItems[i].Amount.ToString();
                }
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.white;
            }
        }
    }

    public void ShowSpecificItems(ItemsList.itemTypes[] itemTypes)
    {
        for (int i = 0; i < player.items.InventoryItemSlots; i++)
        {
            if (player.items.InventoryItems[i] == null)
            {
                itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
            }
            else
            {
                bool isOfSearchingType = false;
                foreach (ItemsList.itemTypes type in itemTypes)
                {
                    if (player.items.InventoryItems[i].Type == type)
                    {
                        isOfSearchingType = true;
                    }
                }
                if (isOfSearchingType)
                {
                    itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.white;
                }
                else
                {
                    itemSlots[i].GetComponentsInChildren<Image>()[1].color = Color.black;
                }
            }
        }
    }

    public bool CanSelect(int index)
    {
        return player.items.InventoryItems[index] == null || itemSlots[index].GetComponentsInChildren<Image>()[1].color != Color.black;
    }
}
