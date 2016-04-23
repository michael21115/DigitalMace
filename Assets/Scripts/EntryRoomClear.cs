using UnityEngine;
using System.Collections;

public class EntryRoomClear : MonoBehaviour {

	float timer;
	
	// Update is called once per frame
	void Update () {
	transform.position += new Vector3 (0f, 0f, -0.1f);

	timer += Time.deltaTime;
		if (timer > 1f) {
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter (Collider collider){
		if (collider.gameObject.tag == "Wall"){
			Debug.Log("I hit a wall, I want to get rid of it");
			Destroy(collider);
		}
	}
}
