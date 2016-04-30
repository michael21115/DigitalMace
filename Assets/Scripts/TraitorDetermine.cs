using UnityEngine;
using System.Collections;

public class TraitorDetermine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float traitorSelect = Random.value;
		if (traitorSelect <= .25f){
			Debug.Log ("Player1 is the Traitor");
		}
		else if (traitorSelect > .25f && traitorSelect < .5f){
			Debug.Log ("Player2 is the Traitor");
		}
		else if (traitorSelect > .5f && traitorSelect < .75f){
			Debug.Log ("Player3 is the Traitor");
		}
		else if (traitorSelect >= .75f){
			Debug.Log ("Player4 is the Traitor");
		} else {
			Debug.Log("No Traitor Determined");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
