using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public enum itemTypes { Sword, Shield, Armor, Neckle, Boots, Gloves, Ring, Antique };
    public enum itemRarity { Common, Uncommon, Rare, Legendary, Unique };
    [SerializeField] int itemSlots = 50;
    Item[] equippedItems;
    [SerializeField] Item[] referenceItems;
}
