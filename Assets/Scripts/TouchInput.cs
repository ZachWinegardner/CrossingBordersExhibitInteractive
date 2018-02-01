﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

	public LayerMask touchInputMask; 

	private List<GameObject> touchlist = new List<GameObject> (); 
	private GameObject[] touchesOld; 
	private RaycastHit hit; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		#if UNITY_EDITOR
//
//		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {
//
//			touchesOld = new GameObject[touchlist.Count]; 
//			touchlist.CopyTo (touchesOld); 
//			touchlist.Clear (); 
//
//			Ray ray = GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition); 
//				RaycastHit hit; 
//
//				if (Physics.Raycast (ray, out hit, touchInputMask)) {
//
//					GameObject recipient = hit.transform.gameObject; 
//					touchlist.Add (recipient); 
//
//				if ( Input.GetMouseButtonDown(0)) {
//						recipient.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver); 
//					}
//
//					if (Input.GetMouseButtonUp(0)) {
//						recipient.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver); 
//					}
//
//				if (Input.GetMouseButton(0)) {
//						recipient.SendMessage ("OnTouchMoving", hit.point, SendMessageOptions.DontRequireReceiver); 
//					}
//							
//				}
//	
//		}
//		#endif

		if (Input.touchCount > 0) {

//			touchesOld = new GameObject[touchlist.Count]; 
//			touchlist.CopyTo (touchesOld); 
//			touchlist.Clear (); 

			foreach (Touch touch in Input.touches) {
				//print (touch.fingerId); 

				Ray ray = GetComponent<Camera> ().ScreenPointToRay (touch.position); 

				if (Physics.Raycast (ray, out hit, touchInputMask)) {

					GameObject recipient = hit.transform.gameObject; 
					print (recipient.name.ToString ()); 

					if (touch.phase == TouchPhase.Began) {
						recipient.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
						print ("parented object"); 
						//parent the recipient to the touch
					}

					if (touch.phase == TouchPhase.Ended) {
						recipient.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver); 
						//unparent the child
					}

					if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
						recipient.SendMessage ("OnTouchMoving", hit.point, SendMessageOptions.DontRequireReceiver); 
						//set the childs position to the parent touch
					}

					if (touch.phase == TouchPhase.Canceled) {
						recipient.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver); 
						//unparent
					}
				}
			}

//			foreach (GameObject g in touchesOld) {
//				if (!touchlist.Contains (g)) {
//					g.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver); 
//				}
			}
		}
	}
