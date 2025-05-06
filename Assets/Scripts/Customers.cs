using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    public List<string> sequence = new List<string>();
    [SerializeField] private GameObject unshaved, shaved;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayShavedSprite()
    {
        shaved.SetActive(true);
        unshaved.SetActive(false);
    }
}
