using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PreLoaderScript : MonoBehaviour
{
	CanvasGroup fadeGroup; 
	float loadTime; 
	public float minimumLogoTime = 3.0f; 
	public string playScene; 

	private void Start(){

		fadeGroup = FindObjectOfType<CanvasGroup> (); 

		fadeGroup.alpha = 1; 

		if (Time.time < minimumLogoTime)
			loadTime = minimumLogoTime;
		else
			loadTime = Time.time; 
	}

	private void Update(){
		if (Time.time < minimumLogoTime) {
			fadeGroup.alpha = 1-Time.time; 
		}

		if (Time.time > minimumLogoTime && loadTime != 0) {
			fadeGroup.alpha = Time.time - minimumLogoTime; 
			if (fadeGroup.alpha >= 1) {
				SceneManager.LoadScene (playScene); 
			}
		}
	}
}
