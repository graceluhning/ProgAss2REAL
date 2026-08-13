using UnityEngine;
using TMPro;
public class RentCycle : MonoBehaviour
   {
       public DayCounter dayCounter;
       public MoneyManager moneyManager;

       [SerializeField] public TMP_Text rentText; 

       public void PayRent()
       {
           int rentAmount = dayCounter.dayCount * 10;
           
           rentText.text = "$" + rentAmount.ToString();

           moneyManager.RemoveMoney(rentAmount);

           Debug.Log("Rent paid: " + rentAmount);
       }
       
    }

