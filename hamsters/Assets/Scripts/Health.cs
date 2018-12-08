using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	public const int maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = maxHealth;

	public RectTransform healthBar;

	public bool destroyOnDeath;

	private NetworkStartPosition[] spawnPoints;

	void Start(){
	
		if (isLocalPlayer) {
		
			spawnPoints = FindObjectsOfType<NetworkStartPosition> ();
		
		}
	
	}

	public void TakeDamage(int amount){

		if (!isServer) {
		
			return;
		
		}
	
		currentHealth -= amount;
		if (currentHealth <= 0) {
		
			if (destroyOnDeath) {
			
				Destroy (gameObject);
			
			} else {
			
				currentHealth = maxHealth;

				//called on the server, but invoked on the clients
				RpcRespawn();
			}

		
		}
				
	}

	public void RecoverHealth(int amount){
	
		currentHealth += amount;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	
	}

	void OnChangeHealth(int currentHealth){

		healthBar.sizeDelta = new Vector2 (currentHealth, healthBar.sizeDelta.y);
		//currentHealth = health;
	
	}

	[ClientRpc]
	void RpcRespawn(){
	
		if (isLocalPlayer) {
		
			//move back to zero location
			Vector2 spawnPoint = Vector2.zero;

			//if there is a spawn point array  and the array is not empty, pick one at random
			if (spawnPoints != null && spawnPoints.Length > 0) {
			
				spawnPoint = spawnPoints [Random.Range (0, spawnPoints.Length)].transform.position;
			
			}

			//set the player's position to the chosen spawn points
			transform.position = spawnPoint;
		
		}
	
	}

}
