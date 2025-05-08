using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float firstTimer = 5f;
    public float timeLimit = 0f;
    public float secondTimer = 3f;
    public float thirdTimer = 2f;
    
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

        if (Score.score == 5)
        {
            currentTargetTime = secondTimer;
        }

        if (Score.score == 10)
        {
            currentTargetTime = thirdTimer;
        }

    }
    public void RunTimer()
    {
        timeLimit += Time.deltaTime;
        if (timeLimit > currentTargetTime)
        {
            SceneManager.LoadScene(2);
        }

    }
    public void ResetTimer()
    {
        timeLimit = 0f;
    }
    
    
}
