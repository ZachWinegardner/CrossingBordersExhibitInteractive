using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerScript : MonoBehaviour {

	public GameObject [] screens; 

	public GameObject[] artistInfo; 

	public ClearStickers clearStickers; 

	public GameObject donePanel; 
	public GameObject permissionsPanel; 
	public GameObject arrow; 
	public PromptData sliderData; 
	public GameObject[] promptQs; 

	public GameObject attractCam; 
	public AttractStickersActivate attrOn; 

	public AttractAnimator AttrAnim; 

	public void ToggleInfo (GameObject info){

		if (info.activeSelf) {
			info.SetActive (false); 
		} else
			info.SetActive (true); 
	}


	public void Reset (){
		
		//turn off animations (HOW TO)
		for(int i = 0; i < screens[2].transform.childCount; i++) {
			screens [2].transform.GetChild (i).gameObject.SetActive (false);  
		}

		//turn off artist info (SELECTION)
		foreach (GameObject info in artistInfo){
			info.SetActive (false); 
		}

		// PLAY SCREEN
		clearStickers.Clear (); 
		donePanel.SetActive (false); 
		permissionsPanel.SetActive (false); 
		arrow.SetActive (true); 

		//PROMPTS
		sliderData.SetToNeutral (); 
		foreach (GameObject prompt in promptQs) {
			prompt.SetActive (false); 
		}
		promptQs [0].SetActive (true); 



		//ATTRACT
		attrOn.TurnOnStickers(); 
		attractCam.SetActive (true); 


		//RESET SCREENS
		foreach (GameObject screen in screens) {
			screen.SetActive (false); 
		}
		screens [2].SetActive (true); 
		screens[1].SetActive(true); 
		screens [0].SetActive (true); 
		//WELCOME
		AttrAnim.Reset(); 
		screens[1].GetComponent<CanvasGroup>().alpha = 0f; 

	}

}
