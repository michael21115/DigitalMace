using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class roomPrefabPlacer : MonoBehaviour {

	// Creates a list of room prefabs; assigned in the inspector
	public List<Transform> roomList = new List<Transform>();
	
	// Update is called once per frame
	void Update () {
        for (int i=0; i < 1; i++) {
			float randNum = Random.value;
            if (randNum < .2f && randNum > 0f) 
            {
				Instantiate(roomList[0], transform.position, Quaternion.identity);
            }
            else if (randNum < .4f && randNum > .2f)
            {
                Instantiate(roomList[1], transform.position, Quaternion.identity);
            }
            else if (randNum < .6f && randNum > .4f)
            {
                Instantiate(roomList[2], transform.position, Quaternion.identity);
            }
            else if (randNum < .8f && randNum > .6f)
            {
                Instantiate(roomList[3], transform.position, Quaternion.identity);

            }
            else if ( randNum > .8f && randNum < 1f)
            {
                Instantiate(roomList[4], transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("failed, " + randNum);
            }
           }
		// Removes the generator when rooms are complete
        Destroy(gameObject);

    }
}
