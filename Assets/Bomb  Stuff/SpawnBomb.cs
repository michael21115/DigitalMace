using UnityEngine;
using System.Collections;

public class SpawnBomb : MonoBehaviour {

    [SerializeField]
    float cooldown;

    [SerializeField]
    Transform bomb;

    public bool isBomb;
    private float timer;

    void Start()
    {
        Instantiate(bomb, transform.position, transform.rotation);
        isBomb = true;
    }

	// Update is called once per frame
	void Update () {
        if (!isBomb)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
                if(timer < 0)
                {
                    Instantiate(bomb, transform.position, transform.rotation);
                    isBomb = true;
                }
            }
        }
        else
        {
            timer = cooldown;
        }
	}
}
