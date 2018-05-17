using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	private Rigidbody2D rb;
	private SpriteRenderer sRenderer;
	private Animator animator;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.D)){
			rb.AddForce(Vector2.right * speed);
			sRenderer.flipX = false;
			animator.SetBool("IsWalking",true);
		}else if(Input.GetKey(KeyCode.A)){
			animator.SetBool("IsWalking",true);
			sRenderer.flipX = true;
			rb.AddForce(-Vector2.right * speed);
		}else{
			animator.SetBool("IsWalking",false);
		}
	}
}
