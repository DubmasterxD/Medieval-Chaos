using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipMenu : MonoBehaviour
{
    [SerializeField] GameObject itemEquipMenu;

    public void CloseWindow()
    {
        itemEquipMenu.SetActive(false);
    }
}
