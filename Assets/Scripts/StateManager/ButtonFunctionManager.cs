using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}