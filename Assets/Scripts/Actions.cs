using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] Encounters[] encounters = null;
    Encounters areaEncounters = null;
    string areaName ="";
    public bool isBossNearby { get; set; } = false;
    bool isInCity = false;
    bool isSpecialEncounter = false;
    bool isTreasure = false;
    Item treasure = null;
    Enemy enemy = null;
    public Enemy boss { get; set; } = null;

    private void Start()
    {
        AreaChanged("Test");
    }

    public void AreaChanged(string newAreaName)
    {
        areaName = newAreaName;
        int i = 0;
        while(areaName!=encounters[i].AreaName)
        {
            i++;
        }
        areaEncounters = encounters[i];
    }

    public void SetNewAction()
    {
        isTreasure = false;
        if(isBossNearby)
        {
            enemy = boss;
        }
        else if(isInCity)
        {

        }
        else if(isSpecialEncounter)
        {
            enemy = areaEncounters.RareEncounter;
        }
        else
        {
            if(areaEncounters.IsNewEncounterItem())
            {
                isTreasure = true;
                treasure = areaEncounters.NewTreasure();
            }
            else
            {
                enemy = areaEncounters.NewEnemy();
            }
        }
    }
}
