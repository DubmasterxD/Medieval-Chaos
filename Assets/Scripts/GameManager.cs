using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Actions actions;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            actions = GetComponent<Actions>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
