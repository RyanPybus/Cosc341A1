using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    GameObject Ball;
    bool jumpPressed;
    bool onGround;
    public bool isDead;
    public bool killable;
    double horizontalIn;
    double verticalIn;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) respawn();

        if (GetComponent<Transform>().position.y < -5)
        {
            isDead=true;
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

    // if dead, teleport to start location, decrement score, reset dead status.
    void respawn()
    {
        Vector3 spawn = new Vector3(0, 2, 0);
        GetComponent<Transform>().position = spawn;
        GameObject.Find("UI").GetComponent<Scoring>().score--;

        isDead = false;
        return;
    }

    // Run on physics update
    private void FixedUpdate()
    {
        if (jumpPressed)
        {
            Vector3 oldv = GetComponent<Rigidbody>().velocity;
            oldv.y = 10;
            GetComponent<Rigidbody>().velocity = oldv;
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

    private void OnCollisionEnter(Collision collision)
    {

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
