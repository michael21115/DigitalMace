using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

    [SerializeField]
    Transform pcTransform;

    [SerializeField]
    float slowSpeed;

    private float defaultSpeed;
    private PlayerController playerController;

    void Start()
    {
        pcTransform = GameObject.Find("Controller_GameObject").transform;
        playerController = pcTransform.GetComponent<PlayerController>();
        defaultSpeed = playerController.speed;
    }

    void Update()
    {
        playerController = pcTransform.GetComponent<PlayerController>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Contains("Player"))
        {
            playerController.speed = slowSpeed;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag.Contains("Player"))
        {
            playerController.speed = defaultSpeed;
        }
    }
}
