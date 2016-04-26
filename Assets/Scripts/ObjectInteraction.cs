using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

    [SerializeField] public Transform[] hands;
    public float throwForce;
    public bool throwItem, keyItem;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<ObjectInteraction>().hands[0].childCount == 0)
        {
            throwItem = false;
        }
        if (GetComponent<ObjectInteraction>().hands[1].childCount == 0)
        {
            keyItem = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Rigidbody otherRB = other.gameObject.GetComponent<Rigidbody>();

        if (other.collider.tag == "Projectile")
        {
            otherRB.mass = 1;
            GetComponent<Rigidbody>().AddForce((Vector3.up * 500f));
        }

        if (other.collider.tag == "Grabby Thing" && !throwItem)
        {
                otherRB.constraints = RigidbodyConstraints.FreezeAll;
                otherRB.mass = 0;
                other.transform.position = hands[0].position;
                other.transform.SetParent(hands[0]);
                otherRB.useGravity = false;
                throwItem = true;
        }
        else if (other.collider.tag == "Key Item" && !keyItem)
        {
            otherRB.constraints = RigidbodyConstraints.FreezeAll;
            other.transform.position = hands[1].position;
            other.transform.SetParent(hands[1]);
            otherRB.useGravity = false;
            keyItem = true;
        }
    }
}
