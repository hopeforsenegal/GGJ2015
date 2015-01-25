using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
	public float maxMoveSpeed;
	public float moveAcceleration;
	public float moveDeadzone;
	public float deceleration;
    public float jumpStrength;
    public float stickyJumpStrengthRatio;
    public float springyJumpStrengthRatio;
    public float slowMoveSpeedRatio;
    public float fastMoveSpeedRatio;

	public bool isGrounded {
		get {
            // Look down our height for the platform layer
            Collider2D hit = Physics2D.OverlapCircle((Vector2)collider2D.bounds.center - new Vector2(0, collider2D.bounds.extents.y), 0.30f, 1 << LayerMask.NameToLayer("Platform"));
            return hit != null;
		}
	}

	private bool moved;
    private bool jumped;
    private bool ducked;
	private bool hasDoubleJumped = false;
	private float currentMoveSpeed;
    private float currentAmplifyJumpStrength;
    private float currentAmplifyMoveSpeed;

    void Start()
    {
        ApplyNormalJump();
        ApplyNormalMovement();
    }

	void Update( ) {
		// jump if necessary
		float yVel = rigidbody2D.velocity.y;
		if (jumped) {
            yVel = currentAmplifyMoveSpeed * currentAmplifyJumpStrength * jumpStrength;
        }
		if (isGrounded) {
			hasDoubleJumped = false;
		}

		// update velocity
		rigidbody2D.velocity = new Vector2(currentMoveSpeed, yVel);
		if (!moved) {
			if (Mathf.Abs(currentMoveSpeed) < moveDeadzone) {
				currentMoveSpeed = 0;
			} else if (currentMoveSpeed < 0) {
				currentMoveSpeed += deceleration * Time.deltaTime;
			} else {
				currentMoveSpeed -= deceleration * Time.deltaTime;
			}
		}

        if (!isGrounded && rigidbody2D.velocity.y > 0)
        {
            foreach (DirectionalPlatform platforms in GameObject.FindObjectsOfType<DirectionalPlatform>())
            {
                if (collider2D.bounds.center.y < platforms.collider2D.bounds.center.y + 1.0f)
                {
                    platforms.BelowState();
                }
                else
                {
                    platforms.AboveState();
                }
            }
        }
		
		moved = false;
        jumped = false;
        ducked = false;
	}

    void ApplyStickyJump()
    {
        currentAmplifyJumpStrength = stickyJumpStrengthRatio;
    }

    void ApplySpringyJump()
    {
        currentAmplifyJumpStrength = springyJumpStrengthRatio;
    }

    void ApplyNormalJump()
    {
        currentAmplifyJumpStrength = 1.0f;
    }

    void ApplySlowMovement()
    {
        currentAmplifyMoveSpeed = slowMoveSpeedRatio;
    }

    void ApplyFastMovement()
    {
        currentAmplifyMoveSpeed = fastMoveSpeedRatio;
    }

    void ApplyNormalMovement()
    {
        currentAmplifyMoveSpeed = 1.0f;
    }

    public void MoveLeft()
    {
        if (!ducked)
        {
            moved = true;
            currentMoveSpeed -= moveAcceleration * Time.deltaTime;
            currentMoveSpeed = currentAmplifyMoveSpeed * Mathf.Max(-1 * maxMoveSpeed, currentMoveSpeed);
        }
	}

	public void MoveRight( ) {
        if (!ducked)
        {
            moved = true;
            currentMoveSpeed += moveAcceleration * Time.deltaTime;
            currentMoveSpeed = currentAmplifyMoveSpeed * Mathf.Min(maxMoveSpeed, currentMoveSpeed);
        }
	}

	public void Jump( ) {
		// Can only jump if grounded
		if(isGrounded){
            jumped = true;
		} else if (!hasDoubleJumped) {
			jumped = true;
			hasDoubleJumped = true;
		}
	}

    public void Duck()
    {
        // Can only duck if grounded
        if (isGrounded)
        {
            ducked = true;
        }
    }

    public void Stand()
    {
        ducked = false;
    }
}
