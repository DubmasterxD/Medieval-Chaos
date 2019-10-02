using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1;

    public Vector2 moveDirection { get; set; }

    public bool isMoving { get; private set; }

    Vector2 lastMoveDirection;

    int wallAnimatorID = Animator.StringToHash("wall");
    int moveXAnimatorID = Animator.StringToHash("moveX");
    int moveYAnimatorID = Animator.StringToHash("moveY");

    Animator animator;
    Actions actions;


    private void Start()
    {
        animator = GetComponent<Animator>();
        actions = GameManager.instance.actions;
        animator.speed = movementSpeed;
    }

    private void Update()
    {
        if (CanMove())
        {
            Move();
        }
    }

    private void Move()
    {
        lastMoveDirection = moveDirection;
        SetMoveAnimator(lastMoveDirection);
        ToggleMoving(true);
    }

    private bool CanMove()
    {
        return moveDirection != Vector2.zero && !isMoving;
    }

    public void FinishMovement()
    {
        SetMoveAnimator(Vector2.zero);
        ChangePosition();
        ToggleMoving(false);
        actions.SetNewAction();
    }

    private void ChangePosition()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += lastMoveDirection.x;
        newPosition.y += lastMoveDirection.y;
        transform.position = newPosition;
    }

    public void CancelMove()
    {
        SetMoveAnimator(Vector2.zero);
        animator.SetTrigger(wallAnimatorID);
        ToggleMoving(false);
    }

    private void SetMoveAnimator(Vector2 moveDirection)
    {
        animator.SetFloat(moveXAnimatorID, moveDirection.x);
        animator.SetFloat(moveYAnimatorID, moveDirection.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            CancelMove();
        }
    }

    private void ToggleMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }
}
