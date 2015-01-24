using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
	public float maxMoveSpeed;
	public float moveAcceleration;
	public float moveDeadzone;
	public float deceleration;
	public float jumpStrength;

	public bool isGrounded {
		get {
            // Look down our height for the platform layer
            Collider2D hit = Physics2D.OverlapCircle((Vector2)collider2D.bounds.center - new Vector2(0, collider2D.bounds.extents.y), 0.05f, 1 << LayerMask.NameToLayer("Platform"));
            return hit != null;
		}
	}

	private float currentMoveSpeed;
	private bool moved;
	private bool jumped;

	void Update( ) {
		// jump if necessary
		float yVel = rigidbody2D.velocity.y;
		if (jumped) {
			yVel += jumpStrength;
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
		
		moved = false;
		jumped = false;
	}

	public void MoveLeft( ) {
		moved = true;
		currentMoveSpeed -= moveAcceleration * Time.deltaTime;
		currentMoveSpeed = Mathf.Max(-1 * maxMoveSpeed, currentMoveSpeed);
	}
	public void MoveRight( ) {
		moved = true;
		currentMoveSpeed += moveAcceleration * Time.deltaTime;
		currentMoveSpeed = Mathf.Min(maxMoveSpeed, currentMoveSpeed);
	}
	public void Jump( ) {
		// Can only jump if grounded
		if(isGrounded){
			jumped = true;
		}
	}
}
