using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

	public float speed;
	public float jumpForce;
	private float moveInput;

	private Rigidbody2D rb;

	private bool facingRight = true;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private int extraJumps;
	public int extraJumpsValue;

	CharacterCreation cc;

	// Use this for initialization
	void Start () {
		//Instantiate(cc.models[PlayerPrefs.GetInt("CharacterSelected")]);

		extraJumps = extraJumpsValue;
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		//MOVEMENT
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);
		moveInput = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);

		//FLIPPING SPRITE
		if (facingRight == false && moveInput > 0) {

			Flip ();

		} else if (facingRight == true && moveInput < 0) {

			Flip ();

		}

		//JUMPING
		if (isGrounded == true) {
			extraJumps = extraJumpsValue;

		}

		if (Input.GetKeyDown (KeyCode.W) && extraJumps > 0) {

			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;

		}
	}

	void Flip(){

		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;

	}
}
