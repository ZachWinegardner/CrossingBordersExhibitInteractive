using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SetArtworkImage : MonoBehaviour {

	public SnapShot snap; 
	RawImage RI; 

	void Awake(){
		RI = GetComponent<RawImage> (); 
	}

	public void SetArtwork(){
		RI.texture = snap.virtualPhoto; 
	}
}
