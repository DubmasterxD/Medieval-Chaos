using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] Encounters[] encounters;
    string areaName;
    bool isBossNearby = false;
    bool isInCity = false;
    bool isSpecialEncounter = false;

    public void SetNewAction()
    {
        if(isBossNearby)
        {

        }
        else if(isInCity)
        {

        }
        else if(isSpecialEncounter)
        {

        }
        else
        {

        }
    }
}
