using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipMenu : MonoBehaviour
{
    [SerializeField] GameObject itemEquipMenu = null;

    public void CloseWindow()
    {
        itemEquipMenu.SetActive(false);
    }
}
