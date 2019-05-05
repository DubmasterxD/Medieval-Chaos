using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityMenu : MonoBehaviour
{
    [SerializeField] GameObject inventory = null;
    [SerializeField] GameObject shop = null;
    [SerializeField] GameObject blacksmith = null;
    [SerializeField] GameObject stash = null;
    [SerializeField] GameObject quest = null;
    [Header("Inventory")]
    [SerializeField] GameObject allItemsMenuButtonHighlight = null;
    [SerializeField] GameObject weaponItemsMenuButtonHighlight = null;
    [SerializeField] GameObject armorItemsMenuButtonHighlight = null;
    [SerializeField] GameObject accessoryItemsMenuButtonHighlight = null;
    [SerializeField] GameObject miscItemsMenuButtonHighlight = null;
    [SerializeField] Text SlotsText = null;
    [SerializeField] GameObject[] itemSlots = null;
    [SerializeField] Image selectedItemImage = null;
    [SerializeField] Text selectedItemName = null;
    [SerializeField] Text selectedItemDescription = null;

    private PlayerStats playerStats;
    private ItemsList playerItems;

    private void Start()
    {
        playerStats = Player.instance.stats;
        playerItems = Player.instance.items;
    }

    public void OpenStash()
    {
        CloseAll();
        stash.SetActive(true);
    }

    public void OpenBlacksmith()
    {
        CloseAll();
        blacksmith.SetActive(true);
    }

    public void OpenShop()
    {
        CloseAll();
        shop.SetActive(true);
    }

    public void OpenInventory()
    {
        CloseAll();
        inventory.SetActive(true);
    }

    public void CloseAll()
    {
        inventory.SetActive(false);
        shop.SetActive(false);
        blacksmith.SetActive(false);
        stash.SetActive(false);
    }

    public void ExitCity()
    {
        CloseAll();
        this.gameObject.SetActive(false);
    }
}
