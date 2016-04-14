using UnityEngine;
using System.Collections;

public class DoorGen : MonoBehaviour {

	public Transform doorPrefab;
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0.1f, 0f, 0f);
	}

	void OnTriggerEnter(Collider collider){
		float doorGenRand = Random.value;
		if (doorGenRand <= .09f){
			if (collider.tag == "Wall"){
				Debug.Log("I would destroy this wall if I could");
				Destroy(collider.gameObject);
			}
			else{
				return;
			}
		}

		if (collider.tag == "doorDetect"){
			Debug.Log ("We're in a Detector!");
			if (doorGenRand <= .9f && doorGenRand >= .3f){
				Instantiate(doorPrefab, transform.position, Quaternion.identity);
			}
			else {
				return;
			}
		}

		if (collider.tag == "generatorDestroyer"){
			Destroy(gameObject);
		}
	}
}
