using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlayButton()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
