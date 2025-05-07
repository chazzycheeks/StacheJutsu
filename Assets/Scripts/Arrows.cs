using UnityEngine;
using static UnityEngine.Rendering.ProbeAdjustmentVolume;

public class Arrows : MonoBehaviour
{
    [SerializeField] private GameObject lit;
    public void DisplayLitArrow()
    {
        lit.SetActive(true);
    }
    public void DisplayUnlitArrow ()
    {
        lit.SetActive(false);
    }
}
