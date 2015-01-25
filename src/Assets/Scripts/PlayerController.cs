using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {
	void Update( ) {

        if (this.GetComponent<PlayerMovement>().tag.CompareTo("PlayerOne") == 0)
        {
            if (Input.GetButton("OneLeft"))
            {
                this.GetComponent<PlayerMovement>().MoveLeft();
                this.GetComponentInChildren<Animator>().SetBool("Moving", true);
                this.GetComponentInChildren<Animator>().transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetButton("OneRight"))
            {Debug.Log("pressed");
                this.GetComponent<PlayerMovement>().MoveRight();
                this.GetComponentInChildren<Animator>().SetBool("Moving", true);
                this.GetComponentInChildren<Animator>().transform.localScale = new Vector3(1, 1, 1);
            }
            if ((!Input.GetButton("OneLeft") && !Input.GetButton("OneRight")) || !this.GetComponent<PlayerMovement>().isGrounded)
            {
                this.GetComponentInChildren<Animator>().SetBool("Moving", false);
            }
            if (Input.GetButtonDown("OneJump"))
            {
                this.GetComponent<PlayerMovement>().Jump();
            }
        }
        else if (this.GetComponent<PlayerMovement>().tag.CompareTo("PlayerTwo") == 0)
        {
            if (Input.GetButton("TwoLeft"))
            {
                this.GetComponent<PlayerMovement>().MoveLeft();
                this.GetComponentInChildren<Animator>().SetBool("Moving", true);
                this.GetComponentInChildren<Animator>().transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetButton("TwoRight"))
            {
                this.GetComponent<PlayerMovement>().MoveRight();
                this.GetComponentInChildren<Animator>().SetBool("Moving", true);
                this.GetComponentInChildren<Animator>().transform.localScale = new Vector3(1, 1, 1);
            }
            if ((!Input.GetButton("TwoLeft") && !Input.GetButton("TwoRight")) || !this.GetComponent<PlayerMovement>().isGrounded)
            {
                this.GetComponentInChildren<Animator>().SetBool("Moving", false);
            }
            if (Input.GetButtonDown("TwoJump"))
            {
                this.GetComponent<PlayerMovement>().Jump();
            }
        }
	}
}
