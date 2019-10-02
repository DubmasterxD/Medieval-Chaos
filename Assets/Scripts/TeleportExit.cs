using UnityEngine;

public class TeleportExit : MonoBehaviour
{
    [SerializeField] string fromScene = "";

    private void Start()
    {
        if(transform.parent.gameObject.GetComponent<TeleportEntrance>())
        {
            fromScene = transform.parent.gameObject.GetComponent<TeleportEntrance>().ToScene;
        }
        if(Player.instance.previousScene == fromScene)
        {
            Player.instance.gameObject.transform.position = transform.position;
        }
    }
}
