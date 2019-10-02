using UnityEngine;

public class MoveArrows : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = Player.instance.movement;
    }

    public void MoveUp()
    {
        playerMovement.moveDirection = Vector2.up;
    }

    public void MoveDown()
    {
        playerMovement.moveDirection = Vector2.down;
    }

    public void MoveRight()
    {
        playerMovement.moveDirection = Vector2.right;
    }

    public void MoveLeft()
    {
        playerMovement.moveDirection = Vector2.left;
    }

    public void ResetMoveDirection()
    {
        playerMovement.moveDirection = Vector2.zero;
    }
}
