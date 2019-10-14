using UnityEngine;

namespace Medieval.UI
{
    public class Action : MonoBehaviour
    {
        [SerializeField] GameObject actionInfo = null;
        [SerializeField] GameObject actionFight = null;
        [SerializeField] GameObject actionTreasure = null;

        public GameObject ActionInfo { get => actionInfo; set => actionInfo = value; }
        public GameObject ActionFight { get => actionFight; set => actionFight = value; }
        public GameObject ActionTreasure { get => actionTreasure; set => actionTreasure = value; }
    }
}