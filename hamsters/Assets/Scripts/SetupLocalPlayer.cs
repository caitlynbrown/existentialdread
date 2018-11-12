using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {

	[SyncVar]
	public string pname = "player";

	[SyncVar]
	public Color playerColor = Color.white;

	public Sprite player0;
	public Sprite player1;
	public Sprite player2;

	private SpriteRenderer sr;

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
			}

			if (PlayerPrefs.GetInt ("CharacterSelected") == 1) {
				sr.sprite = player1;
			}

			if (PlayerPrefs.GetInt ("CharacterSelected") == 2) {
				sr.sprite = player2;
			}
			
		
		}
	}
	
	// Update is called once per frame
	void Update () {

		//this.GetComponentInChildren<TextMesh> ().text = pname;

	}
}
