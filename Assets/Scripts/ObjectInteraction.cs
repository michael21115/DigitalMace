using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

    [SerializeField] public Transform[] hands;
    public float throwForce;
    public bool throwItem, keyItem;
    public string throwItemName, keyItemName;
    public float objectMass;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hands[0].childCount == 0)
        {
            throwItem = false;
            throwItemName = null;
        }
        if (hands[1].childCount == 0)
        {
            keyItem = false;
            keyItemName = null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Rigidbody otherRB = other.gameObject.GetComponent<Rigidbody>();

        if (other.collider.tag == "Projectile")
        {
            GetComponent<Rigidbody>().AddForce((Vector3.up * 500f));

            if (keyItem)
            {
                Rigidbody keyItemRB = hands[1].FindChild(keyItemName).GetComponent<Rigidbody>();

                keyItemRB.constraints = RigidbodyConstraints.None;
                keyItemRB.constraints = RigidbodyConstraints.FreezeRotation;
                keyItemRB.detectCollisions = true;
                keyItemRB.useGravity = true;
                hands[1].DetachChildren();
            }
        }

        if (other.collider.tag == "Grabby Thing" && !throwItem)
        {
            objectMass = other.gameObject.GetComponent<ThrowableObjects>().mass;
            throwItemName = other.gameObject.name;

            otherRB.constraints = RigidbodyConstraints.FreezeAll;
            other.transform.position = hands[0].position;
            other.transform.SetParent(hands[0]);
            otherRB.mass = 0f;
            otherRB.useGravity = false;
            throwItem = true;
        }
        else if (other.collider.tag == "Key Item" && !keyItem)
        {
            keyItemName = other.gameObject.name;

            otherRB.constraints = RigidbodyConstraints.FreezeAll;
            other.transform.position = hands[1].position;
            other.transform.SetParent(hands[1]);
            otherRB.detectCollisions = false;
            otherRB.useGravity = false;
            keyItem = true;
        }
    }
}
