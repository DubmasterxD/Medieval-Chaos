using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEncounter : MonoBehaviour
{
    [SerializeField] Enemy boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.actions.isBossNearby = true;
            GameManager.instance.actions.boss = boss;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.instance.actions.isBossNearby = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.actions.isBossNearby = true;
        }
    }
}
