using UnityEngine;
using Medieval.Core;
using Medieval.Player;

namespace Medieval.Map
{
    public class TeleportEntrance : MonoBehaviour
    {
        [SerializeField] string toScene = "";

        public string ToScene { get => toScene; }

        Manager player;
        Actions actions;

        private void Awake()
        {
            player = FindObjectOfType<Manager>();
            actions = FindObjectOfType<Actions>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player.previousScene = Game.instance.GetComponent<Scenes>().GetCurrentScene();
                player.movement.CancelMove();
                Game.instance.gameObject.GetComponent<Scenes>().ChangeScene(toScene);
                actions.AreaChanged(ToScene);
                actions.SetNewAction();
            }
        }
    }
}