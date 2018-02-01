using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TouchTest : MonoBehaviour {


	public Text text; 
	public float raylength;
	public LayerMask layermask; 
	bool parented = false; 
	GameObject recipientChild; 



	void Update () {

		if (Input.touchCount > 0) {
			
			Vector3 touchPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);; 

			if (Input.GetTouch(0).phase == TouchPhase.Began){
				RaycastHit hit; 
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				if (Physics.Raycast(ray, out hit, raylength, layermask)){
					recipientChild = hit.transform.gameObject; 
					parented = true; 

				}

				if (Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetTouch (0).phase == TouchPhase.Canceled) {
					parented = false; 
				}
			}

			if (parented) {
				Vector3 newpos = new Vector3 (touchPos.x, touchPos.y, recipientChild.transform.position.z); 
				recipientChild.transform.position = newpos;


			}

		}

	}


}
