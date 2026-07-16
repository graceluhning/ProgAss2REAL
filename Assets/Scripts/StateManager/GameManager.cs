using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        ChangeState(GameState.Playing);
    }


    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.Playing:
                StartDay();
                break;

            case GameState.Shopping:
                OpenShop();
                break;

            case GameState.DayComplete:
                EndDay();
                break;

            case GameState.GameOver:
                LoseGame();
                break;

            case GameState.GameWon:
                WinGame();
                break;
        }
    }


    private void StartDay()
    {
        Debug.Log("Day Started");

    }


    private void OpenShop()
    {
        Debug.Log("Shopping Phase");

    }


    private void EndDay()
    {
        Debug.Log("Day Complete");

    }


    private void LoseGame()
    {
        Debug.Log("Game Over");

    }


    private void WinGame()
    {
        Debug.Log("You Won!");
    }
}