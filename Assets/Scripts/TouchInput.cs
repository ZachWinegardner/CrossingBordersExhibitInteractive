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
	public int orderLayer = 0; 
	SpriteRenderer SR; 
	DeleteSticker DS; 

	public GameObject doneButton; 


	void Start (){

	}

	void StoreScale(){
		minScale = (recipientChild.GetComponent<StickerStats>().stickerScale.x)/3; 
		maxScale = (recipientChild.GetComponent<StickerStats>().stickerScale.x)*2.5f; 

 

	}

	void Update () {

		//Whenever there is a touch
		if (Input.touchCount == 1) {


			//store the world pos of the touch(es)
			Vector3 touchPosZero = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);; 
			//Vector3 touchPosOne = Camera.main.ScreenToWorldPoint (Input.GetTouch (1).position);; 
			touchParent.position = touchPosZero;

			if (touchParent.childCount == 2) {
				Destroy (touchParent.GetChild (1).gameObject); 
			}


			//Check if that touch just began
			if (Input.GetTouch(0).phase == TouchPhase.Began){
				//Cast a ray
				RaycastHit hit; 
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

				//parent the empty object to the touch

				//If you hit a sticker UI object, parent a clone object to the touchpos
				if (Physics.Raycast (ray, out hit, raylength, stickerMask) && GameObject.FindGameObjectsWithTag("inPlay").Length < 300 ) {
					sticker = hit.transform.gameObject; 
					//setting the sticker grabbed
					recipientChild = Instantiate (sticker, sticker.transform.position, Quaternion.identity); 
					SR = recipientChild.GetComponent<SpriteRenderer> (); 
					SR.sortingOrder = 1002; 
					recipientChild.layer = 9; 
					recipientChild.tag = "inPlay"; 
					//parented = true; 
					ParentObject(recipientChild, touchParent);
					StoreScale (); 



				} else {
					
					//if its already in play just move it
					if(Physics.Raycast(ray, out hit, raylength, inPlayMask)){
						recipientChild = hit.transform.gameObject; 
						StoreScale (); 
						//parented = true; 
						ParentObject(recipientChild, touchParent);   
					}
				}
			}

			// Ended or error, unparent
			if ((Input.GetTouch (0).phase == TouchPhase.Ended) || (Input.GetTouch (0).phase == TouchPhase.Canceled) )  {
				//parented = false; 
				//print (touchParent.GetChild(0).name.ToString()); 
				if (recipientChild != null) {
					orderLayer += 1; 
					CheckIfDone (); 
					//if rec child isn't what's parented to the toucher
					if (recipientChild != touchParent.GetChild (0).gameObject) {
						DS = touchParent.GetChild (0).GetComponent < DeleteSticker> (); 
						SR = touchParent.GetChild (0).GetComponent<SpriteRenderer> ();
						SR.sortingOrder = orderLayer; 

						if (DS._readyToDelete) {
							Destroy (touchParent.GetChild (0).gameObject); 
							recipientChild = null; 
						} else {
							UnParentObject (touchParent.GetChild (0).gameObject); 
							recipientChild = null; 
						}
					} 
					//If it is what the child is
					else {
						DS = recipientChild.GetComponent<DeleteSticker> ();
						SR = recipientChild.GetComponent<SpriteRenderer> (); 
						SR.sortingOrder = orderLayer;
						if (DS._readyToDelete) {
							Destroy (recipientChild); 
							recipientChild = null; 
						} else {
							UnParentObject (recipientChild);
							recipientChild = null; 
						}
					}
				}


				if (touchParent.childCount == 1) {
					//print ("leftover 1"); 
					Destroy (touchParent.GetChild (0).gameObject); 
				}

				if (touchParent.childCount == 2) {
					//print ("leftover 2"); 
					Destroy (touchParent.GetChild (0).gameObject);
					Destroy (touchParent.GetChild (1).gameObject); 

				}



			}

			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				//print ("checking leftover"); 

			}
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

				if (recipientChild.GetComponent<DeleteSticker> ()._canRotate==true) {
					float pinchAmount = 0;
					Quaternion desiredRotation = recipientChild.transform.rotation;

					RotateCalc.Calculate();

					if (Mathf.Abs(RotateCalc.turnAngleDelta) > 0) { // rotate
						Vector3 rotationDeg = Vector3.zero;
						rotationDeg.z = RotateCalc.turnAngleDelta;
						desiredRotation *= Quaternion.Euler(rotationDeg);
					}


					// not so sure those will work:
					recipientChild.transform.rotation = desiredRotation;
					//transform.position += Vector3.forward * pinchAmount; 
				}

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

	void CheckIfDone(){
		if (GameObject.FindGameObjectsWithTag ("inPlay").Length >= 3) {
			doneButton.SetActive (true); 
		}
	}


}
