using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    private float timer;
    Transform cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        cam.GetComponent<CameraShake>().cameraShake(0.4f);
        timer = 0;
    }

    void Update()
    {

        timer += Time.deltaTime;
        if(timer > 1f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.name);
        if (collider.gameObject.tag == "Wall" || collider.gameObject.tag == "Door")
        {
            Destroy(collider.gameObject);
        }
    }
}
