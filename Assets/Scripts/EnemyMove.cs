using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Vector3 home;
    int seed;
    Vector3 initVelocity = Vector3.zero;
    int cooldown;

    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
        seed = 1;
        if (Random.value > 0.5)
        {
            seed = -1;
        }
        initVelocity.x = seed;
        GetComponent<Rigidbody>().velocity = initVelocity*5;
    }

    // Update is called once per frame
    // if enemy is more than 4.5 units away from home, redirect enemy to face home.
    void Update()
    {
        if ((transform.position - home).magnitude > 4.5)
        {
            float speed = GetComponent<Rigidbody>().velocity.magnitude;
            Vector3 pointHome = (home - transform.position);
            pointHome = pointHome / pointHome.magnitude;
            Vector3 newVelocity = pointHome * speed;
            while (newVelocity.magnitude < 5)
            {
                newVelocity = newVelocity * (float)1.1;
            }

            GetComponent<Rigidbody>().velocity = newVelocity;
        }
        
    }
}
