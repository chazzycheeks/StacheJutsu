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
    
    GameManager gameManager;
    Score Score;
    public float currentTargetTime;
    

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

       /* if (Score.score < 9) 
        {
            
            gameManager.timerAnimation.SetTrigger("StartTimer");
        }*/

        if (Score.score == 3)
        {
            currentTargetTime = secondTimer;
        }

       /* if (Score.score < 19)
        {
            
            gameManager.timerAnimation.SetTrigger("SecondTimer");
            
        }*/

        if (Score.score == 5)
        {
            currentTargetTime = thirdTimer;
        }

        /*if (Score.score > 19)
        {

            gameManager.timerAnimation.SetTrigger("ThirdTimer");
        }*/

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
