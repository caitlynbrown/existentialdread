using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class owl : MonoBehaviour {

	public float speed = 0.5f;

	private GameObject ground;
	private bool down;
	private bool caught;

	// Use this for initialization
	void Start () {
		ground = GameObject.Find ("ground");
		down = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (down) {
			this.gameObject.transform.Translate (0, -speed, 0);

			if (transform.position.y <= ground.transform.position.y + 1) {
				Debug.Log ("go up");
				down = false;
			}
		} else if (transform.position.y >= 20) {
			Destroy (this.gameObject);
		}
		else {
			this.gameObject.transform.Translate (0, speed, 0);
		}
	}

	void OnTriggerStay2D (Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			collision.transform.position = this.gameObject.transform.position;
		}

	}
}
