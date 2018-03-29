using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptData : MonoBehaviour {
	
	public int[][] questions; 
	public int[] Q1_Responses; 
	public int[] Q2_Responses; 
	public int[] Q3_Responses; 
	public int[] Q4_Responses; 
	public int[] Q5_Responses; 

	public int currentValue; 
	public Slider sliderOne; 


	// Use this for initialization
	void Start () {
		Q1_Responses = new int[] { 0, 0, 0, 0, 0 }; 
		Q2_Responses = new int[] { 0, 0, 0, 0, 0 }; 
		Q3_Responses = new int[] { 0, 0, 0, 0, 0 }; 
		Q4_Responses = new int[] { 0, 0, 0, 0, 0 }; 
		Q5_Responses = new int[] { 0, 0, 0, 0, 0 }; 


	}

	public void SubmitResponse(){
		Q1_Responses [currentValue - 1] += 1; 
	}
	
	// Update is called once per frame
	void Update () {
		currentValue = (int)sliderOne.value; 
		questions = new int[][] { Q1_Responses, Q2_Responses, Q3_Responses, Q4_Responses, Q5_Responses };

	}
}
