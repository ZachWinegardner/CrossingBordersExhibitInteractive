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

	public Transform frame; 

	public Vector3 frameScale; 

	void Start(){
		posOfCamera = imagePos.position; 
	}

	public void SetFrame(){
		frame.localScale = frameScale; 
	}



}
