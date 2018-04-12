using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SnapShot : MonoBehaviour {

	public int imgHeight;
	public int imgWidth;
	public Camera shotCam; 
	public Texture2D virtualPhoto;

	public float aspectRatio; 

	void Start () {
		
		shotCam.aspect = 1;
		imgWidth = 1340; 
		imgHeight = imgWidth;

	}

//	public void SetAspectRatio(PaintingSpecs PS){
//		aspectRatio = PS.paintingRatio; 
//		transform.position = PS.posOfCamera; 
//		transform.Translate (0f, 0f, -3f); 
//		GetComponent<Camera> ().orthographicSize = PS.camSize; 
//	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			CreateImageFromCam (); 

		}
	}
		


	 public void CreateImageFromCam(){
			//shotCam.aspect = aspectRatio; 
			RenderTexture tempRT = new RenderTexture (imgWidth, imgHeight, 24); 
			shotCam.targetTexture = tempRT; 
			shotCam.Render (); 

			RenderTexture.active = tempRT; 
			virtualPhoto = new Texture2D (imgWidth, imgHeight, TextureFormat.RGB24, false); 
			virtualPhoto.ReadPixels (new Rect (0, 0, tempRT.width, tempRT.height), 0, 0); 
			virtualPhoto.Apply (); 
			print ("captured"); 
			RenderTexture.active = null; 
			shotCam.targetTexture = null; 
			//Destroy (tempRT); 
		}

}
