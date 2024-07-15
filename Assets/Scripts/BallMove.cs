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
    Vector3 rebound;

    // Start is called before the first frame update
    void Start()
    {
        rebound = Vector3.zero;
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
            Vector3 oldv = GetComponent<Rigidbody>().velocity;
            oldv.y = 7;
            Debug.Log(rebound * 3);
            oldv = oldv + rebound*3;
            Debug.Log("newv: " + oldv);
            GetComponent<Rigidbody>().velocity = oldv;
            jumpPressed = false;
        }
        if (Mathf.Abs((float)horizontalIn) > 0.2)
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
        Debug.Log("Collision");
        ContactPoint touch = collision.GetContact(0);
        Debug.Log("touch point" + touch.point);
        Vector3 incident = transform.position - touch.point;
        Debug.Log("incident" + incident);
        rebound = (incident / (incident.magnitude));
        Debug.Log("rebound" + rebound);
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
