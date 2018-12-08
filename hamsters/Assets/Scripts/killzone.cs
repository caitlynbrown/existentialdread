﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killzone : MonoBehaviour {

	public int respawnTime = 3;

	private float timer;
	private bool playerDead;
	private GameObject deadPlayer;
	private GameObject spawn1;	
	private GameObject spawn2;


	// Use this for initialization
	void Start () {
		spawn1 = GameObject.Find ("SpawnPosition1");
		spawn2 = GameObject.Find ("SpawnPosition2");

	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			//Debug.Log ("Player Died :(");
			deadPlayer = collision.gameObject;
			respawn (deadPlayer);
		} else if (collision.gameObject.tag == "noKill") {
			Debug.Log ("Shouldn't Happen Right Now...");
		}
		else {
			//Debug.Log ("Item destroyed");
			Destroy (collision.gameObject);
		}
	}

	private void respawn(GameObject deadPlayer) {
		//More stuff should be done here, like taking away a life, etc.
		int rand = Random.Range(0,10);

		deadPlayer.gameObject.GetComponent<Health> ().currentHealth = 100;

		if (rand <= 5) {
			deadPlayer.transform.position = spawn1.transform.position;

		}
		else if (rand >= 4) {
			deadPlayer.transform.position = spawn2.transform.position;

		}
	}
}