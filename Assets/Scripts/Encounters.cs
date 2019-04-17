using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounters : ScriptableObject
{
    [SerializeField] string areaName;
    [SerializeField] Enemy[] enemies;
    [SerializeField] float[] enemiesChances;
    [SerializeField] Item[] items;
    [SerializeField] float[] itemsChances;
    [SerializeField] Enemy rareEncounter;
    [SerializeField] float chanceToEnemy;
    [SerializeField] float chanceToItem;
    [SerializeField] float chanceToRare;
}
