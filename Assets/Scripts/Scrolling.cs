using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Scrolling : MonoBehaviour {

	public Transform stickers; 
	public float top; 
	public float bottom; 
	Vector3 scrolledPos; 


	// Update is called once per frame
	void Update () {

		float scrollValue = GetComponent<Scrollbar> ().value; 
		float scrolledValue;
		scrolledValue = Mathf.Lerp (top, bottom, scrollValue); 

		scrolledPos = new Vector3 (stickers.position.x, scrolledValue, stickers.position.z); 

		stickers.position = scrolledPos; 

	}

	public void Reset(){
		GetComponent<Scrollbar> ().value = 0; 
		stickers.position = scrolledPos; 
	}
}
