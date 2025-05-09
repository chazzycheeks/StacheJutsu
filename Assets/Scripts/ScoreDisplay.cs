using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    Score currentScore;

    private void Start()
    {
       currentScore = FindAnyObjectByType<Score>();
       scoreText = GetComponent<TextMeshProUGUI>();  
    }
    private void Update()
    {
        scoreText.text = currentScore.score.ToString();
    }
   
}

