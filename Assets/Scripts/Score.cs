using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    
    public int score;

    public void ResetScore()
    {
        score = 0;
    }   
    public void AddScore()
    {
        score++;    
    }
}
