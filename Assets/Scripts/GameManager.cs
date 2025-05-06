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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // currentCustomer = LoadNewCustomer();
    }

    // Update is called once per frame
    void Update()
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
            //  Debug.Log($"input at index {sequenceIndex} passed");
            sequenceIndex++;
            if (sequenceIndex == currentCustomer.sequence.Count)
            {
                sequenceIndex = 0;
                sequenceChecker.Clear();
                //switch to shaved sprite
                currentCustomer.DisplayShavedSprite();
                
                //add 1 to score
                //delay 2 seconds
                //LoadNewCustomer
                StartCoroutine(LoadNewCustomer());
               

                Debug.Log("Sequence completed");
            }
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }   
    private IEnumerator LoadNewCustomer()
    {
        yield return new WaitForSeconds(1.5f);

        //Logic to load in the next customer
    }
    
}
