using UnityEngine;
using System.Collections;

public class OpenScript : MonoBehaviour {

    private bool open = false;
    private Vector3 openPosition, closedPosition;

    void Start ()
    {
        closedPosition = transform.position;
        openPosition = transform.position - transform.forward * 3;

    }

	// Update is called once per frame
	void Update () {
        if (open)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, 0.15f);
        }

        if (!open)
            transform.position = Vector3.Lerp(transform.position, closedPosition, 0.15f);
    }

//    void OnTriggerStay(Collider col)
//    {
//        if (col.tag == "Player")
//        {
//            if (Input.GetKeyDown(KeyCode.E))
//            {
//                Debug.Log("E PRESSED");
//                if (open)
//                    open = !open;
//                else if (!open)
//                    open = !open;
//            }
//        }
//    }

	void OnTriggerEnter (Collider collider){

        //Debug.Log(collider.tag);
        if (collider.tag == "Player")
        {

            if (open == true)
            {
                Debug.Log("Opening the dank door");
                //open = true;
            }
            else if (open == false)
            {
                //Debug.Log("Closing");
                open = !open;
            }
        }
	}
}
