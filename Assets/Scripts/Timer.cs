using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float firstTimer = 6f;
    public float timeLimit = 0f;
    public float secondTimer = 4.5f;
    public float thirdTimer = 3.5f;
    public float fourthTimer = 2.5f;
    
    GameManager gameManager;
    Score Score;
    public float currentTargetTime;
    AudioManager audioManager;
    

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Score = FindAnyObjectByType<Score>();
        audioManager = FindAnyObjectByType<AudioManager>();
        currentTargetTime = firstTimer;
      
    }
    private void Update()
    {
        if (gameManager.currentCustomer != null)
        {
            RunTimer();
        }

       /* if (Score.score % 10 == 0 && Score.score > 0)
        {
            audioManager.PlayProgressDing();
        }*/

        if (Score.score == 10)
        {
            currentTargetTime = secondTimer;

        }

        if (Score.score == 20)
        {
            currentTargetTime = thirdTimer;
        }

        if (Score.score == 35)
        {
            currentTargetTime = fourthTimer;

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
