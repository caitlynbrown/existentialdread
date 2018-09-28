using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treehouseSpawner : MonoBehaviour {

	public GameObject shadow;
	public GameObject apple;
	public GameObject owl;
	public int dropTime = 15;
	public int owlChance = 5;

	private float timer;
	private int chance;
	private bool shadowActive;
	private bool firstShadow;

	void Start () {
		timer = 0;
		shadow.SetActive (false);
		shadowActive = false;
		firstShadow = true;
	}

	void Update () {
		//Debug.Log (timer);
		timer += Time.deltaTime;
		if (timer >= (dropTime - 2) && timer <= (dropTime - 1)) {
			if (shadowActive) {

			} else {
				shadow.SetActive (true);
				shadowActive = true;
			}
		} 
		else if (timer >= dropTime) {
			firstShadow = false;
			chance = Random.Range (1, 100);
			Debug.Log (chance);
			if (chance <= owlChance) {
				Instantiate (owl);
				owl.transform.position = this.transform.position;
				timer = 0;
			} 
			else {
				Instantiate (apple);
				apple.transform.position = this.transform.position;
				//comment out below for a fun time.
				timer = 0;
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
