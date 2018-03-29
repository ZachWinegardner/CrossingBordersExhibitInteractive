using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	public Transform dataPage; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void RevealData(){
		dataPage.Translate (0, -1680f, 0); 
	}

	public void HideData(){
		dataPage.Translate (0, 1680f, 0); 
	}
}
