using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSpecs : MonoBehaviour {

	public int height; 
	public int width; 
	public float paintingRatio; 
	public float camSize; 
	public Transform imagePos; 
	public Vector3 posOfCamera; 

	void Start(){
		posOfCamera = imagePos.position; 
	}



}
