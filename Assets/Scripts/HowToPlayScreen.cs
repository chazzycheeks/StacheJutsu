using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayScreen : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
