using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

	Vector3[] touchPos = new Vector3[5]; 
	RaycastHit hit;


	void Start () {
		
	}
	
	void Update () {

		if (Input.touchCount > 0) {


			foreach(Touch t in Input.touches)
			{
				if (Input.GetTouch (0).phase == TouchPhase.Began) {
					if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Camera.main.transform.forward, out hit, 100f)){
						print ("hit object"); 
					}
						
				}

//				for (var touch : iPhoneTouch in iPhoneInput.touches){
//					var ray = Camera.main.ScreenPointToRay(touch.position);
//					var hit : RaycastHit;
//					if (Physics.Raycast (ray, hit, 100)) {
//						if(touch.phase == iPhoneTouchPhase.Began || touch.phase == iPhoneTouchPhase.Moved) {
//							var cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
//							object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (touch.position.x, touch.position.y, cameraTransform.z - 0.5));
//						}
//					}
//				}
				
				//if(hit.collider.name == "Test Cube")
				//	hit.transform.position = touchPos[t.fingerId];
			}
		}
	}
}
