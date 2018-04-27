using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	public static SaveManager Instance { set; get; }
	public SaveState state; 
	public int[][] questions; 

	private void Awake(){
		DontDestroyOnLoad (gameObject); 
		Instance = this; 
		Load ();
		RetrieveDataForText (); 
		Debug.Log (HelperSave.Serialize<SaveState> (state)); 
	}


	//Save state of this savestate to the player prefs
	public void Save()
	{
		//turns our state into a string to serialize
		PlayerPrefs.SetString("save", HelperSave.Serialize<SaveState>(state));
	}

	public void Load(){
		//is there already a save?
		if (PlayerPrefs.HasKey ("save")) {
			//takes our current save state and uses helpersave to deserialize it
			state = HelperSave.Deserialize<SaveState> (PlayerPrefs.GetString ("save")); 
		}
		else 
		{
			state = new SaveState (); 
			Save (); 
			print ("No Save, making new one"); 
		}
	}

	public void SubmitQuestionOne(int index)
	{
		state.Q1_Responses [index-1] += 1;
	}

	public void SubmitQuestionTwo(int index)
	{
		state.Q2_Responses [index-1] += 1;
	}

	public void SubmitQuestionThree(int index)
	{
		state.Q3_Responses [index-1] += 1;
	}

	public void SubmitQuestionFour(int index)
	{
		state.Q4_Responses [index-1] += 1;
		Save (); 
	}

	public void RetrieveDataForText(){
		questions = new int[][] { state.Q1_Responses, state.Q2_Responses, state.Q3_Responses, state.Q4_Responses }; 
	}

	public void addMaker(){
		state.numberOfMakers += 1; 
	}

	public void addRespondent(){
		state.numberOfRespondents += 1; 
	}

	public void SetIpad(string name){
		state.iPadName = name; 
		state.hasName = true; 
	}

	void Update (){
		if (Input.GetKeyDown (KeyCode.R)) {
			PlayerPrefs.DeleteKey ("save"); 
			print ("wiped save"); 
		}
	}
}
