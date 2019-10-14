using UnityEngine;
using UnityEngine.UI;
using Medieval.Core;
using Medieval.UI;

namespace Medieval.Map
{
    public class Actions : MonoBehaviour
    {
        [SerializeField] Encounters[] encounters = null;
        Encounters areaEncounters = null;
        string areaName = "";
        public bool isBossNearby { get; set; } = false;
        public bool isInCity { get; set; } = false;
        public bool isSpecialEncounter { get; set; } = false;
        public bool isTreasure { get; set; } = false;
        Item treasure = null;
        Enemy enemy = null;
        public Enemy boss { get; set; } = null;
        Text actionButtonText = null;
        GameObject city = null;

        private void Start()
        {
            AreaChanged("Test");
            actionButtonText = FindObjectOfType<Side>().ActionButton.GetComponentInChildren<Text>();
        }

        public void AreaChanged(string newAreaName)
        {
            areaName = newAreaName;
            int i = 0;
            while (areaName != encounters[i].AreaName)
            {
                i++;
            }
            areaEncounters = encounters[i];
        }

        public void SetNewAction()
        {
            isTreasure = false;
            if (isBossNearby)
            {
                enemy = boss;
                actionButtonText.text = "Boss fight";
            }
            else if (isInCity)
            {
                actionButtonText.text = "Enter city";
            }
            else if (isSpecialEncounter)
            {
                enemy = areaEncounters.RareEncounter;
                actionButtonText.text = "Rare fight";
            }
            else if (areaEncounters.IsNewEncounterItem())
            {
                isTreasure = true;
                treasure = areaEncounters.NewTreasure();
                actionButtonText.text = "Treasure";
            }
            else
            {
                enemy = areaEncounters.NewEnemy();
                actionButtonText.text = "Fight";
            }
        }
    }
}