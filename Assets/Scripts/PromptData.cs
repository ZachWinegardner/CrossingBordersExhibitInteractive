using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptData : MonoBehaviour {
	
//	public int[][] questions; 
//	public int[] Q1_Responses; 
//	public int[] Q2_Responses; 
//	public int[] Q3_Responses; 
//	public int[] Q4_Responses; 
//	public int[] Q5_Responses; 


	public int currentValue; 
	public Slider slider; 

	void Awake(){
		slider = GetComponent<Slider> (); 
		SetToNeutral (); 	}

	public void SetValue () {
		currentValue = (int)slider.value; 

	}

	public void RecordResponseOne()
	{
		SaveManager.Instance.SubmitQuestionOne (currentValue);
		SetToNeutral (); 
	}

	public void RecordResponseTwo()
	{
		SaveManager.Instance.SubmitQuestionTwo (currentValue); 
		SetToNeutral (); 

	}

	public void RecordResponseThree()
	{
		SaveManager.Instance.SubmitQuestionThree (currentValue); 
		SetToNeutral (); 

	}

	public void RecordResponseFour()
	{
		SaveManager.Instance.SubmitQuestionFour (currentValue); 
		SetToNeutral (); 

	}

	public void SetToNeutral(){
		slider.value = 3; 
	}
}
