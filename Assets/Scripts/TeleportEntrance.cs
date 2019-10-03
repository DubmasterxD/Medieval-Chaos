using UnityEngine;

public class TeleportEntrance : MonoBehaviour
{
    [SerializeField] string toScene = "";

    public string ToScene { get => toScene; }

    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.previousScene = GameManager.instance.GetComponent<SceneLoader>().GetCurrentScene();
            player.movement.CancelMove();
            GameManager.instance.gameObject.GetComponent<SceneLoader>().ChangeScene(toScene);
            GameManager.instance.actions.AreaChanged(ToScene);
            GameManager.instance.actions.SetNewAction();
        }
    }
}
