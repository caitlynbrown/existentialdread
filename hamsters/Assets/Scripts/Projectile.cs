﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		Debug.Log ("here");

		var hit = collision.gameObject;
		var health = hit.GetComponent<Health> ();
		if (health != null) {
			health.TakeDamage (10);
		
		}

		Destroy (gameObject);
		Debug.Log ("dead");

	}

}
