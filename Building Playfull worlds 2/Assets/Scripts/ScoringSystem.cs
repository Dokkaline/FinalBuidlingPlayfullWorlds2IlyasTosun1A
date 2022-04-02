using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public int theScore;
    void Update()
    {
        scoreText.GetComponent<TMP_Text>().text = "Purified:" + theScore;  
    }
}

