using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour
{
    PlayerMovement playerMovement;
    bool moveRight = false;
    bool moveLeft = false;
    bool moveUp = false;
    bool moveDown = false;

    private void Start()
    {
        playerMovement = Player.instance.movement;
    }

    private void Update()
    {
        if (moveRight)
        {
            playerMovement.MoveRight();
        }
        else if(moveLeft)
        {
            playerMovement.MoveLeft();
        }
        else if(moveUp)
        {
            playerMovement.MoveUp();
        }
        else if(moveDown)
        {
            playerMovement.MoveDown();
        }
    }

    public void StartMoveRight()
    {
        moveRight = true;
    }

    public void StartMoveLeft()
    {
        moveLeft = true;
    }

    public void StartMoveUp()
    { 
        moveUp = true;
    }

    public void StartMoveDown()
    {
        moveDown = true;
    }
    public void StopMoveRight()
    {
        moveRight = false;
    }

    public void StopMoveLeft()
    {
        moveLeft = false;
    }

    public void StopMoveUp()
    {
        moveUp = false;
    }

    public void StopMoveDown()
    {
        moveDown = false;
    }
}
