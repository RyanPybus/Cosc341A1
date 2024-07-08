using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    Vector3 respawn = new Vector3(0, 2, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        resetBall();
    }
    void resetBall()
    {
        GameObject.Find("Ball").GetComponent<Transform>().position = respawn;
        Debug.Log("reset");
    }
}
