using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMenu : MonoBehaviour
{
    [SerializeField] GameObject inventory = null;
    [SerializeField] GameObject shop = null;
    [SerializeField] GameObject blacksmith = null;
    [SerializeField] GameObject stash = null;
    [SerializeField] GameObject quest = null;
    
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
