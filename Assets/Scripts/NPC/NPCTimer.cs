using UnityEngine;
using  UnityEngine.UI;

public class NPCTimer : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    
    [SerializeField] private float startTime = 15f;
    
    private NPClogic npclogic;
    
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


    public void TimerFinished()
    {
        isTimerRunning = false;
        currentTime = 0;
        timerImage.fillAmount = 0f;
        
        npclogic.Kill();
        
    }
}