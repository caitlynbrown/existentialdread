using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	// Use this for initialization
	void Start () {
		
		facingRight = true; 
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () { //to prevent FPS jumping with multiplayer

	
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		HandleMovement (horizontal, vertical);
		Flip (horizontal);
		Debug.Log ("here0");

	}

	private void HandleMovement(float horizontal, float vertical){
	

		myRigidBody.velocity = new Vector2 (horizontal * movementSpeed, myRigidBody.velocity.y);


		myAnimator.SetFloat ("speed", Mathf.Abs(horizontal));
		Debug.Log ("here1");

		if (Input.GetKeyDown("space")) {
		
			myRigidBody.velocity = new Vector2 (horizontal * movementSpeed, vertical);

		
		}


	}

	private void Flip(float horizontal){

		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
		
			facingRight = !facingRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1; //flips
			transform.localScale  = scale;

		}
	}
}
