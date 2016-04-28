using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using XInputDotNetPure;

public class PlayerController : MonoBehaviour {

    [SerializeField] Transform[] players;
    public float speed = 50;

    List<string> listOfJoysticks = new List<string>();
    string[] joystickArray;

	// Use this for initialization
	void Update ()
    {
        joystickArray = new string[] { "NULL", "NULL", "NULL", "NULL" };

        // This doesn't work but, the idea is to track the controllers and slot numbers
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (Input.GetJoystickNames()[i] != null)
            {
                joystickArray[i] = Input.GetJoystickNames()[i];

                listOfJoysticks.Add(joystickArray[i]);
            }
            else if (Input.GetJoystickNames()[i] == null)
            {
                joystickArray[i] = "NULL";

                listOfJoysticks.RemoveAt(i);
            }
            //Debug.Log("joystick_" + (i + 1) + " = " + joystickArray[i]);

            //Debug.Log(listOfJoysticks[i] + " added to list at position " + i);
        }

        PlayerInput();


    }
    /// <summary>
    /// Checks for and runs player input
    /// </summary>
    void PlayerInput ()
    {
        // For each joystick attached, control that coresponding player
        // Maybe we will have a player select screen?
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            float horizontal = Input.GetAxis("Joy " + i + " Horizontal");
            float vertical = Input.GetAxis("Joy " + i + " Vertical");
            Vector3 movement = new Vector3(horizontal, 0, vertical) * speed;

            //players[i].position += movement * Time.deltaTime;
            players[i].GetComponent<Rigidbody>().velocity = movement + Physics.gravity;

            if (movement != Vector3.zero)
            {
                //snaps to movement direction... a little jumpy
                players[i].forward = Vector3.Normalize(movement);
            }

            //Add player buttons and data loss capture

            // Input for xBox Controllers
            if (Input.GetJoystickNames()[i].Contains("Xbox"))
            {
                if (Input.GetButtonDown("Joy " + i + " A"))
                {
                    Debug.Log("Player " + i + 1 + " pressed 'A'");

                    if (players[i].GetComponent<ObjectInteraction>().throwItem)
                    {
                        Rigidbody objectRB = players[i].GetComponent<ObjectInteraction>().hands[0].GetChild(0).GetComponent<Rigidbody>();

                        // throw the game object in your off hand
                        players[i].GetComponent<ObjectInteraction>().throwItem = false;
                        objectRB.constraints = RigidbodyConstraints.None;
                        objectRB.constraints = RigidbodyConstraints.FreezeRotation;
                        objectRB.AddForce(players[i].forward * players[i].GetComponent<ObjectInteraction>().throwForce * 1000f);
                        objectRB.useGravity = true;
                        players[i].GetComponent<ObjectInteraction>().hands[0].DetachChildren();
                    }
                }
                if (Input.GetButtonDown("Joy " + i + " B"))
                {
                    Debug.Log("Player " + i + 1 + " pressed 'B'");
                }
                if (Input.GetButtonDown("Joy " + i + " X"))
                {
                    Debug.Log("Player " + i + 1 + " pressed 'X'");
                }
                if (Input.GetButtonDown("Joy " + i + " Y"))
                {
                    Debug.Log("Player " + i + 1 + " pressed 'Y'");
                }
            }
            // Input for other (PS4) Controllers
            else if (Input.GetJoystickNames()[i].Contains("Wireless"))
            {
                if (Input.GetButtonDown("Joy " + i + " A"))
                {
                    Debug.Log("Player " + i + 1 + " pressed 'square'");
                }
                if (Input.GetButtonDown("Joy " + i + " B"))
                {
                    Debug.Log("Player " + i + 1 + " pressed 'cross'");

                    if (players[i].GetComponent<ObjectInteraction>().throwItem)
                    {
                        Rigidbody objectRB = players[i].GetComponent<ObjectInteraction>().hands[0].GetChild(0).GetComponent<Rigidbody>();

                        // throw the game object in your off hand
                        players[i].GetComponent<ObjectInteraction>().throwItem = false;
                        objectRB.constraints = RigidbodyConstraints.None;
                        objectRB.constraints = RigidbodyConstraints.FreezeRotation;
                        objectRB.AddForce(players[i].forward * players[i].GetComponent<ObjectInteraction>().throwForce * 1000f);
                        objectRB.useGravity = true;
                        players[i].GetComponent<ObjectInteraction>().hands[0].DetachChildren();
                    }
                }
                if (Input.GetButtonDown("Joy " + i + " X"))
                {
                    Debug.Log("Player " + i + 1 + " pressed 'circle'");
                }
                if (Input.GetButtonDown("Joy " + i + " Y"))
                {
                    Debug.Log("Player " + i + 1 + " pressed 'triangle'");
                }
            }
        }
    }
}
