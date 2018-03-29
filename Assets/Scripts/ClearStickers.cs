using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStickers : MonoBehaviour {

	public GameObject doneButton; 

	public void Clear(){
		GameObject[] inPlayStickers; 
		inPlayStickers = GameObject.FindGameObjectsWithTag ("inPlay"); 
		if (inPlayStickers.Length > 0) {
			foreach (GameObject sticker in inPlayStickers) {
				Destroy (sticker); 
				if (inPlayStickers.Length >=3)
					StartCoroutine (HideDone ()); 

			}
		}

	}

	IEnumerator HideDone () {

		yield return new WaitForSeconds (.01f); 
		doneButton.SetActive (false); 
	}

}
