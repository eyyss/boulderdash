
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public Vector2 gridSize = new Vector2(1f, 1f); // Size of each grid cell

    private Vector2 targetPosition;
    private float moveTimer;
    public float moveCoolDown;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public ControlTile leftTile, rightTile, upTile, downTile;

    public float pushTime = 1f;
    private float rockPushTimer;
    private void Start()
    {
        // Initialize target position to current position
        targetPosition = transform.position;
        moveTimer = moveCoolDown;
    }

    private void Update()
    {

        if (leftTile.hitRock || rightTile.hitRock)
        {
            rockPushTimer += Time.deltaTime;
        }


        // Handle movement input
        HandleInput();

        // Move towards the target position
        Move();

        PushRock(Input.GetAxisRaw("Horizontal"));
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

        if (inputX != 0) inputY = 0;
        if (inputY != 0) inputX = 0;





        if (leftTile.hitFrame || leftTile.hitRock)
        {
            inputX = Mathf.Clamp(inputX, 0, 1);
        }
        if (rightTile.hitFrame || rightTile.hitRock)
        {
            inputX = Mathf.Clamp(inputX, -1,0);
        }
        if (upTile.hitFrame || upTile.hitRock)
        {
            inputY = Mathf.Clamp(inputY, -1,0);    
        }
        if (downTile.hitFrame || downTile.hitRock)
        {
            inputY = Mathf.Clamp(inputY, 0, 1);
        }

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

    private void PushRock(float x)
    {
        if (leftTile.hitRock)
        {
            if (leftTile.hitObject == null) return;
            if (leftTile.hitObject.TryGetComponent(out Rock rock) && rockPushTimer >= pushTime)
            {
                rockPushTimer = 0;
                rock.Move(x);
            }
        }
        if (rightTile.hitRock)
        {
            if (rightTile.hitObject == null) return;
            if (rightTile.hitObject.TryGetComponent(out Rock rock) && rockPushTimer >= pushTime)
            {
                rockPushTimer = 0;
                rock.Move(x);
            }
        }
    }
}

