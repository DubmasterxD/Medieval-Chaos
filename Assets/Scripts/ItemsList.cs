using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public enum itemTypes { Weapon, Shield, Armor, Neckle, Boots, Gloves, Ring, Helmet, Artifact };
    public enum itemRarity { Common, Uncommon, Rare, Legendary, Unique };
    [SerializeField] int itemSlots = 50;
    [SerializeField] Item equippedWeapon;
    [SerializeField] Item equippedArmor;
    [SerializeField] Item equippedShield;
    [SerializeField] Item equippedRing;
    [SerializeField] Item equippedNeckle;
    [SerializeField] Item equippedBoots;
    [SerializeField] Item equippedGloves;
    [SerializeField] Item equippedArtifact;
    [SerializeField] Item equippedHelmet;
    [SerializeField] Item[] inventoryItems;
    [SerializeField] Item[] referenceItems;

    public Item EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }
    public Item EquippedArmor { get => equippedArmor; set => equippedArmor = value; }
    public Item EquippedShield { get => equippedShield; set => equippedShield = value; }
    public Item EquippedRing { get => equippedRing; set => equippedRing = value; }
    public Item EquippedNeckle { get => equippedNeckle; set => equippedNeckle = value; }
    public Item EquippedBoots { get => equippedBoots; set => equippedBoots = value; }
    public Item EquippedGloves { get => equippedGloves; set => equippedGloves = value; }
    public Item EquippedArtifact { get => equippedArtifact; set => equippedArtifact = value; }
    public Item EquippedHelmet { get => equippedHelmet; set => equippedHelmet = value; }

    private void Start()
    {
        inventoryItems = new Item[itemSlots];
    }
}
