using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
	public float rotationSpeed;
	public float movementSpeed;
	public float rotationTime;


	public GameObject target;

	public float rand;
	public GameObject enemyGraphic;
	bool canFlip = true;
	bool facingRight = false;
	float flipTime = 2f;
	float nextFlipChance = 0f;

	//attacking
	public float chargeTime;
	float startChargeTime;
	bool charging;
	Rigidbody2D enemyRB;

	public GameObject AI;
	Animator anim;

	// Use this for initialization
	void Start(){
		Invoke ("ChangeRotation", rotationTime);
		anim = GetComponent<Animator> ();
		enemyRB = GetComponent<Rigidbody2D> ();


	}

	void ChangeRotation(){
		if (Random.value > 0.5f) {
			rotationSpeed = -rotationSpeed;
		}

		Invoke ("ChangeRotation", rotationTime);
	}

	void Update(){

		if (Time.time > nextFlipChance) {

			if (Random.Range (0, 10) >= 5)FlipFacing ();

			nextFlipChance = Time.time + flipTime;
			//enemyRB.transform.position = new Vector2 (Random.Range (10, 50) * Time.deltaTime, -2.7f);


		}

		rand = Random.Range (0, 10);
		transform.Rotate (new Vector3 (0, 0, rotationSpeed * Time.deltaTime));
		if (rand >= 5) {
			transform.position += transform.up * movementSpeed * Time.deltaTime;

		}
		else if (rand <= 4) {
			transform.position -= transform.up * movementSpeed * Time.deltaTime;
		}

		//anim.SetFloat ("speed", Mathf.Abs (movementSpeed)); //tells animator to use walking animation
	}

	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "Player") {

			if (startChargeTime < Time.time) {

				if (!facingRight) {

					Debug.Log ("ADDFORCE -1");
					//.position = target.transform.position;
					enemyRB.AddForce (new Vector2 (-10, 0) * movementSpeed);



				} else if(facingRight) {
					Debug.Log ("ADDFORCE + 1");
					//transform.position = target.transform.position;

					enemyRB.AddForce (new Vector2 (10, 0) * movementSpeed);

				}

				//enemyAnimator.SetBool ("isCharging", charging);
			}

		}

	}

	void OnTriggerExit2D(Collider2D other){

		if (other.tag == "Player") {
			Debug.Log ("exit collide");
			canFlip = true;
			charging = false;
			enemyRB.velocity = new Vector2 (0f, 0f);
			//enemyAnimator.SetBool ("isChargining", charging);

		}

	}
	void FlipFacing(){

		if (!canFlip) {

			return;

		}

		float facingX = enemyGraphic.transform.localScale.x;
		facingX *= -1f;
		enemyGraphic.transform.localScale = new Vector3 (facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
		facingRight = !facingRight;

	}
}
