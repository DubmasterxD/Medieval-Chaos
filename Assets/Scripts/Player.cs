using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movement { get; private set; }
    public PlayerStats stats { get; private set; }
    public CurrencyController currency { get; private set; }
    public ItemsList items { get; private set; }

    [SerializeField] string nickname;
    public string previousScene { get; set; }
    public string Nickname { get => nickname; set => nickname = value; }

    private void Awake()
    {
        SetReferences();
    }

    private void SetReferences()
    {
        movement = GetComponent<PlayerMovement>();
        stats = GetComponent<PlayerStats>();
        currency = GetComponent<CurrencyController>();
        items = GetComponent<ItemsList>();
    }
}
