using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealData : MonoBehaviour {

	public int codeNumber = 0; 

	public void CheckCode(int addition){
		//add the amount from the buttons 1 or 10
		codeNumber += addition; 
		if (codeNumber == 33) {
			Reveal (); 
		}
		//unless it equals 33, countdown
		else
			StartCoroutine (Countdown ()); 
	}

	void Reveal(){
		transform.Translate (0, -1680, 0); 
	}

	public void Hide(){
		transform.Translate (0, 1680, 0); 
	}

	public void Clear(){
		codeNumber = 0; 
	}

	IEnumerator Countdown(){
		//if it isn't 33 after 5 secs, reset it
		yield return new WaitForSeconds (5); 
		if (codeNumber != 33) {
			Clear (); 
		}
	}
}
