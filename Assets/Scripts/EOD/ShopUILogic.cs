using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUILogic : MonoBehaviour
{
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private DayTimer timer;
    
    [SerializeField] GameObject nextDayUI;

    [SerializeField] private Button strawberryButton;
    [SerializeField] TMP_Text strawText;
    public bool strawBought;
    [SerializeField] private GameObject strawSpawner;
    
    [SerializeField] private Button chocolateButton;
    [SerializeField] TMP_Text chocolateText;
    public bool chocolateBought;
    [SerializeField] private GameObject chocolateSpawner;

    
    [SerializeField] private Button mintButton;
    [SerializeField] TMP_Text mintText;
    public bool mintBought;
    [SerializeField] private GameObject mintSpawner;

    
    [SerializeField] private Button mangoButton;
    [SerializeField] TMP_Text mangoText;
    public bool mangoBought;
    [SerializeField] private GameObject mangoSpawner;

    
        
    [SerializeField] private Button cookiesCreamButton;
    [SerializeField] TMP_Text cookiesCreamText;
    public bool cookiesCreamBought;
    [SerializeField] private GameObject cookiesCreamSpawner;
    
    public DayCounter dayCounter;
    
    
    public void NextDay() // when next day pressed, reset timer and begin next day
    {
        nextDayUI.SetActive(false);
        Time.timeScale = 1f;

        timer.currentTime = timer.startTime;

        dayCounter.NextDay();
        Debug.Log(dayCounter.dayCount);
        
    }

    public void BuyChocolate()
    {
        if (chocolateBought) return;

        if (_moneyManager.Money >= 10)
        {
            _moneyManager.RemoveMoney(10);
            chocolateBought = true;
            
            if (chocolateBought)
            {
                chocolateSpawner.SetActive(true);
            }
            
            
            chocolateText.text = "BOUGHT";
            chocolateButton.interactable = false;
            
            Debug.Log("Bought Armor!");
        
        }
        
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    public void BuyStrawberry()
    {
        if (strawBought) return;

        if (_moneyManager.Money >= 20)
        {
            _moneyManager.RemoveMoney(20);
            strawBought = true;
            
            if (strawBought)
            {
                strawSpawner.SetActive(true);
            }

            strawText.text = "BOUGHT";
            strawberryButton.interactable = false;

            Debug.Log("Bought Strawberry!");
        }
        
        else
        {
            Debug.Log("Not enough coins!");
        }

    }

    public void BuyMint()
    {
        if (mintBought) return;

        if (_moneyManager.Money >= 30)
        {
            _moneyManager.RemoveMoney(30);
            mintBought = true;
            
            if (mintBought)
            {
                mintSpawner.SetActive(true);
            }

            mintText.text = "BOUGHT";
            mintButton.interactable = false;


            Debug.Log("Bought Mint!");
        }

        else
        {
            Debug.Log("Not enough coins!");
        }

    }
    
    public void BuyMango()
    {
        if (mangoBought) return;

        if (_moneyManager.Money >= 40)
        {
            _moneyManager.RemoveMoney(40);
            mangoBought = true;
            
            if (mangoBought)
            {
                mangoSpawner.SetActive(true);
            }

            mangoText.text = "BOUGHT";
            mangoButton.interactable = false;


            Debug.Log("Bought Mango!");
        }

        else
        {
            Debug.Log("Not enough coins!");
        }

    }
    
    public void BuyCookiesCream()
    {
        if (cookiesCreamBought) return;

        if (_moneyManager.Money >= 50)
        {
            _moneyManager.RemoveMoney(50);
            cookiesCreamBought = true;
            
            if (cookiesCreamBought)
            {
                cookiesCreamSpawner.SetActive(true);
            }

            cookiesCreamText.text = "BOUGHT";
            cookiesCreamButton.interactable = false;


            Debug.Log("Bought Cookies and Cream!");
        }

        else
        {
            Debug.Log("Not enough coins!");
        }

    }


}

