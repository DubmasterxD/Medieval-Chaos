using UnityEngine;

namespace Medieval.Map
{
    public class BossEncounter : MonoBehaviour
    {
        [SerializeField] Enemy boss = null;

        Actions actions;

        private void Awake()
        {
            actions = FindObjectOfType<Actions>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                actions.isBossNearby = true;
                actions.boss = boss;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            actions.isBossNearby = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                actions.isBossNearby = true;
            }
        }
    }
}