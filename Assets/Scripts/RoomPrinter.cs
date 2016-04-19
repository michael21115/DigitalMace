﻿using UnityEngine;
using System.Collections;

public class RoomPrinter : MonoBehaviour {

    [SerializeField]
    Transform wallPrefab;

    [SerializeField]
    Transform doorPrefab;

	// Use this for initialization
	void Start () {
        transform.localPosition += new Vector3(-5, 0, -5);
        spawnFullRoom(1, 1);
        Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    //Spawns a wall that length.
    public void spawnWall(int length)
    {
        //float doorChance = 0.2f;
        while (length > 0)
        {
            float randomNumber = Random.value;
            Transform temp = Instantiate(wallPrefab, transform.position, transform.rotation) as Transform;
            temp.transform.parent = transform.parent;
            transform.position += transform.forward * 2;
            length--;
        }
    }

    public void spawnDoor()
    {
        Transform temp = Instantiate(doorPrefab, transform.position, transform.rotation) as Transform;
        temp.transform.parent = transform.parent;
        transform.position += transform.forward * 2;
    }

    //Note: using grid units. So 1 width is 5 walls wide, or 10 units
    public void spawnFullRoom(int width, int length)
    {
        //Multiply by wall sizes.
        width *= 5;
        length *= 5;

        //Check if the wall needs a door, then spawn if we need to.
      

        //West Side
        if (transform.parent.GetComponent<RoomProperties>().doorLocations[3])
        {
            spawnWall((int)(length / 2));
            spawnDoor();
            spawnWall((int)(length / 2));
        }
        else {
            spawnWall(length);
        }
        transform.eulerAngles += new Vector3(0, 90, 0);

        //North Side
        if (transform.parent.GetComponent<RoomProperties>().doorLocations[0])
        {
            spawnWall((int)(length / 2));
            spawnDoor();
            spawnWall((int)(length / 2));
        }
        else {
            spawnWall(length);
        }
        transform.eulerAngles += new Vector3(0, 90, 0);

        //East Side
        if (transform.parent.GetComponent<RoomProperties>().doorLocations[1])
        {
            spawnWall(length / 2);
            spawnDoor();
            spawnWall(length / 2);
        }
        else {
            spawnWall(length);
        }
        transform.eulerAngles += new Vector3(0, 90, 0);

        //South Side
        if (transform.parent.GetComponent<RoomProperties>().doorLocations[2])
        {
            spawnWall((int)(length / 2));
            spawnDoor();
            spawnWall((int)(length / 2));
        }
        else {
            spawnWall(length);
        }
        transform.eulerAngles += new Vector3(0, 90, 0);
    }
}
