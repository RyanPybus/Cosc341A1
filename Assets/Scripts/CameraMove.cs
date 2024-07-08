using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    double horizontalIn;
    double verticalIn;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;
        Vector3 ballPos = GameObject.Find("Ball").GetComponent<Transform>().position;
        pos.z = ballPos.z - 8;
        GetComponent<Transform>().position = pos;

    }
}
