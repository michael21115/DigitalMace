using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

    [SerializeField] Transform[] hands;

    bool throwItem, keyItem;

	// Use this for initialization
	void Start ()
    {
        //hands = GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Grabby Thing" && !throwItem)
        {
            other.transform.position = transform.GetChild(1).position;
            other.transform.parent = transform.GetChild(1);
            throwItem = true;
            //return other.gameObject;
        }
        else if (other.collider.tag == "Key Item" && !keyItem)
        {
            other.transform.position = transform.GetChild(0).position;
            other.transform.parent = transform.GetChild(0);
            keyItem = true;
            //return other.gameObject;
        }
        //else return null;
    }
}
