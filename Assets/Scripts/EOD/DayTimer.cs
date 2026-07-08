using UnityEngine;
using  UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] public GameObject endDayUI;
    
    [SerializeField] private float startTime = 120f;
    
    private float currentTime;
    private bool isTimerRunning = false;

    void Start()
    {
        currentTime = startTime;
        StartTimer();
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
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        timerImage.fillAmount = 1f;
        isTimerRunning = true;
    }

    public void TimerFinished()
    {
        isTimerRunning = false;
        currentTime = 0;
        timerImage.fillAmount = 0f;

        Time.timeScale = 0f;
        endDayUI.SetActive(true);
    }
}

