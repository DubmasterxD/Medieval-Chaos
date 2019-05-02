using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas instance;

    [SerializeField] GameObject overlay = null;
    [SerializeField] GameObject windows = null;
    [SerializeField] GameObject city = null;
    [SerializeField] GameObject map = null;
    [SerializeField] GameObject action = null;
    [SerializeField] GameObject dialogue = null;
    [SerializeField] GameObject informations = null;

    public GameObject Overlay { get => overlay; }
    public GameObject Windows { get => windows; }
    public GameObject City { get => city; }
    public GameObject Map { get => map; }
    public GameObject Action { get => action; }
    public GameObject Dialogue { get => dialogue; }
    public GameObject Informations { get => informations; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
