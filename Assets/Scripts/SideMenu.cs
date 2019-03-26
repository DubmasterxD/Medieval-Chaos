using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenu : MonoBehaviour
{
    Player player;

    [SerializeField] GameObject itemsSideMenu = null;
    [SerializeField] GameObject infoSideMenu = null;
    [SerializeField] GameObject inventoryMenu = null;
    [SerializeField] GameObject itemEquipMenu = null;
    [SerializeField] GameObject actionMenu = null;
    [SerializeField] GameObject questLogMenu = null;

    private void Start()
    {
        player = Player.instance;
    }

    public void ShowItemInfo()
    {
        itemsSideMenu.SetActive(false);
        infoSideMenu.SetActive(true);
    }

    public void ShowEquippedItems()
    {
        itemsSideMenu.SetActive(true);
        infoSideMenu.SetActive(false);
    }

    public void OpenItemChangeMenu()
    {
        if (!player.movement.isMoving)
        {
            ShowEquippedItems();
            itemEquipMenu.SetActive(true);
        }
    }

    public void OpenInventory()
    {
        if (!player.movement.isMoving)
        {
            inventoryMenu.SetActive(true);
        }
    }

    public void OpenQuestLog()
    {
        if (!player.movement.isMoving)
        {
            questLogMenu.SetActive(true);
        }
    }
    
    public void OpenActionDetailsMenu()
    {
        if (!player.movement.isMoving)
        {
            actionMenu.SetActive(true);
        }
    }
}
