using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    [SerializeField] Transform[] players;

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
            Debug.Log("joystick_" + (i + 1) + " = " + joystickArray[i]);

            Debug.Log(listOfJoysticks[i] + " added to list at position " + i);
        }


        // For each joystick attached, control that coresponding player
        // Maybe we will have a player select screen?
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (Input.GetJoystickNames()[i] == Input.GetJoystickNames()[i])
            {
                float horizontal = Input.GetAxis("Joy " + i + " Horizontal");
                float vertical = Input.GetAxis("Joy " + i + " Vertical");

                Vector3 movement = new Vector3(horizontal, 0, vertical) * 10;

                players[i].position += movement * Time.deltaTime;
            }
        }
    }
}
