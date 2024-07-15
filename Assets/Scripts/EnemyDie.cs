using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parent = GameObject.Find("enemy1").GetComponent<Rigidbody>().position;
        parent.y += 1;
        gameObject.transform.position = parent;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ball")
        {
            Vector3 temp = GameObject.Find("Ball").GetComponent<Rigidbody>().velocity;
            temp.y = 4;
            GameObject.Find("Ball").GetComponent<Rigidbody>().velocity = temp;
            GameObject.Find("enemy1").SetActive(false);
            gameObject.SetActive(false);
            GameObject.Find("UI").GetComponent<Scoring>().score+=5;
        }
    }
}
