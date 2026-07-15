using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public int Money;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Money = 120;
        UpdateMoneyUI();
    }

    public void AddMoney(int amount)
    {
        Money += amount;

        Debug.Log("Earned $" + amount);
        Debug.Log("Total Money: $" + Money);

        UpdateMoneyUI();
    }

    public void RemoveMoney(int amount)
    {
        Money -= amount;

        if (Money < 0)
            Money = 0;

        UpdateMoneyUI();
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
            moneyText.text = "COINS: " + Money;
    }
}