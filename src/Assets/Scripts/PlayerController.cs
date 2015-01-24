using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {
	void Update( ) {
		if (Input.GetButton("Left")) {
			this.GetComponent<PlayerMovement>().MoveLeft();
			this.GetComponentInChildren<Animator>().SetBool("Moving", true);
			this.GetComponentInChildren<Animator>().transform.localScale = new Vector3(-1, 1, 1);
		}
		if (Input.GetButton("Right")) {
			this.GetComponent<PlayerMovement>().MoveRight();
			this.GetComponentInChildren<Animator>().SetBool("Moving", true);
			this.GetComponentInChildren<Animator>().transform.localScale = new Vector3(1, 1, 1);
		}
		if ((!Input.GetButton("Left") && !Input.GetButton("Right")) || !this.GetComponent<PlayerMovement>().isGrounded) {
			this.GetComponentInChildren<Animator>().SetBool("Moving", false);
		}
		if (Input.GetButtonDown("Jump")) {
			this.GetComponent<PlayerMovement>().Jump();
		}
	}
}
