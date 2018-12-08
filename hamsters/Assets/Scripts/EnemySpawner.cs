using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

	public GameObject enemyPrefab1;
	public GameObject enemyPrefab2;

	public int numberOfEnemies1;
	public int numberOfEnemies2;

	public override void OnStartServer(){
	
		for (int i = 0; i < numberOfEnemies1; i++) {
		
			var spawnPosition = new Vector2 (Random.Range (-8.0f, 10.0f), -4.5f);
			var spawnRotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
			var enemy1 = (GameObject)Instantiate (enemyPrefab1, spawnPosition, spawnRotation);
			NetworkServer.Spawn (enemy1);
		
		
		}

		for (int i = 0; i < numberOfEnemies2; i++) {

			var spawnPosition = new Vector2 (Random.Range (-8.0f, 10.0f), Random.Range (-4.0f, 4.0f));
			var spawnRotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
			var enemy2 = (GameObject)Instantiate (enemyPrefab2, spawnPosition, spawnRotation);
			NetworkServer.Spawn (enemy2);


		}
	
	}


}
