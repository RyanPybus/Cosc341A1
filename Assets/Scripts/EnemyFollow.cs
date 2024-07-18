using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Ballpos = GameObject.Find("Ball").GetComponent<Transform>().position;
        if (Ballpos.z > 46 && Ballpos.z < 64)
        {
            Vector3 target = (Ballpos - transform.position);
            target.y = 0;
            target = target.normalized;
            Vector3 newVelocity = target * 3;
            GetComponent<Rigidbody>().velocity = newVelocity;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }
}
