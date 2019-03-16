using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1;
    bool isMoving = false;
    Animator anim = null;
    int _wallTrigger = Animator.StringToHash("wall");
    int _moveX = Animator.StringToHash("moveX");
    int _moveY = Animator.StringToHash("moveY");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GoRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft();
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            GoUp();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            GoDown();
        }
    }

    public void GoRight()
    {
        Move(new Vector2(1, 0));
    }

    public void GoLeft()
    {
        Move(new Vector2(-1, 0));
    }

    public void GoUp()
    {
        Move(new Vector2(0, 1));
    }

    public void GoDown()
    {
        Move(new Vector2(0, -1));
    }

    private void Move(Vector2 moveDirection)
    {
        if (!isMoving)
        {
            anim.SetFloat(_moveX, moveDirection.x);
            anim.SetFloat(_moveY, moveDirection.y);
            anim.speed = movementSpeed;
            isMoving = true;
        }
    }

    public void FinishedMovingX(float MoveX)
    {
        anim.SetFloat(_moveX, 0);
        transform.position = new Vector3(transform.position.x + MoveX, transform.position.y, 0);
        isMoving = false;
    }

    public void FinishedMovingY(float MoveY)
    {
        anim.SetFloat(_moveY, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y + MoveY, 0);
        isMoving = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetFloat(_moveX, 0);
        anim.SetFloat(_moveY, 0);
        anim.SetTrigger(_wallTrigger);
        isMoving = false;
    }
}
