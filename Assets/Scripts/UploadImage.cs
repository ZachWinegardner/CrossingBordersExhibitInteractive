using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGoogleDrive; 

public class UploadImage : MonoBehaviour {


	public Texture2D imageToUpload;
	public string filename; 
	public int extension; 

	public SnapShot snapShot; 

	private GoogleDriveFiles.CreateRequest request; 

	// Use this for initialization
	void Start () {
		filename = filename + "_" + extension.ToString (); 
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			//snapShot.CreateImageFromCam (); 
			UploadSnap(); 
		}
	}

	public void UploadSnap(){
		imageToUpload = snapShot.virtualPhoto; 
		var content = imageToUpload.EncodeToPNG (); 
		var file = new UnityGoogleDrive.Data.File () { Name = filename, Content = content, MimeType = "image/png" };
		request = GoogleDriveFiles.Create (file); 
		request.Fields = new List<string> { "id", "name", "size", "createdTime" };
		request.Send ();
	}
}
