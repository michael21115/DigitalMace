using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class roomDecorationPlacer : MonoBehaviour {
    
    Vector3 pos;
    int counter = 0;

    [SerializeField] Transform[] furniture;
    [SerializeField] Transform blueprint;
<<<<<<< HEAD
    [SerializeField] Transform chairPrefab;
    [SerializeField] Transform couchPrefab;     
    [SerializeField] Transform deskPrefab;
	[SerializeField] Transform spikePrefab;
=======

    private float uniformChance;
    private float currentChance;

    private Transform defaultParent;
>>>>>>> 7c9533db2554467e1ff4390958f99159cc8ebe16


	void SpawnObject(Object furniture) {
		Transform temp = (Transform)Instantiate(furniture, pos, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        temp.transform.parent = defaultParent;
		counter++;
	}
		
    // Use this for initialization
    void Start()
    {
        defaultParent = GameObject.Find("Furniture").transform;
        uniformChance = 0.15f / furniture.Length;
        currentChance = uniformChance;
        for (int x = 0; x < 3; x++) //this creates a 9x9 square area where objects can spawn
        {
            for (int z = 0; z < 3; z++)
            {
                pos = new Vector3(x * 2, 0, z * -2) + blueprint.transform.position;  
                float randomNumber = Random.Range(0.0f, 1.0f);
<<<<<<< HEAD

                //each piece of furniture has a 5% chance of being placed
				if (randomNumber > 0.7f && randomNumber < .85f){
					SpawnObject(spikePrefab);
				}
                if (randomNumber > 0.85f && randomNumber < .9f)   
=======
                
                //New Loop to generate furniture. Allows for more furniture to be added.
                foreach(Transform obj in furniture)
>>>>>>> 7c9533db2554467e1ff4390958f99159cc8ebe16
                {
                    if (randomNumber < currentChance)
                    {
                        currentChance = uniformChance;
                        pos.y = obj.transform.position.y;
                        SpawnObject(obj);
                        break;
                    }
                    else
                    {
                        currentChance += uniformChance;
                    }
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
