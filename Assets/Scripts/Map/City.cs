using UnityEngine;

namespace Medieval.Map
{
    public class City : MonoBehaviour
    {
        Actions actions;

        private void Awake()
        {
            actions = FindObjectOfType<Actions>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                actions.isInCity = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            actions.isInCity = false;
        }
    }
}