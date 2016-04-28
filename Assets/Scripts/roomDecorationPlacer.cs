using UnityEngine;
using System.Collections;

public class roomDecorationPlacer : MonoBehaviour {
    
    Vector3 pos;
    int counter = 0;

    [SerializeField] Transform[] furniture;
    [SerializeField] Transform blueprint;
    [SerializeField] float totalChance;

    private float uniformChance;
    private float currentChance;

    private Transform defaultParent;


	void SpawnObject(Object furniture) {
		Transform temp = (Transform)Instantiate(furniture, pos, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        temp.transform.parent = defaultParent;
		counter++;
	}

    // Use this for initialization
    void Start()
    {
        defaultParent = GameObject.Find("Furniture").transform;
        uniformChance = totalChance / furniture.Length;
        //Debug.Log(uniformChance);
        currentChance = uniformChance;
        for (int x = 0; x < 3; x++) //this creates a 9x9 square area where objects can spawn
        {
            for (int z = 0; z < 3; z++)
            {
                pos = new Vector3(x * 2, 0, z * -2) + blueprint.transform.position;  
                float randomNumber = Random.Range(0.0f, 1.0f);
                currentChance = uniformChance;
                //New Loop to generate furniture. Allows for more furniture to be added.
                foreach(Transform obj in furniture)
                {
                    Debug.Log(currentChance);
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
