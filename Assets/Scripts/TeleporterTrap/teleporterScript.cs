using UnityEngine;
using System.Collections;

public class teleporterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log(collider.tag);
            int randCoordX = Random.Range(0, 5);
            int randCoordY = Random.Range(0, 5);
            Debug.Log(randCoordX + "," + randCoordY);
            GameObject destination = GameObject.Find("RoomController (" + randCoordX.ToString() + " , " + randCoordY.ToString() + ")");
            collider.transform.position = destination.transform.position + Vector3.up;
        }
    }
}
