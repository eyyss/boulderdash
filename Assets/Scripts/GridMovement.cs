using Unity.VisualScripting;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 gridSize = new Vector2(1f, 1f); // Size of each grid cell

    private Vector2 targetPosition;
    private float moveTimer;
    public float moveCoolDown;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private void Start()
    {
        // Initialize target position to current position
        targetPosition = transform.position;
        moveTimer = moveCoolDown;
    }

    private void Update()
    {
        // Handle movement input
        HandleInput();
        
        // Move towards the target position
        Move();
    }

    private void HandleInput()
    {
        // Capture input
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if (inputX != 0 || inputY != 0)
        {
            animator.SetBool("isMove", true);
        }
        else { animator.SetBool("isMove", false); }
        if(inputX > 0)
        {
            spriteRenderer.flipX = true;
                    }
        if (inputX < 0)
        {
            spriteRenderer.flipX = false;
        }
        
        // Calculate new target position based on input
        targetPosition = new Vector2(transform.position.x+inputX, transform.position.y + inputY) * gridSize;
    }

    private void Move()
    {
        // Move towards the target position
        moveTimer += Time.deltaTime;
        if (moveTimer > moveCoolDown)
        {
            moveTimer = 0;
            transform.position = targetPosition;
        }
      
    }
}

