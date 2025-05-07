using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    public List<string> sequence = new List<string>();
    [SerializeField] private GameObject unshaved, shaved;
    public void DisplayShavedSprite()
    {
        shaved.SetActive(true);
        unshaved.SetActive(false);
    }
    public void DisplayUnshavedSprite()
    {
        shaved.SetActive(false);
        unshaved.SetActive(true);
    }
}
