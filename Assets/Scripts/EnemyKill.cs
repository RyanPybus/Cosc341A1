using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ball")
        {
            ContactPoint impact = collision.GetContact(0);
            Vector3 up = new Vector3(0, 1, 0);
            if (Mathf.Abs(Vector3.Dot(impact.normal, up)) > 0.8)
            {
                gameObject.SetActive(false);
                GameObject.Find("UI").GetComponent<Scoring>().score += 5;
                return;
            }
            GameObject.Find("Ball").GetComponent<BallMove>().isDead = true;
        }
    }
}
