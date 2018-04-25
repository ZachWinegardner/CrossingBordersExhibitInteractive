using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSwapper : MonoBehaviour {

	public GameObject[] anims; 
	string [] names; 




	public void SetAnim (int index){

		foreach (GameObject anim in anims) {
			if (anim.activeSelf) {
				//anim.GetComponent<PlayAnim> ().Stop (); 
				anim.SetActive (false);
			}
		}

		anims [index - 1].SetActive (true);




//		if (index <= 2) {
//			anims [index - 1].GetComponent<PlayAnim> ().Play (names[index-1]);
//		}
	}
}
