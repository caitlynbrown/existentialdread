using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class startGame : NetworkBehaviour {
	
	public Button startBtn;
	// Use this for initialization
	void Start () {
		startBtn.onClick.AddListener (gameStart);
	}
	
	void gameStart() {
		//SceneManager.LoadScene ("charcter_selection");
		NetworkManager.singleton.ServerChangeScene("alt_char_select");
	}
}
