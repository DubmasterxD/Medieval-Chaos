using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEntrance : MonoBehaviour
{
    [SerializeField] string toScene = "";

    public string ToScene { get => toScene; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.instance.previousScene = GameManager.instance.GetComponent<SceneLoader>().GetCurrentScene();
            GameManager.instance.gameObject.GetComponent<SceneLoader>().ChangeScene(toScene);
        }
    }
}
