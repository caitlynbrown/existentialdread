using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class CharacterCreation : MonoBehaviour {

	public List<GameObject> models;

	//default index of the model 
	private int selectionIndex = 0;
	//private int index;

	private float connectionID = 0;
	// Use this for initialization
	void Start () {



		//used to store what the person last chose but I didn't really need/want to use it
		//still cool to have tho
		selectionIndex = PlayerPrefs.GetInt("CharacterSelected");

		models = new List<GameObject>();
		foreach (Transform t in transform)
		{
			models.Add(t.gameObject);
			t.gameObject.SetActive(false);
		}

		models[selectionIndex].SetActive(true);
	}

	private void Update()
	{

	}

	public void Select (int index)
	{


		if (index == selectionIndex)
			return;

		if (index < 0 || index >= models.Count)
			return;

		models[selectionIndex].SetActive(false);
		selectionIndex = index;
		models[selectionIndex].SetActive(true);

	



	}




	


	public void ConfirmButton()
	{		
		//NetworkServer.AddPlayerForConnection (0.1, models [selectionIndex], 0);

		PlayerPrefs.SetInt("CharacterSelected", selectionIndex);



		SceneManager.LoadScene("newhammy");

	}

	/* public void OnMouseEnter(int index)
    {
        if (index == selectionIndex)
            return;

        if (index < 0 || index >= models.Count)
            return;

        models[selectionIndex].SetActive(false);
        selectionIndex = index;
        models[selectionIndex].SetActive(true);

    }*/


}
