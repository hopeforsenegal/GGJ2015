using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    void Update()
    {
        PlayerMovement movement = this.GetComponent<PlayerMovement>();
        if (movement.tag.CompareTo("PlayerOne") == 0)
        {
            if (Input.GetButton("OneLeft"))
            {
                Animator animator = this.GetComponentInChildren<Animator>();
                movement.MoveLeft();
                animator.SetBool("Moving", true);
                animator.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetButton("OneRight"))
            {
                Animator animator = this.GetComponentInChildren<Animator>();
                movement.MoveRight();
                animator.SetBool("Moving", true);
                animator.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((!Input.GetButton("OneLeft") && !Input.GetButton("OneRight")) || !movement.isGrounded)
            {
                this.GetComponentInChildren<Animator>().SetBool("Moving", false);
            }
            if (Input.GetButtonDown("OneJump") && movement.isGrounded)
            {
                movement.Jump();
            }
            if (Input.GetButtonDown("OneDuck") && movement.isGrounded)
            {
                movement.Duck();
                this.transform.Find("SpriteAnchor/Sprite").transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
            }
            if (Input.GetButtonUp("OneDuck"))
            {
                movement.Stand();
                this.transform.Find("SpriteAnchor/Sprite").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        else if (movement.tag.CompareTo("PlayerTwo") == 0)
        {
            if (Input.GetButton("TwoLeft"))
            {
                Animator animator = this.GetComponentInChildren<Animator>();
                movement.MoveLeft();
                animator.SetBool("Moving", true);
                animator.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetButton("TwoRight"))
            {
                Animator animator = this.GetComponentInChildren<Animator>();
                movement.MoveRight();
                animator.SetBool("Moving", true);
                animator.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((!Input.GetButton("TwoLeft") && !Input.GetButton("TwoRight")) || !movement.isGrounded)
            {
                this.GetComponentInChildren<Animator>().SetBool("Moving", false);
            }
            if (Input.GetButtonDown("TwoJump") && movement.isGrounded)
            {
                movement.Jump();
            }
            if (Input.GetButtonDown("TwoDuck") && movement.isGrounded)
            {
                movement.Duck();
                this.transform.Find("SpriteAnchor/Sprite").transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
            }
            if (Input.GetButtonUp("TwoDuck"))
            {
                movement.Stand();
                this.transform.Find("SpriteAnchor/Sprite").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
    }
}
