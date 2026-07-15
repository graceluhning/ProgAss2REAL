using UnityEngine;
public class RentCycle : MonoBehaviour
   {
       public DayCounter dayCounter;
       public MoneyManager moneyManager;

       public void PayRent()
       {
           int rentAmount = dayCounter.dayCount * 10;

           moneyManager.RemoveMoney(rentAmount);

           Debug.Log("Rent paid: " + rentAmount);
       }
       
    }

