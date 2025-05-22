using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
   /* [SerializeField] private TextMeshProUGUI highScoreText;*/
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

    /*public void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore:{PlayerPrefs.GetInt("HighScore", 0)}";
    }
   */
}

