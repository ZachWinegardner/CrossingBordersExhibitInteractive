using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractAnimator : MonoBehaviour {

	Vector3 startPos; 
	public float offset; 
	public float amp; 
	public bool zoom; 
	public float zValue; 


	// Use this for initialization
	void Start () {
		startPos = transform.position; 
		zValue = transform.position.z; 

	}

	IEnumerator Zoom (){
		zoom = true; 
		yield return new WaitForSeconds (2); 
		gameObject.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		if (zoom) {
			zValue += .2f; 
			transform.position = startPos + new Vector3 (0f, 0f, -zValue);  
		} else {
			zValue = startPos.z; 
			transform.position = startPos + new Vector3 (0f, (Mathf.Sin (Time.time + offset)) * amp, 0f);
		}

	}

}
