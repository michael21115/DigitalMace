using UnityEngine;
using System.Collections;

public class EntryRoomClear : MonoBehaviour {

	float timer;

	// Removes the walls that the collider touches in the main entryway
	void OnTriggerEnter (Collider collider){
		if (collider.gameObject.tag == "Wall"){
			Destroy(collider.gameObject);
		}
	}
		
	void Update () {
	// Removes the object to keep it from causing problems later
	timer += Time.deltaTime;
		if (timer > 0.1f) {
			Destroy(gameObject);
		}
	}
}
