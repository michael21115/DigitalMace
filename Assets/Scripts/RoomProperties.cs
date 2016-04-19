using UnityEngine;
using System.Collections;

public class RoomProperties : MonoBehaviour {

    /* Door Locations
        0 : North
        1 : East
        2 : South
        3 : West
    */
    public bool[] doorLocations;
    public string type;
    public int[] size;

    int numberOfDoors = 0;

    [SerializeField]
    Transform roomPrinter;


	// Use this for initialization
	void Start () {
        //Count the number of set doors in this room
        foreach(bool isDoor in doorLocations)
        {
            if (isDoor)
                numberOfDoors++;
        }
        //If there are no set doors, we need to randomly generate all of them.
        if(numberOfDoors == 0)
        {
            //Add one door then a second.
            while(numberOfDoors < 2)
            {
                int randomNumber = (int)(Random.value * 3.99f);
                if(!doorLocations[randomNumber])
                {
                    doorLocations[randomNumber] = true;
                    numberOfDoors++;
                }
            }
        }
        //If there is only one set door, we need to randomly generate one more.
        else if(numberOfDoors == 1)
        {
            //Add one door
            while (numberOfDoors < 2)
            {
                int randomNumber = (int)(Random.value * 3.99f);
                if (!doorLocations[randomNumber])
                {
                    doorLocations[randomNumber] = true;
                    numberOfDoors++;
                }
            }
        }
        //If there are 2 or more, we don't need to add any more doors.

        //Instantiate room printer.
        Transform printer = Instantiate(roomPrinter, transform.position, transform.rotation) as Transform;
        printer.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
