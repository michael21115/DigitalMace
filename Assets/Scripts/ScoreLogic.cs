using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour {

	[SerializeField] Transform PlayerContainer, GoalItem, WinZone, BombSpawner;
	[SerializeField] static int ScoreP1, ScoreP2, ScoreP3, ScoreP4;
	[SerializeField] Text P1, P2, P3, P4;

	int maxWidth = 3;
	int maxHeight = 4;

	void placeComponent (Transform currentThing) {
		int tempHeight = Random.Range (0, maxHeight);
		int tempWidth = Random.Range (0, maxWidth);
		//Debug.Log (tempHeight + " , " + tempWidth);
		GameObject destination = GameObject.Find ("RoomController (" + tempHeight + " , " + tempWidth + ")");
		currentThing.transform.position = destination.transform.position;
		//Debug.Log ("Placing " + currentThing + " at " + destination);
		destination.GetComponent<RoomProperties>().furniture = true;
	}

	// Use this for initialization
	void Start () {
		
		PlayerContainer = GameObject.Find ("PlayerContainer").transform;
		placeComponent (PlayerContainer);

		GoalItem = GameObject.Find ("GoalItem").transform;
		placeComponent (GoalItem);

		WinZone = GameObject.Find ("WinZone").transform;
		placeComponent (WinZone);

		BombSpawner = GameObject.Find ("BombSpawner").transform;
		placeComponent (BombSpawner);

		P1.text = ScoreP1.ToString();
		P2.text = ScoreP2.ToString();
		P3.text = ScoreP3.ToString();
		P4.text = ScoreP4.ToString();
	}

}
