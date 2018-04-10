using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SetNumbersText : MonoBehaviour {

	Text numText;  
	public int questionNumber; 
	public int responseNumber; 

	// Use this for initialization
	void Start () {
		numText = GetComponent<Text> (); 
		UpdateDataNumbers (); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateDataNumbers(){
		//Get the data into the double int array
		SaveManager.Instance.RetrieveDataForText (); 

		//grab the question number and response score number and set the text
		numText.text = (SaveManager.Instance.questions [questionNumber-1] [responseNumber-1].ToString()); 
	}
}
