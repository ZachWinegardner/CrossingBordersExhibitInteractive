using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayAnim : MonoBehaviour {

	public MovieTexture movie; 


	// Use this for initialization
	void Awake () {
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		Play (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Play (); 
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			Stop (); 
		}
	}

	public void Play(){
		movie.Play (); 
		movie.loop = true; 
	}

	public void Stop(){
		movie.Stop ();
	}
}
