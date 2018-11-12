using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

	public float enemySpeed;

	//Animator enemyAnimator;

	//facing
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

	private void Awake(){
		AI.SetActive (true);

		if (this.tag == "AI") {
		
			this.gameObject.SetActive (true);
		}

	}
		
	
	// Use this for initialization
	void Start () {
		//enemyAnimator = GetComponent<Animator> ();
		AI.SetActive (true);

		enemyRB = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFlipChance) {
		
			if (Random.Range (0, 10) >= 5)FlipFacing ();

			nextFlipChance = Time.time + flipTime;
			//enemyRB.transform.position = new Vector2 (Random.Range (10, 50) * Time.deltaTime, -2.7f);


		}
	}

	void OnTriggerEnter2D(Collider2D other){
	
		if (other.tag == "Player") {
			if (facingRight && other.transform.position.x < transform.position.x) {
				Debug.Log ("flip1");
				FlipFacing ();
			
			} else if (!facingRight && other.transform.position.x > transform.position.x) {
				Debug.Log ("flip2");
				FlipFacing ();
			
			}

			canFlip = false;
			charging = true;
			startChargeTime = Time.time + chargeTime;


	
		}
	}

	void OnTriggerStay2D(Collider2D other){
	
		if (other.tag == "Player") {
		
			if (startChargeTime < Time.time) {
			
				if (!facingRight) {

					Debug.Log ("ADDFORCE -1");
					enemyRB.AddForce (new Vector2 (-10, 0) * enemySpeed);


				
				} else if(facingRight) {
					Debug.Log ("ADDFORCE + 1");
						enemyRB.AddForce (new Vector2 (10, 0) * enemySpeed);
				
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
