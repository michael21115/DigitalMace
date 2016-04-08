using UnityEngine;
using System.Collections;

public class fogOfWarDetect : MonoBehaviour {

	public GameObject roomLight;


	void OnTriggerEnter (Collider collider){
		Debug.Log("Something Enters; is it a player?");
		if (collider.tag == "Player"){
			Debug.Log("Yes, it's a player");
			roomLight.SetActive(true);
		}
	}

	void OnTriggerExit(Collider collider){
		if (collider.tag == "Player"){
			roomLight.SetActive(false);
		} 
	}
}
