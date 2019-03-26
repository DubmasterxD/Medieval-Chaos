using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public PlayerMovement movement { get; private set; }

    public string previousScene { get; set; }

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SetReferences();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SetReferences()
    {
        movement = GetComponent<PlayerMovement>();
    }
}
