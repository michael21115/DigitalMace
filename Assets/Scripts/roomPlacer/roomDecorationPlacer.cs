using UnityEngine;
using System.Collections;

public class roomDecorationPlacer : MonoBehaviour {

    
    Vector3 pos;
    int counter = 0;
    [SerializeField] Transform blueprint;
    [SerializeField] Transform chairPrefab;
    [SerializeField] Transform couchPrefab; 
    [SerializeField] Transform deskPrefab;

    // Use this for initialization
    void Start()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int z = 0; z < 3; z++)
            {
                pos = new Vector3(x * 2, 0, z * -2) + blueprint.transform.position;
                float randomNumber = Random.Range(0.0f, 1.0f);
                if (randomNumber > 0.85f && randomNumber < .9f)
                {
                    Instantiate(chairPrefab, pos, Quaternion.identity);
                    counter++;
                }
                if (randomNumber > 0.9f && randomNumber < 0.95f)
                {
                    Instantiate(couchPrefab, pos, Quaternion.identity);
                    counter++;
                }
                if (randomNumber > 0.95f)
                {
                    Instantiate(deskPrefab, transform.position, Quaternion.identity);
                    counter++;
                }
                else {
                    continue;
                }
                if (counter > 0)
                {
                    Destroy(gameObject);
                }

            }
        }
        Destroy ( gameObject );
    }
    // Update is called once per frame
    void Update () {
	    
	}
}
