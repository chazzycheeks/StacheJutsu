using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayScreen;
    public GameObject creditsScreen;
    public GameObject mainMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlayButton()
    {
        mainMenu.SetActive(false);
        howToPlayScreen.SetActive(true);
    }

    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        if (creditsScreen != null)
        {
            creditsScreen.SetActive(false);
        }

        if (howToPlayScreen != null)
        {
            howToPlayScreen.SetActive(false);
        }
        mainMenu.SetActive(true);
    }
}
