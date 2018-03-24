using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TouchInput : MonoBehaviour {


	public Text text; 
	public float raylength;
	public LayerMask stickerMask; 
	public LayerMask inPlayMask; 
	bool parented = false; 
	GameObject recipientChild; 
	GameObject sticker; 
	public Transform touchParent; 
	public float scaleSensitivity = 1f; 
	public float minScale; 
	public float maxScale; 
	float startDist; 
	float currentDist; 
	float diffDist;

	void Update () {

		//Whenever there is a touch
		if (Input.touchCount == 1) {


			//store the world pos of the touch(es)
			Vector3 touchPosZero = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);; 
			//Vector3 touchPosOne = Camera.main.ScreenToWorldPoint (Input.GetTouch (1).position);; 
			touchParent.position = touchPosZero;
			


			//Check if that touch just began
			if (Input.GetTouch(0).phase == TouchPhase.Began){
				//Cast a ray
				RaycastHit hit; 
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

				//parent the empty object to the touch

				//If you hit a sticker UI object, parent a clone object to the touchpos
				if (Physics.Raycast (ray, out hit, raylength, stickerMask)) {
					sticker = hit.transform.gameObject; 
					recipientChild = Instantiate (sticker, sticker.transform.position, Quaternion.identity); 
					recipientChild.layer = 9; 
					//parented = true; 
					ParentObject(recipientChild, touchParent);   

				} else {
					
					//if its already in play just move it
					if(Physics.Raycast(ray, out hit, raylength, inPlayMask)){
						recipientChild = hit.transform.gameObject; 
						//parented = true; 
						ParentObject(recipientChild, touchParent);   
					}
				}
			}

			// Ended or error, unparent
			if (Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetTouch (0).phase == TouchPhase.Canceled) {
				//parented = false; 
				UnParentObject (recipientChild); 
				DeleteSticker DS = recipientChild.GetComponent<DeleteSticker> (); 
				if (DS._readyToDelete) {
					Destroy (recipientChild); 
				}
			}

			//Set the cloned object touched to the touchpos
//			if (parented) {
//				Vector3 newpos = new Vector3 (touchPosZero.x, touchPosZero.y, recipientChild.transform.position.z); 
//				recipientChild.transform.position = newpos;
//
//
//			}
		}

		//For Zooming and Rotation
		if (Input.touchCount == 2) {

			//store the touch positions
			Vector3 touchPosZero = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);; 
			Vector3 touchPosOne = Camera.main.ScreenToWorldPoint (Input.GetTouch (1).position);; 
			//touchParent.position = Vector3.Lerp (touchPosZero, touchPosOne, 0.5f);
			//Set the touchparent to the first touch

			// unparent the sticker if a finger was lifted
			if (Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetTouch (1).phase == TouchPhase.Ended) {
				if (recipientChild != null && recipientChild.transform.parent != null) {
					UnParentObject (recipientChild); 
				}
			}

			//if there is a sticker that was touched 
			if (recipientChild != null && recipientChild.transform.parent != null) {
				
				// Store both touches.
				Touch touchZero = Input.GetTouch(0);
				Touch touchOne = Input.GetTouch(1);

				// Find the position in the previous frame of each touch.
				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

				// Find the magnitude of the vector (the distance) between the touches in each frame.
				float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

				// Find the difference in the distances between each frame.
				float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
				//print (deltaMagnitudeDiff.ToString ()); 

				float xScale = recipientChild.transform.localScale.x; 
				float yScale = recipientChild.transform.localScale.y; 

				xScale -= deltaMagnitudeDiff * scaleSensitivity; 
				xScale = Mathf.Clamp (xScale, minScale, maxScale); 
				yScale = xScale;
				Vector3 pinchedScale = new Vector3 (xScale, yScale, 1); 
				recipientChild.transform.localScale = pinchedScale;  

			}

		}
	}

	void ParentObject(GameObject child, Transform parent){

		child.transform.parent = parent; 
	}

	void UnParentObject(GameObject child){

		if (recipientChild != null) {
			
			child.transform.parent = null; 
		}
	}


}
