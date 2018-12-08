using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICollision : MonoBehaviour {

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

	void Start () {
	}

// Update is called once per frame
	void FixedUpdate () {

		//MOVEMENT
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);


}
}
