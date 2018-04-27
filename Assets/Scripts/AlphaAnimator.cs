using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AlphaAnimator : MonoBehaviour {

	CanvasGroup CG; 
	public float sensitivity; 

	// Use this for initialization
	void Start () {
		CG = GetComponent<CanvasGroup> (); 
	}
	
	// Update is called once per frame
	void Update () {
		CG.alpha = ((Mathf.Sin (Time.time*sensitivity))+1)/2;

	}
}
