using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private const string SpritePath = "SpriteAnchor/Sprite";

    void Update()
    {
        PlayerMovement movement = this.GetComponent<PlayerMovement>();
        Animator animator = this.GetComponentInChildren<Animator>();

        if (movement.tag.CompareTo("PlayerOne") == 0)
        {
            if (Input.GetButton("OneLeft"))
            {
                movement.MoveLeft();
                animator.SetBool("Moving", true);
                animator.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetButton("OneRight"))
            {
                movement.MoveRight();
                animator.SetBool("Moving", true);
                animator.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((!Input.GetButton("OneLeft") && !Input.GetButton("OneRight")) || !movement.isGrounded)
            {
                animator.SetBool("Moving", false);
            }
            if (Input.GetButtonDown("OneJump"))
            {
                movement.Jump();
            }
            if (Input.GetButtonDown("OneDuck") && movement.isGrounded)
            {
                movement.Duck();
                this.transform.Find(SpritePath).transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
            }
            if (Input.GetButtonUp("OneDuck"))
            {
                movement.Stand();
                this.transform.Find(SpritePath).transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        else if (movement.tag.CompareTo("PlayerTwo") == 0)
        {
            if (Input.GetButton("TwoLeft"))
            {
                movement.MoveLeft();
                animator.SetBool("Moving", true);
                animator.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetButton("TwoRight"))
            {
                movement.MoveRight();
                animator.SetBool("Moving", true);
                animator.transform.localScale = new Vector3(1, 1, 1);
            }
            if ((!Input.GetButton("TwoLeft") && !Input.GetButton("TwoRight")) || !movement.isGrounded)
            {
                animator.SetBool("Moving", false);
            }
            if (Input.GetButtonDown("TwoJump"))
            {
                movement.Jump();
            }
            if (Input.GetButtonDown("TwoDuck") && movement.isGrounded)
            {
                movement.Duck();
                this.transform.Find(SpritePath).transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
            }
            if (Input.GetButtonUp("TwoDuck"))
            {
                movement.Stand();
                this.transform.Find(SpritePath).transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
    }
}
