using UnityEngine;
using System.Collections;

public class roomDecorationPlacer : MonoBehaviour {
    
    Vector3 pos;
    int counter = 0;

    [SerializeField] Transform[] furniture;
    [SerializeField] Transform blueprint;

    private float uniformChance;
    private float currentChance;


	void SpawnObject(Object furniture) {
		Transform temp = (Transform)Instantiate(furniture, pos, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
		temp.transform.parent = transform.parent;
		counter++;
	}

    // Use this for initialization
    void Start()
    {
        uniformChance = 0.15f / furniture.Length;
        currentChance = uniformChance;
        for (int x = 0; x < 3; x++) //this creates a 9x9 square area where objects can spawn
        {
            for (int z = 0; z < 3; z++)
            {
                pos = new Vector3(x * 2, 0, z * -2) + blueprint.transform.position;  
                float randomNumber = Random.Range(0.0f, 1.0f);
                
                //New Loop to generate furniture. Allows for more furniture to be added.
                foreach(Transform obj in furniture)
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
                    break;
                }

            }
        }
        Destroy ( gameObject ); //destroy the placer after job is done
    }
}
