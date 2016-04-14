using UnityEngine;
using System.Collections;

public class roomPrefabPlacer : MonoBehaviour {

    public Transform roomPrefab;
    public Transform roomPrefab2;
    public Transform roomPrefab3;
    public Transform roomPrefab4;
    public Transform roomPrefab5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for (int i=0; i < 5; i++) {
            float randNum = Random.Range(0f, 1f);
            if (randNum < .2f && randNum > 0f) 
            {
                Instantiate(roomPrefab, transform.position, Quaternion.identity);
            }
            else if (randNum < .4f && randNum > .2f)
            {
                Instantiate(roomPrefab2, transform.position, Quaternion.identity);
            }
            else if (randNum < .6f && randNum > .4f)
            {
                Instantiate(roomPrefab3, transform.position, Quaternion.identity);
            }
            else if (randNum < .8f && randNum > .6f)
            {
                Instantiate(roomPrefab4, transform.position, Quaternion.identity);

            }
            else if ( randNum > .8f && randNum < 1f)
            {
                Instantiate(roomPrefab5, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("failed, " + randNum);
            }


            transform.Translate(0f, 0f, -9.5f);
           }
        Destroy(gameObject);

    }
}
