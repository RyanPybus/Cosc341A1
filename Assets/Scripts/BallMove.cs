using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    GameObject Ball;
    bool jumpPressed;
    bool onGround;
    double horizontalIn;
    double verticalIn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.y < -5)
        {
            Vector3 respawn = new Vector3 (0, 2, 0);
            GetComponent<Transform>().position = respawn;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) & onGround)
        {
            jumpPressed = true;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            horizontalIn = Input.GetAxis("Horizontal")*5;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            verticalIn = Input.GetAxis("Vertical")*5;
        }

    }

    // Run on physics update
    private void FixedUpdate()
    {
        if (jumpPressed)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.VelocityChange);

            jumpPressed = false;
        }
        if (horizontalIn != 0)
        {
            Vector3 v = GetComponent<Rigidbody>().velocity;
            v.x = (float)horizontalIn;
            GetComponent<Rigidbody>().velocity = v;
        }
        if (verticalIn != 0)
        {
            Vector3 v = GetComponent<Rigidbody>().velocity;
            v.z = (float)verticalIn;
            GetComponent<Rigidbody>().velocity = v;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

}
