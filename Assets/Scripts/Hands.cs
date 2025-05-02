using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Hands : MonoBehaviour
{
    [SerializeField] private GameObject upHand;
    [SerializeField] private GameObject downHand;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upHand.SetActive(true);
            downHand.SetActive(false);
            leftHand.SetActive(false);
            rightHand.SetActive(false);     
        }
       else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            upHand.SetActive(false);
            downHand.SetActive(true);
            leftHand.SetActive(false);
            rightHand.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            upHand.SetActive(false);
            downHand.SetActive(false);
            leftHand.SetActive(true);
            rightHand.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            upHand.SetActive(false);
            downHand.SetActive(false);
            leftHand.SetActive(false);
            rightHand.SetActive(true);
        }
    }
}
