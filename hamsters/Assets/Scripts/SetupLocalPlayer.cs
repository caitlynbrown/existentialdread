using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {

	[SyncVar]
	public string pname = "player";

	[SyncVar]
	public Color playerColor = Color.white;

	[SyncVar]
	public int playerChoice;

	public Sprite player0;
	public Sprite player1;
	public Sprite player2;
	public Sprite player3;

	private SpriteRenderer sr;
	private GameObject[] players;

	//void OnGUI(){
	
		//if (isLocalPlayer) {
		
			//pname = GUI.TextField (new Rect (25, Screen.height - 40, 100, 30), pname);
			//if (GUI.Button (new Rect (130, Screen.height - 40, 80, 30), "Change")) {
			
				//CmdChangeName (pname);
			
			//}
		
	//	}
	
	//}

	//[Command]
	//public void CmdChangeName(string newName){
	
		//pname = newName;
		//this.GetComponentInChildren<TextMesh> ().text = pname;
	
	//}
		

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		if (isLocalPlayer) {
			//NetworkServer.Spawn (player1);

			//SpriteRenderer[] rends = GetComponentsInChildren<SpriteRenderer> ();
			//foreach (Renderer r in rends) {


				//GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("player_1");
				//r.material.color = playerColor;

			//}

			if (PlayerPrefs.GetInt ("CharacterSelected") == 0) {
				sr.sprite = player0;
				playerChoice = 0;
			}

			if (PlayerPrefs.GetInt ("CharacterSelected") == 1) {
				sr.sprite = player1;
				playerChoice = 1;
			}

			if (PlayerPrefs.GetInt ("CharacterSelected") == 2) {
				sr.sprite = player2;
				playerChoice = 2;
			}
			if (PlayerPrefs.GetInt ("CharacterSelected") == 3) {
				sr.sprite = player3;
				playerChoice = 3;
			}
			
		
		}

		if (!isLocalPlayer) {
			
		}

		players = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject p in players) {
			if (p.gameObject.GetComponent<NetworkIdentity> ().isLocalPlayer == false) {
				var choice = p.gameObject.GetComponent<SetupLocalPlayer> ().playerChoice;

				if (choice == 0) {
					p.gameObject.GetComponent<SpriteRenderer> ().sprite = player0;
				} else if (choice == 1) {
					p.gameObject.GetComponent<SpriteRenderer> ().sprite = player1;
				} else if (choice == 2) {
					p.gameObject.GetComponent<SpriteRenderer> ().sprite = player2;
				} else if (choice == 3) {
					p.gameObject.GetComponent<SpriteRenderer> ().sprite = player3;
				} else {
					p.gameObject.GetComponent<SpriteRenderer> ().sprite = player0;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		//this.GetComponentInChildren<TextMesh> ().text = pname;

	}
}
