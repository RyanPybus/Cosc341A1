using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scoring : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString(); 
    }
}
