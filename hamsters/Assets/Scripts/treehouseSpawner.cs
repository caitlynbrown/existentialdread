using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class treehouseSpawner : NetworkBehaviour {

	public GameObject shadow;
	public GameObject apple;
	public GameObject peach;
	public GameObject pear;
	public GameObject cherry;
	public GameObject orange;

	public GameObject owl;
	public int dropTime = 15;
	public int owlChance = 5;

	private float timer;
	private int chance;
	private bool shadowActive;
	private bool firstShadow;
	private GameObject[] players;
	private GameObject localplayer;

	void Start () {
		Debug.Log ("Start");
		timer = 0;
		//shadow.SetActive (false);
		shadowActive = false;
		firstShadow = true;

	}

	void Update () {
		players = GameObject.FindGameObjectsWithTag("Player");

		foreach (GameObject p in players) {
			if (p.gameObject.GetComponent<NetworkIdentity> ().isLocalPlayer) {
				localplayer = p.gameObject;
			}
		}

		if (localplayer.GetComponent<NetworkIdentity>().isServer) {
			int rand = Random.Range (0, 50);

			//Debug.Log (timer);
			timer += Time.deltaTime;
			if (timer >= (dropTime - 2) && timer <= (dropTime - 1)) {
				if (shadowActive) {

				} else {
					shadow.SetActive (true);
					shadowActive = true;
				}
			} else if (timer >= dropTime) {
				firstShadow = false;
				chance = Random.Range (1, 100);
				//Debug.Log (chance);
				if (chance <= owlChance) {
					var ow = (GameObject)Instantiate (owl);
					NetworkServer.Spawn (ow);
					ow.transform.position = this.transform.position;

					timer = 0;
				} else {

					if (rand <= 10) {
						var ap = (GameObject)Instantiate (apple);
						NetworkServer.Spawn (ap);
						ap.transform.position = this.transform.position;

						//comment out below for a fun time.
						timer = 0;
					} else if (rand >= 11 && rand <= 20) {
						var pe = (GameObject)Instantiate (peach);
						NetworkServer.Spawn (pe);
						pe.transform.position = this.transform.position;

						//comment out below for a fun time.
						timer = 0;
					} else if (rand >= 21 && rand <= 30) {
						var pea = (GameObject)Instantiate (pear);
						NetworkServer.Spawn (pea);
						pea.transform.position = this.transform.position;

						//comment out below for a fun time.
						timer = 0;
					} else if (rand >= 31 && rand <= 40) {
						var ch = (GameObject)Instantiate (cherry);
						NetworkServer.Spawn (ch);
						ch.transform.position = this.transform.position;

						//comment out below for a fun time.
						timer = 0;
					} else if (rand >= 41 && rand <= 50) {
						var or = (GameObject)Instantiate (orange);
						NetworkServer.Spawn (or);
						or.transform.position = this.transform.position;

						//comment out below for a fun time.
						timer = 0;
					}
				}

			}
			//I want the shadow to linger a little after the timer resets, but can't have it do so on the first spawn.
			else if (timer >= 1.2 && timer <= 1.3) {
				if (firstShadow) {

				} else {
					shadow.SetActive (false);
					shadowActive = false;
				}
			}
		}
	}
}
