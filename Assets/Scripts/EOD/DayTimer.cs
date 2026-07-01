using UnityEngine;
using TMPro;

public class DayTimer : MonoBehaviour
{
    [SerializeField] public float startTime = 60f;
    [SerializeField] public TMP_Text timerText;

    public float currentTime;
    [SerializeField] public GameObject endDayUI;

    private void Start()
    {
        currentTime = startTime;
        Debug.Log(currentTime);
    }

    private void Update()
    {
        if (currentTime <= 0f)
        {
            endDayUI.SetActive(true);
            Time.timeScale = 0f;
        }

        currentTime -= Time.deltaTime;

        if (currentTime < 0f)
        timerText.text = currentTime.ToString();
    }
}
