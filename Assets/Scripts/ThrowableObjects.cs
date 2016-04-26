using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowableObjects : MonoBehaviour {

    [SerializeField] float waitTime = 1f;
    float currTime = 0f;
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.tag == "Projectile")
        {
            currTime += Time.deltaTime;
            if (currTime >= waitTime)
            {
                gameObject.tag = "Grabby Thing";
                currTime = 0f;
            }
        }
	}
}
