using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sRenderer;
    private Animator animator;
	public float maxSpeed;
    public float speed;
    public float jumpForce;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            move(-Vector2.left);
        }
        else if (Input.GetKey(KeyCode.A))
        {
           move(Vector2.left);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }


        if (Input.GetKey(KeyCode.W) && animator.GetBool("IsGrounded"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.Play("salto");
        }

    }

    private void move(Vector2 direction)
    {
		if(rb.velocity.magnitude < maxSpeed && animator.GetBool("IsGrounded")){
			
		
        animator.SetBool("IsWalking", true);
        rb.AddForce(direction * speed);
        if (direction.x > 0)
        {
            sRenderer.flipX = false;
        }
        else
        {
            sRenderer.flipX = true;
        }
		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("IsGrounded", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("IsGrounded", false);
    }
}
