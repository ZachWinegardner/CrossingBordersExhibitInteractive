using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractAnimator : MonoBehaviour {

	public Vector3 startPos; 
	public float offset; 
	public float amp; 
	public float zValue; 

	public float sensitivity = 0.1f; 

	public bool zoom; 
	public bool onCanvas; 
	CanvasGroup CG; 



	// Use this for initialization
	void Start () {
		startPos = transform.position; 
		zValue = transform.position.z;

		if (onCanvas){
			CG = GetComponent <CanvasGroup> ();
			//print ("got CG"); 
			CG.alpha = 0f; 
		}

	}

	public IEnumerator Zoom (){
		zoom = true; 
		yield return new WaitForSeconds (2); 
		zoom = false; 
		transform.position = startPos; 
		if (!onCanvas)
			gameObject.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (zoom) {
			// For the welcome screen , fade in
			if (onCanvas && CG.alpha <= 1) {
				CG.alpha += sensitivity*Time.deltaTime; 
			} 
			//For all other things, move
			else {
				if (!onCanvas) {
					transform.Translate (0f, 0f, -.1f);
					//zValue += .2f; 
				}
			}

		} else {
			//Oscillate for stickers
			if (!onCanvas) {
				zValue = startPos.z; 
				transform.position = startPos + new Vector3 (0f, (Mathf.Sin (Time.time + offset)) * amp, 0f);
			}
		}


	


	}

	public void Reset (){
		if (!onCanvas)
			transform.position = startPos; 
		else
			CG.alpha = 0f; 
		
		zoom = false; 

	}

}
