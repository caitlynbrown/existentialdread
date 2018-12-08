using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class controller : NetworkBehaviour {

	public float speed;
	public float jumpForce;
	private float moveInput;
	private Health health;
	public Sprite fillerSprite;

	private static Random r = new Random();
	public Color col;

	public GameObject projectilePrefab;
	public Transform projectileSpawn;

	private Rigidbody2D rb;
	private Rigidbody2D rbProjectile;

	private bool facingRight = true;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private int extraJumps;
	public int extraJumpsValue;

	public List<GameObject> pickups;

	CharacterCreation cc;

	private GameObject[] players;
	// Use this for initialization
	void Start () {
		//Instantiate(cc.models[PlayerPrefs.GetInt("CharacterSelected")]);


		extraJumps = extraJumpsValue;
		rb = GetComponent<Rigidbody2D> ();
		health = GetComponent<Health> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

	

		//players = GameObject.FindGameObjectsWithTag ("Player");
		//foreach (GameObject p in players) {
		//	if (p.gameObject.GetComponent<NetworkIdentity> ().isLocalPlayer == false) {
		//		p.gameObject.GetComponent<SpriteRenderer> ().sprite = fillerSprite;
		//	}
		//}

		if (!isLocalPlayer) {
			return;
		}


		//if (Input.GetKeyDown (KeyCode.Space)) {
		//	CmdFire ();
		//}

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
		
	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "AIHitbox") {
			//Debug.Log ("hit");
			this.health.TakeDamage (1);
		} else if (col.tag == "pickup") {
			Debug.Log ("Fruit Hit");

			if (col.gameObject == GameObject.Find ("cherry(Clone)")) {
				Debug.Log ("Cherry");
				this.health.RecoverHealth (30);
			} else if (col.gameObject == GameObject.Find ("orange(Clone)")) {
				Debug.Log ("Orange");
				this.health.RecoverHealth (10);
			} else if (col.gameObject == GameObject.Find ("pear(Clone)")) {
				Debug.Log ("Pear");
				this.health.RecoverHealth (5);
			} else if (col.gameObject == GameObject.Find ("peach(Clone)")) {
				Debug.Log ("Peach");
				this.health.RecoverHealth (15);
			} else if (col.gameObject == GameObject.Find ("apple(Clone)")) {
				Debug.Log ("Apple");
				this.health.RecoverHealth (20);
			}
			Destroy (col.gameObject);

		} else if (col.tag == "projectile") {
			this.health.TakeDamage (1);

		} 

		else if (col.gameObject.tag == "Player" && col.GetComponent<NetworkIdentity>().isLocalPlayer == false) {
			if (Input.GetMouseButtonUp(0)) {
				Debug.Log ("hit");
				col.gameObject.GetComponent<Health> ().TakeDamage (5);
			}
		}
//		else if(col.tag == "Player"){
//			if () {
//				return;
//			}
//			else{
//				
//			}
//		}

	}

//	[Command]
//	void CmdFire(){
//
//		var projectile = (GameObject)Instantiate (projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
//		if (facingRight == true) {
//			col = new Color (Random.Range (.2F, 2F), Random.Range (.2F, 2F), Random.Range (.2F, 2F));
//			projectile.GetComponent<SpriteRenderer> ().color = col;
//			projectile.GetComponent<Rigidbody2D> ().velocity = projectile.transform.right * 20;
//		}
//		if (facingRight == false) {
//			col = new Color (Random.Range (.2F, 2F), Random.Range (.2F, 2F), Random.Range (.2F, 2F));
//			projectile.GetComponent<SpriteRenderer> ().color = col;
//			projectile.GetComponent<Rigidbody2D> ().velocity = -projectile.transform.right * 20;
//		}
//
//		NetworkServer.Spawn (projectile);
//		Destroy (projectile, 2.0f);
//
//	}
}
