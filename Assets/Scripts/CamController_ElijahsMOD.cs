using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamController_ElijahsMOD : MonoBehaviour {

    [SerializeField] Transform[] players;
    [SerializeField] float minHeight = 10;
    [SerializeField] float maxHeight = 40;

    List<Transform> listOfPlayers = new List<Transform>();
    List<float> xPositions = new List<float>();
    List<float> zPositions = new List<float>();

    float averageXpos = 0;
    float averageZpos = 0;

    // Use this for initialization
    void Start()
    {
        foreach (Transform player in players)
        {
            listOfPlayers.Add(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();

        foreach (Transform player in listOfPlayers)
        {
            averageXpos += player.position.x;
            averageZpos += player.position.z;
        }

        averageXpos /= listOfPlayers.Count;
        averageZpos /= listOfPlayers.Count;

        transform.position = new Vector3(averageXpos, CalculateDistance(), averageZpos);
    }

    float CalculateDistance()
    {
        // Distances between each player's position

        float distance01 = Vector3.Distance(players[0].position, players[1].position);
        float distance02 = Vector3.Distance(players[0].position, players[2].position);
        float distance03 = Vector3.Distance(players[0].position, players[3].position);
        float distance04 = Vector3.Distance(players[1].position, players[2].position);
        float distance05 = Vector3.Distance(players[1].position, players[3].position);
        float distance06 = Vector3.Distance(players[2].position, players[3].position);

        float distances = (distance01 + distance02 + distance03 + distance04 + distance05 + distance06) / 6f;

        Debug.Log("Average distance = " + distances);

        return Mathf.Clamp(distances, minHeight, maxHeight);
    }
}
