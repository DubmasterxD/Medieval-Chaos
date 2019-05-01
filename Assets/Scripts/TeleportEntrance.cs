using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEntrance : MonoBehaviour
{
    [SerializeField] string toScene = "";

    public string ToScene { get => toScene; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.previousScene = GameManager.instance.GetComponent<SceneLoader>().GetCurrentScene();
            Player.instance.movement.HitWall();
            GameManager.instance.gameObject.GetComponent<SceneLoader>().ChangeScene(toScene);
            GameManager.instance.actions.AreaChanged(ToScene);
            GameManager.instance.actions.SetNewAction();
        }
    }
}
