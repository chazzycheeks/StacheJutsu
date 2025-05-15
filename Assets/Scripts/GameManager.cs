using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<string> sequenceChecker = new List<string>();
    public List<Customers> customerList = new List<Customers>();
    public Customers currentCustomer;
    int sequenceIndex = 0;
    private bool sequenceDone = true;

    [SerializeField] private GameObject leftPrefab;
    [SerializeField] private GameObject rightPrefab;
    [SerializeField] private GameObject upPrefab;
    [SerializeField] private GameObject downPrefab;
    public GameObject arrowDisplay;

    public Animator nice;
    public Animator timerAnimation;
    public Animator scroll;
    public Animator scoreAnimation;
    public Animator hajime;
    Timer timer;
    Score score;

    
    public GameObject mainGame;
    public GameObject gameOver;
    
    public ParticleSystem puffCloud;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        timer = FindAnyObjectByType<Timer>();
        score = FindAnyObjectByType<Score>();

        if (score != null)
        {
            score.ResetScore();
        }
        
        StartCoroutine(GameIntro());       
    }

    // Update is called once per frame
    void Update()
    {
        if (sequenceDone == false)
        {
            HandleSequenceInput();
        }
    }

    public IEnumerator GameIntro()
    {
        scroll.SetTrigger("ScrollOpen");
        yield return new WaitForSecondsRealtime(1.5f);
        timerAnimation.SetTrigger("TimerEntry");
        scoreAnimation.SetTrigger("ScoreEntry");
        yield return new WaitForSecondsRealtime(1f);
        hajime.SetTrigger("Hajime");
        StartCoroutine(LoadNewCustomer());
    }

    private void HandleSequenceInput()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            sequenceChecker.Add("Up");
            CheckSequence();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            sequenceChecker.Add("Down");
            CheckSequence();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            sequenceChecker.Add("Left");
            CheckSequence();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            sequenceChecker.Add("Right");
            CheckSequence();
        }
    }

    private void CheckSequence()
    {
        //Compare the latest string in sequenceChecker to the string in the current customer that has the same index

        // Debug.Log(sequenceChecker[^1][0] + " " + currentCustomer.sequence[sequenceIndex]);
        if (sequenceChecker[^1] == currentCustomer.sequence[sequenceIndex])
        {
            //At this point we know the button has been pressed correctly

            //We can use the sequence index to access the correct child object of the arrow display
            arrowDisplay.transform.GetChild(sequenceIndex).GetComponent<Arrows>().DisplayLitArrow();
            //Tell the arrow to display it's lit version
            //By getting the arrow's child and turning it on
            

            //  Debug.Log($"input at index {sequenceIndex} passed");
            sequenceIndex++;

            if (sequenceIndex == currentCustomer.sequence.Count)
            {
                sequenceIndex = 0;
                sequenceChecker.Clear();
                //switch to shaved sprite
              //  nice.SetTrigger("CustomerCompleted");
                puffCloud.Play();
                currentCustomer.DisplayShavedSprite();
                sequenceDone = true;
                //add 1 to score
                timer.ResetTimer();
                timerAnimation.SetTrigger("ResetTimer");
                score.AddScore();
                //delay 2 seconds
                //LoadNewCustomer
                
                StartCoroutine(LoadNewCustomer());
               

               // Debug.Log("Sequence completed");
            }
        }
        else
        {
            mainGame.SetActive(false);
            gameOver.SetActive(true);
          
        }
    }   
    public IEnumerator LoadNewCustomer()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        if (currentCustomer != null)
        {
            nice.SetTrigger("CustomerCompleted");
        }
        
        yield return new WaitForSecondsRealtime(1f);
       if (currentCustomer != null)
        {
            currentCustomer.gameObject.SetActive(false);
        }
        sequenceDone = false;
        int customerIndex = Random.Range(0, customerList.Count);
        currentCustomer = customerList[customerIndex];
        currentCustomer.gameObject.SetActive(true);
        currentCustomer.DisplayUnshavedSprite();
        if (timer.currentTargetTime == timer.firstTimer)
        {
            timerAnimation.SetTrigger("StartTimer");
        }
        else if (timer.currentTargetTime == timer.secondTimer)
        {
            timerAnimation.SetTrigger("SecondTimer");
        }
        else if (timer.currentTargetTime == timer.thirdTimer)
        {
            timerAnimation.SetTrigger("ThirdTimer");
        }
        else if (timer.currentTargetTime == timer.fourthTimer)
        {
            timerAnimation.SetTrigger("FourthTimer");
        }
        GenerateButtons();
        
        
        
    }

    private void GenerateButtons()
    {
        foreach (Transform childArrows in arrowDisplay.transform)
        {
            Destroy(childArrows.gameObject);
        }
        //Use a foreach loop to check each string in the current customer's sequence list
        foreach (string thisString in currentCustomer.sequence)
        {
            if (thisString == "Right")
            {
                Instantiate(rightPrefab, arrowDisplay.transform);
            }
            if (thisString == "Left")
            {
                Instantiate(leftPrefab, arrowDisplay.transform);
            }
            if (thisString == "Up")
            {
                Instantiate(upPrefab, arrowDisplay.transform);
            }
            if (thisString == "Down")
            {
                Instantiate(downPrefab, arrowDisplay.transform);
            }
        }
        //In this loop, spawn different prefabs depending on what the string is
        //e.g. If the string is "Right" spawn the prefab for the right arrow

        //Make all spawned prefabs a child of the relevant UI object
    }
    
}
