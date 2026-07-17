using UnityEngine;
using UnityEngine.UI;

public class NPCTimer : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float startTime = 15f;
    [SerializeField] private NPClogic npclogic;

    public float currentTime;
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

            float fill = currentTime / startTime;
            timerImage.fillAmount = fill;

            if (fill > 0.5f)
            {
                timerImage.color = Color.green;
            }
            else if (fill > 0.25f)
            {
                timerImage.color = Color.yellow;
            }
            else
            {
                timerImage.color = Color.red;
            }
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

    public void TimerFinished()
    {
        isTimerRunning = false;
        currentTime = 0;
        timerImage.fillAmount = 0f;

        npclogic.Kill();
    }
    
}