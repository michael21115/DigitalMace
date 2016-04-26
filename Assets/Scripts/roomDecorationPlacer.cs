using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class roomDecorationPlacer : MonoBehaviour {
    
    Vector3 pos;
    int counter = 0;
    [SerializeField] Transform blueprint;
    [SerializeField] Transform chairPrefab;
    [SerializeField] Transform couchPrefab;     
    [SerializeField] Transform deskPrefab;
<<<<<<< HEAD:Assets/Scripts/roomDecorationPlacer.cs

	void SpawnObject(Object furniture) {
		Transform temp = (Transform)Instantiate(furniture, pos, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
		temp.transform.parent = transform.parent;
		counter++;
	}

=======
 
>>>>>>> bba82398bfd3fa6b2dfb2762d25bf4a7cd259c93:Assets/Scripts/roomPlacer/roomDecorationPlacer.cs
    // Use this for initialization
    void Start()
    {
        for (int x = 0; x < 3; x++) //this creates a 9x9 square area where objects can spawn
        {
            for (int z = 0; z < 3; z++)
            {
                pos = new Vector3(x * 2, 0, z * -2) + blueprint.transform.position;  
                float randomNumber = Random.Range(0.0f, 1.0f);

                //each piece of furniture has a 5% chance of being placed
                if (randomNumber > 0.85f && randomNumber < .9f)   
                {
<<<<<<< HEAD:Assets/Scripts/roomDecorationPlacer.cs
					SpawnObject(chairPrefab);
=======
           
                    Instantiate(chairPrefab, pos, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
                    counter++;
>>>>>>> bba82398bfd3fa6b2dfb2762d25bf4a7cd259c93:Assets/Scripts/roomPlacer/roomDecorationPlacer.cs
                }
                if (randomNumber > 0.9f && randomNumber < 0.95f)
                {
					SpawnObject(couchPrefab);
                }
                if (randomNumber > 0.95f)
                {
					SpawnObject(deskPrefab);
                }
                else {
                    continue;
                }
                if (counter > 0) //this ensures that only a max of around 4-5 objects spawn. 0 objects spawned is also possible
                {
                    Destroy(gameObject);
                    
                }

            }
        }
        Destroy ( gameObject ); //destroy the placer after job is done


    }
}
