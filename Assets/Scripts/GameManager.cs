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

    [SerializeField] private Animator nice;
    [SerializeField] private Animator timerAnimation;
    Timer timer;
    Score score;

    
    public GameObject mainGame;
    public GameObject gameOver;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        timer = FindAnyObjectByType<Timer>();
        score = FindAnyObjectByType<Score>();

        if (score != null)
        {
            score.ResetScore();
        }
        StartCoroutine(LoadNewCustomer());
    }

    // Update is called once per frame
    void Update()
    {
        if (sequenceDone == false)
        {
            HandleSequenceInput();
        }
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
                nice.SetTrigger("CustomerCompleted");
                currentCustomer.DisplayShavedSprite();
                sequenceDone = true;
                //add 1 to score
                timer.ResetTimer();
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
       
        yield return new WaitForSeconds(1f);
       if (currentCustomer != null)
        {
            currentCustomer.gameObject.SetActive(false);
        }
        sequenceDone = false;
        int customerIndex = Random.Range(0, customerList.Count);
        currentCustomer = customerList[customerIndex];
        currentCustomer.gameObject.SetActive(true);
        currentCustomer.DisplayUnshavedSprite();
        GenerateButtons();
        timerAnimation.SetTrigger("StartTimer");
        
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
