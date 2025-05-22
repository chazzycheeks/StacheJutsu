using UnityEngine;

public class Timer : MonoBehaviour
{
    public float firstTimer = 6.3f;
    public float timeLimit = 0f;
    public float secondTimer = 4.8f;
    public float thirdTimer = 3.8f;
    public float fourthTimer = 3f;
    
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
            audioManager.PlayFail();
        }

    }
    public void ResetTimer()
    {
        timeLimit = 0f;
    }
    

    
}
