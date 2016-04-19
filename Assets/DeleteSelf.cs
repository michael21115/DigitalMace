using UnityEngine;
using System.Collections;

public class DeleteSelf : MonoBehaviour {

    [SerializeField]
    Transform doorPrefab;

    [SerializeField]
    Transform wallPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray leftCheckRay = new Ray(transform.position, transform.right * -1);
        Ray rightCheckRay = new Ray(transform.position, transform.right);
        RaycastHit leftRayInfo = new RaycastHit();
        RaycastHit rightRayInfo = new RaycastHit();

        if(Physics.Raycast(leftCheckRay, out leftRayInfo, 2f))
        {
            if(leftRayInfo.collider.tag == "Wall")
            {
                Destroy(leftRayInfo.collider.gameObject);
                Transform temp = Instantiate(doorPrefab, transform.parent.position, transform.parent.rotation) as Transform;
                temp.position += transform.right * -0.5f;
                temp.transform.parent = transform.parent;
            }
            if(leftRayInfo.collider.tag == "Outer")
            {
                Transform temp = Instantiate(wallPrefab, transform.parent.position, transform.parent.rotation) as Transform;
                temp.transform.parent = transform.parent;
                Destroy(gameObject);
            }
        }

        if(Physics.Raycast(rightCheckRay, out rightRayInfo, 2f))
        {
            if (rightRayInfo.collider.tag == "Wall")
            {
                Destroy(rightRayInfo.collider.gameObject);
                Transform temp = Instantiate(doorPrefab, transform.parent.position, transform.parent.rotation) as Transform;
                temp.position += transform.right * 0.5f;
                temp.transform.parent = transform.parent;
            }
            if (rightRayInfo.collider.tag == "Outer")
            {
                Transform temp = Instantiate(wallPrefab, transform.parent.position, transform.parent.rotation) as Transform;
                temp.transform.parent = transform.parent;
                Destroy(gameObject);
            }
        }

	}

    void OnTriggerStay(Collider col)
    {
        Debug.Log(col.tag);
        if(col.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
