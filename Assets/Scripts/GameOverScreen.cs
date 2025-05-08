using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    Score finalScore;

    private void Start()
    {
        finalScore = FindAnyObjectByType<Score>();
    }
    public void DisplayFinalScore()
    {
        scoreText.text = finalScore.score.ToString();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
