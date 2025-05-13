using UnityEngine;
using static UnityEngine.Rendering.ProbeAdjustmentVolume;

public class Arrows : MonoBehaviour

{
    [SerializeField] private GameObject lit;
  //  [SerializeField] private GameObject unlit;

    public Animator litButton;

    public void DisplayLitArrow()
    {
       // unlit.SetActive(false);
        lit.SetActive(true);

        litButton.SetTrigger("ButtonLit");
    }
    public void DisplayUnlitArrow ()
    {
        lit.SetActive(false);
       // unlit.SetActive(true);
    }
}
