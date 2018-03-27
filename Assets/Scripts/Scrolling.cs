using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Scrolling : MonoBehaviour {

	public Transform stickers; 
	public float top; 
	public float bottom; 



	// Update is called once per frame
	void Update () {

		float scrollValue = GetComponent<Scrollbar> ().value; 
		float scrolledValue;
		scrolledValue = Mathf.Lerp (top, bottom, scrollValue); 

		Vector3 scrolledPos = new Vector3 (stickers.position.x, scrolledValue, stickers.position.z); 

		stickers.position = scrolledPos; 

	}
}
