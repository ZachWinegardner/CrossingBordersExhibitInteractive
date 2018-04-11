using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleInfo (GameObject info){

		if (info.activeSelf) {
			info.SetActive (false); 
		} else
			info.SetActive (true); 
	}

}
