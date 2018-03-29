using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SetNumbersText : MonoBehaviour {

	Text numText; 
	public PromptData data; 
	public int questionNumber; 
	public int responseNumber; 

	// Use this for initialization
	void Start () {
		numText = GetComponent<Text> (); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateDataNumbers(){
		numText.text = (data.questions [questionNumber-1] [responseNumber-1].ToString()); 
	}
}
