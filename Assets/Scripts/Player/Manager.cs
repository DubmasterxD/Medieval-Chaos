using UnityEngine;
using Medieval.Combat;
using Medieval.Core;

namespace Medieval.Player
{
    public class Manager : MonoBehaviour
    {
        public Mover movement { get; private set; }
        public PlayerStats stats { get; private set; }
        public Currency currency { get; private set; }
        public Items items { get; private set; }

        [SerializeField] string nickname;
        public string previousScene { get; set; }
        public string Nickname { get => nickname; set => nickname = value; }

        private void Awake()
        {
            SetReferences();
        }

        private void SetReferences()
        {
            movement = GetComponent<Mover>();
            stats = GetComponent<PlayerStats>();
            currency = GetComponent<Currency>();
            items = GetComponent<Items>();
        }
    }
}