using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSticker : MonoBehaviour {

	bool isOverTrash;  
	float timer; 
	float timerTime; 
	float stateTimer = 0f; 

	Vector3 originScale; 
	Vector3 deletedScale; 

	public bool _readyToDelete; 

	SpriteRenderer spriteRenderer; 
	public Color32 deletedColor; 
	public Color32 originColor; 

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		originColor = spriteRenderer.color; 
		_readyToDelete = false; 
		isOverTrash = false; 
		timerTime = 0.33f;  
		timer = timerTime; 

		originScale = transform.localScale; 
		deletedScale = new Vector3 (0.6f, 0.6f, 0.6f); 
	}

	void Update(){

//		if (isOverTrash) {
//			if (timer >=0)
//			timer -= Time.deltaTime; 
//		}
//
//		if (timer <= 0) {
//			_readyToDelete = true; 
//			stateTimer += Time.deltaTime*5; 
//			spriteRenderer.color = Color32.Lerp (originColor, deletedColor, stateTimer); 
//			Vector3 newScale; 
//			newScale = Vector3.Lerp (originScale, deletedScale, stateTimer); 
//			transform.localScale = newScale; 
//			//change color and size
//		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "PanelDelete") {
			_readyToDelete = true;  

		}
	}

	void OnTriggerExit (Collider other){
		isOverTrash = false; 
		_readyToDelete = false; 
		spriteRenderer.color = originColor; 
		transform.localScale = originScale; 
		timer = timerTime; 
		stateTimer = 0f; 

	}

	public void ClearStickers(){
		GameObject[] inPlayStickers; 
		inPlayStickers = GameObject.FindGameObjectsWithTag ("inPlay"); 
		foreach (GameObject sticker in inPlayStickers) {
			Destroy (sticker); 
		}
	}

}
