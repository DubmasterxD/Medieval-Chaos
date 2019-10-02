using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public PlayerMovement movement { get; private set; }
    public PlayerStats stats { get; private set; }
    public CurrencyController currency { get; private set; }
    public ItemsList items { get; private set; }

    [SerializeField] string nickname;
    public string previousScene { get; set; }
    public string Nickname { get => nickname; set => nickname = value; }

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
        stats = GetComponent<PlayerStats>();
        currency = GetComponent<CurrencyController>();
        items = GetComponent<ItemsList>();
    }
}
