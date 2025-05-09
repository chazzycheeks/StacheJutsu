using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    private float firstTimer = 6f;
    private float timeLimit = 0f;
    private float secondTimer = 3.5f;
    private float thirdTimer = 2.5f;
    
    GameManager gameManager;
    Score Score;
    private float currentTargetTime;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Score = FindAnyObjectByType<Score>();
        currentTargetTime = firstTimer;
    }
    private void Update()
    {
        if (gameManager.currentCustomer != null)
        {
            RunTimer();
        }

        if (Score.score == 6)
        {
            currentTargetTime = secondTimer;
        }

        if (Score.score == 12)
        {
            currentTargetTime = thirdTimer;
        }

    }
    public void RunTimer()
    {
        timeLimit += Time.deltaTime;
        if (timeLimit > currentTargetTime)
        {
            gameManager.mainGame.SetActive(false);
            gameManager.gameOver.SetActive(true); 
        }

    }
    public void ResetTimer()
    {
        timeLimit = 0f;
    }
    
    
}
