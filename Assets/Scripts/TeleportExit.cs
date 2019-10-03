using UnityEngine;

public class TeleportExit : MonoBehaviour
{
    [SerializeField] string fromScene = "";

    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        if(transform.parent.gameObject.GetComponent<TeleportEntrance>())
        {
            fromScene = transform.parent.gameObject.GetComponent<TeleportEntrance>().ToScene;
        }
        if(player.previousScene == fromScene)
        {
            player.gameObject.transform.position = transform.position;
        }
    }
}
