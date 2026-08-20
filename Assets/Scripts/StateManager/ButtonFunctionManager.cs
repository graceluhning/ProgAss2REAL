using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionManager : MonoBehaviour
{
    public GameObject Shop1;
    public GameObject Shop2;
    public GameObject tutorialPanel;
    [SerializeField] private DayTimer dayTimer;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("OpeningScene");
    }
    
    public void RePlayGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShopRight()
    {
        Shop1.SetActive(false);
        Shop2.SetActive(true);
    }
    public void ShopLeft()
    {
        Shop1.SetActive(true);
        Shop2.SetActive(false);
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);

        dayTimer.StartTimer();
    }
}