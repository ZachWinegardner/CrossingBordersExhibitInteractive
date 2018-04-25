using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RevealData : MonoBehaviour {

	public int codeNumber = 0; 

	public Text timeStamp; 
	public Text iPad; 
	public Text participants; 
	public GameObject nameButtons; 

	int made = 0; 
	int respond = 0;


	void Start (){
		CheckName (); 
	}

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
		timeStamp.text = System.DateTime.Now.ToString();
		made = SaveManager.Instance.state.numberOfMakers; 
		respond = SaveManager.Instance.state.numberOfRespondents; 
		participants.text = "images made: " + made.ToString () + " " + "respondents: " + respond.ToString ();  
		CheckName (); 

	}

	public void Hide(){
		transform.Translate (0, 1680, 0); 
	}

	public void Clear(){
		codeNumber = 0; 
	}

	public void CheckName(){
		if (SaveManager.Instance.state.hasName){
			nameButtons.SetActive (false); 
			iPad.text = SaveManager.Instance.state.iPadName; 
		}
	}
		

	IEnumerator Countdown(){
		//if it isn't 33 after 5 secs, reset it
		yield return new WaitForSeconds (5); 
		if (codeNumber != 33) {
			Clear (); 
		}
	}
}
