using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] public GameManager gameManager;
    [SerializeField] private float startTime = 60f;

    private float currentTime;
    private bool isTimerRunning = false;

    void Start()
    {
        currentTime = startTime;
        timerImage.fillAmount = 1f;

        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!isTimerRunning)
            return;

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerImage.fillAmount = currentTime / startTime;
        }
        else
        {
            TimerFinished();
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        Time.timeScale = 1f;
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        timerImage.fillAmount = 1f;
        isTimerRunning = true;
        Time.timeScale = 1f;
    }

    public void TimerFinished()
    {
        isTimerRunning = false;
        currentTime = 0;
        timerImage.fillAmount = 0f;

        NPClogic[] npcs = FindObjectsOfType<NPClogic>();

        foreach (NPClogic npc in npcs)
        {
            npc.Kill();
        }

        Time.timeScale = 0f;

        GameManager.Instance.ChangeState(GameState.Shopping);
    }
}