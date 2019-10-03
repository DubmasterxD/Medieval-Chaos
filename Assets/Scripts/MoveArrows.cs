using UnityEngine;

public class MoveArrows : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void MoveUp()
    {
        player.movement.moveDirection = Vector2.up;
    }

    public void MoveDown()
    {
        player.movement.moveDirection = Vector2.down;
    }

    public void MoveRight()
    {
        player.movement.moveDirection = Vector2.right;
    }

    public void MoveLeft()
    {
        player.movement.moveDirection = Vector2.left;
    }

    public void ResetMoveDirection()
    {
        player.movement.moveDirection = Vector2.zero;
    }
}
