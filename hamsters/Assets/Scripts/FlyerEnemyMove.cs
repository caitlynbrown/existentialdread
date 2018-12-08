using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerEnemyMove : MonoBehaviour {

	public GameObject target;

	public float moveSpeed = .05f;

	public float playerRange;

	// Use this for initialization
	void Start () {
		if (target == null) {
		
			target = GameObject.FindGameObjectWithTag ("Player");
		
		}
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, moveSpeed);
	
	}
}
