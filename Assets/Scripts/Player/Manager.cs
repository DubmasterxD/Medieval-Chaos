using UnityEngine;
using Medieval.Combat;
using Medieval.Core;

namespace Medieval.Player
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] string nickname;
        [SerializeField] Stats stats = null;
        public string previousScene { get; set; }
        public Mover movement { get; private set; }
        public Currency currency { get; private set; }
        public Items items { get; private set; }

        public string Nickname { get => nickname; set => nickname = value; }
        public Stats Stats { get => stats; set => stats = value; }

        private void Awake()
        {
            SetReferences();
        }

        private void SetReferences()
        {
            movement = GetComponent<Mover>();
            currency = GetComponent<Currency>();
            items = GetComponent<Items>();
        }
    }
}