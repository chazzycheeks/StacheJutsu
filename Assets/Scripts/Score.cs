using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreCounter;
    public int score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DontDestroyOnLoad(this);

        scoreCounter = GetComponent<TextMeshProUGUI>();
        scoreCounter.text = "";
        
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddScore()
    {
        score++;
        scoreCounter.text = "" + score;
        
            
    }
}
