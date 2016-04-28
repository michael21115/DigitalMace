using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using XInputDotNetPure;

public class PlayerController : MonoBehaviour {

    [SerializeField] float waitTime = 10f;
    [SerializeField] float currTime = 0f;

    public int playerNo;
    public float speed = 2000f;
    public float dashSpeed = 5f;
    public float dashBoost = 1000f;
    bool canDash = true;
    bool hasDashed = false;

	// Use this for initialization
	void Update ()
    {
        if (hasDashed)
        {
            currTime += Time.deltaTime;
            if (currTime >= waitTime)
            {
                hasDashed = false;
                canDash = true;
                currTime = 0f;
            }
            }

        PlayerInput();
    }
    /// <summary>
    /// Checks for and runs player input
    /// </summary>
    void PlayerInput()
    {
        // For each joystick attached, control that coresponding player
        // Maybe we will have a player select screen?
        float horizontal = Input.GetAxis("Joy " + playerNo + " Horizontal");
        float vertical = Input.GetAxis("Joy " + playerNo + " Vertical");
            Vector3 movement = new Vector3(horizontal, 0, vertical) * speed;

            //players[i].position += movement * Time.deltaTime;

        Ray groundCheck = new Ray(transform.position, -transform.up);
        RaycastHit groundCheckInfo = new RaycastHit();

        if (Physics.Raycast(groundCheck, out groundCheckInfo, (transform.localScale.y * 0.5f * 1.05f)))
        {
            GetComponent<Rigidbody>().velocity = (movement + Physics.gravity) * Time.deltaTime;
        }
        else
        {
            GetComponent<Rigidbody>().velocity += Physics.gravity * Time.deltaTime;
        }

            if (movement != Vector3.zero)
            {
                //snaps to movement direction... a little jumpy
           transform.forward = Vector3.Normalize(movement);
            }

        //Add controller face buttons and data loss capture

        if (playerNo < Input.GetJoystickNames().Length)
        {
            // Input for xBox Controllers
            if (Input.GetJoystickNames()[playerNo].Contains("Xbox"))
            {
                Xbox_Controls();
            }
            // Input for other (PS4) Controllers
            else if (Input.GetJoystickNames()[playerNo].Contains("Wireless"))
            {
                PS4_WirelessControls();
            }
        }
    }

    void Xbox_Controls ()
            {
        if (Input.GetButtonDown("Joy " + playerNo + " A"))
                {
            Debug.Log("Player " + playerNo + 1 + " pressed 'A'");

            if (GetComponent<ObjectInteraction>().throwItem)
                    {
                Transform throwObject = GetComponent<ObjectInteraction>().hands[0].GetChild(0);
                        Rigidbody objectRB = throwObject.GetComponent<Rigidbody>();

                        // throw the game object in your off hand
                        players[i].GetComponent<ObjectInteraction>().throwItem = false;
                        throwObject.tag = "Projectile";
                        objectRB.constraints = RigidbodyConstraints.None;
                        objectRB.constraints = RigidbodyConstraints.FreezeRotation;
                objectRB.mass = GetComponent<ObjectInteraction>().objectMass; // resets the mass of the object before it is thrown
                objectRB.AddForce(transform.forward * GetComponent<ObjectInteraction>().throwForce * 1000f);
                        objectRB.useGravity = true;
                GetComponent<ObjectInteraction>().hands[0].DetachChildren();
                    }
                }
        if (Input.GetButtonDown("Joy " + playerNo + " B"))
                {
            Debug.Log("Player " + playerNo + 1 + " pressed 'B'");
                }
        if (Input.GetButtonDown("Joy " + playerNo + " X"))
                {
            Debug.Log("Player " + playerNo + 1 + " pressed 'X'");

            if (canDash && !hasDashed)
            {
                canDash = false;
                hasDashed = true;
                GetComponent<Rigidbody>().AddForce((Vector3.up * dashBoost) + (transform.forward * dashSpeed * dashBoost));
            }

            if (GetComponent<ObjectInteraction>().throwItem)
            {
                Transform throwObject = GetComponent<ObjectInteraction>().hands[0].GetChild(0);
                Rigidbody objectRB = throwObject.GetComponent<Rigidbody>();

                // drop the game object in your off hand
                GetComponent<ObjectInteraction>().throwItem = false;
                objectRB.constraints = RigidbodyConstraints.None;
                objectRB.constraints = RigidbodyConstraints.FreezeRotation;
                objectRB.mass = GetComponent<ObjectInteraction>().objectMass; // resets the mass of the object before it is thrown
                objectRB.AddForce(transform.up * 500);
                objectRB.useGravity = true;
                GetComponent<ObjectInteraction>().hands[0].DetachChildren();
            }
                }
        if (Input.GetButtonDown("Joy " + playerNo + " Y"))
                {
            Debug.Log("Player " + playerNo + 1 + " pressed 'Y'");

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }

    void PS4_WirelessControls ()
            {
        if (Input.GetButtonDown("Joy " + playerNo + " A"))
                {
            Debug.Log("Player " + playerNo + 1 + " pressed 'square'");
                }
        if (Input.GetButtonDown("Joy " + playerNo + " B"))
                {
            Debug.Log("Player " + playerNo + 1 + " pressed 'cross'");

            if (GetComponent<ObjectInteraction>().throwItem)
                    {
                Transform throwObject = GetComponent<ObjectInteraction>().hands[0].GetChild(0);
                        Rigidbody objectRB = throwObject.GetComponent<Rigidbody>();

                        // throw the game object in your off hand
                GetComponent<ObjectInteraction>().throwItem = false;
                        throwObject.tag = "Projectile";
                        objectRB.constraints = RigidbodyConstraints.None;
                        objectRB.constraints = RigidbodyConstraints.FreezeRotation;
                objectRB.detectCollisions = true;
                objectRB.AddForce(transform.forward * GetComponent<ObjectInteraction>().throwForce * 1000f);
                        objectRB.useGravity = true;
                GetComponent<ObjectInteraction>().hands[0].DetachChildren();
                    }
                }
        if (Input.GetButtonDown("Joy " + playerNo + " X"))
                {
            Debug.Log("Player " + playerNo + 1 + " pressed 'circle'");
                }
        if (Input.GetButtonDown("Joy " + playerNo + " Y"))
                {
            Debug.Log("Player " + playerNo + 1 + " pressed 'triangle'");

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
