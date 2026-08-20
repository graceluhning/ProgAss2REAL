using UnityEngine;
using TMPro;

public class DayCounter : MonoBehaviour
{
    [SerializeField] public int dayCount;
    [SerializeField] public TMP_Text recieptDay;

    void Start()
    {
        dayCount = 1;
        recieptDay.text = "DAY " + dayCount;
    }

    public void NextDay()
    {
        dayCount++;

        Debug.Log("Next day initiated");

        recieptDay.text = "DAY " + dayCount;

        if (dayCount == 6)
        {
            GameManager.Instance.ChangeState(GameState.GameWon);
        }
    }
}