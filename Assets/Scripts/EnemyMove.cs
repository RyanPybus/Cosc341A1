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
    void Update()
    {
        Debug.Log(GetComponent<Rigidbody>().velocity);

        if (cooldown > 0) { cooldown -= 1; return; }

        if (Mathf.Abs(transform.position.x - home.x) > 4.5)
        {
            Vector3 newVelocity = GetComponent<Rigidbody>().velocity * -1;
            GetComponent<Rigidbody>().velocity = newVelocity;
            cooldown = 10;
        }
        
    }
}
