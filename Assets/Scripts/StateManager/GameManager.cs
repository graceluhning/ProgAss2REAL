using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;
    [SerializeField] public RentCycle rentCycle;
    [SerializeField] public MoneyManager moneyManager;
    [SerializeField] public GameObject endDayUI;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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

        Time.timeScale = 1f;
    }


    private void OpenShop()
    {
        Debug.Log("Shopping Phase");
        
        endDayUI.SetActive(true);
        rentCycle.PayRent();

        if (moneyManager.Money <= 0)
        {
            GameManager.Instance.ChangeState(GameState.GameOver);
            return;
        }

    }


    private void EndDay()
    {
        Debug.Log("Day Complete");
    }


    private void LoseGame()
    {
        Debug.Log("Game Over");

        Time.timeScale = 0f;

        SceneManager.LoadScene("GameLostScene");
    }


    private void WinGame()
    {
        Debug.Log("You Won!");

        Time.timeScale = 0f;

        SceneManager.LoadScene("GameWonScene");
    }
}