using UnityEngine;
using System.Collections;


public class KeyItemPlacer : MonoBehaviour { //bugs- two items can spawn in the same area


    [SerializeField] Transform[] keyItemList;

	// Update is called once per frame
	void Start () {
        foreach (Transform keyItem in keyItemList)
        {
            int randCoordX = Random.Range(0, 6);
            int randCoordY = Random.Range(0, 5);
            if (randCoordX == 3 && randCoordY == 0) //check if 3,0 is selected, which is a roomcontroller location that does not exist
            {
                Debug.Log("3, 0 ignored");
                int newRandCoordX = Random.Range(0, 5);
                int newRandCoordY = Random.Range(0, 5);
                Debug.Log(newRandCoordX + " , " + newRandCoordY + "new");
                GameObject newDestination = GameObject.Find("RoomController (" + newRandCoordX.ToString() + " , " + newRandCoordY.ToString() + ")");
                Instantiate(keyItem, newDestination.transform.position + Vector3.forward, Quaternion.identity);
                continue; //can bug out if 3, 0 is selected here again
            }
            Debug.Log(randCoordX + " , " + randCoordY);          
            GameObject destination = GameObject.Find("RoomController (" + randCoordX.ToString() + " , " + randCoordY.ToString() + ")"); //finds the location of a random roomcontroller
            Instantiate(keyItem, destination.transform.position + Vector3.forward, Quaternion.identity);
        }

    }
    
}
