using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector3 home;
    int bound;
    int seed;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        home = transform.position;
        bound = 5;
        seed = 1;
        if (Random.value > 0.5)
        {
            seed = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - home.x) > bound)
        {
            seed = seed * -1;
        }
        count = count + seed;
        Vector3 pos = transform.position;
        pos.x = count * (float)0.01;
        transform.position = pos;
    }
}
