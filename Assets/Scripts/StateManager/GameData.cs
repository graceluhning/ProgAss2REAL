using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currentMoney;
    public MoneyManager moneyManager;

    public GameData(int currentCoins, float currentHealth, Vector3 currentPos)
    {
        currentMoney = moneyManager.Money;
       
    }
}