using UnityEngine;
using Medieval.Player;

namespace Medieval.Map
{
    public class TeleportExit : MonoBehaviour
    {
        [SerializeField] string fromScene = "";

        Manager player;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
        }

        private void Start()
        {
            if (transform.parent.gameObject.GetComponent<TeleportEntrance>())
            {
                fromScene = transform.parent.gameObject.GetComponent<TeleportEntrance>().ToScene;
            }
            if (player.previousScene == fromScene)
            {
                player.gameObject.transform.position = transform.position;
            }
        }
    }
}