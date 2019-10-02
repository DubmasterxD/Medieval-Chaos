using UnityEngine;

public class City : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.actions.isInCity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.instance.actions.isInCity = false;
    }
}
