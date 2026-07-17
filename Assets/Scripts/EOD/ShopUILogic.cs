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
    
    [SerializeField] private Button cherryButton;
    [SerializeField] TMP_Text cherryText;
    public bool cherryBought;
    [SerializeField] private GameObject cherrySpawner;
    
    [SerializeField] private Button whippedCreamButton;
    [SerializeField] TMP_Text whippedCreamText;
    public bool whippedCreamBought;
    [SerializeField] private GameObject whippedCreamSpawner;
    
    [SerializeField] private Button sprinklesButton;
    [SerializeField] TMP_Text sprinklesText;
    public bool sprinklesBought;
    [SerializeField] private GameObject sprinklesSpawner;
    
    [SerializeField] private Button cupOneButton;
    [SerializeField] TMP_Text cupOneText;
    public bool cupOneBought;
    [SerializeField] private GameObject cupOneSpawner;
    
    [SerializeField] private Button cupTwoButton;
    [SerializeField] TMP_Text cupTwoText;
    public bool cupTwoBought;
    [SerializeField] private GameObject cupTwoSpawner;
    
    [SerializeField] public DayCounter dayCounter;
  

    public void NextDay()
    {
        nextDayUI.SetActive(false);

        Time.timeScale = 1f;
        
        timer.ResetTimer();

        dayCounter.NextDay();

        Debug.Log("Day: " + dayCounter.dayCount);

        GameManager.Instance.ChangeState(GameState.Playing);
    }

    public void BuyChocolate()
    {
        if (chocolateBought) return;

        if (_moneyManager.Money >= 20)
        {
            _moneyManager.RemoveMoney(20);
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

        if (_moneyManager.Money >= 40)
        {
            _moneyManager.RemoveMoney(40);
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

        if (_moneyManager.Money >= 60)
        {
            _moneyManager.RemoveMoney(60);
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

        if (_moneyManager.Money >= 80)
        {
            _moneyManager.RemoveMoney(80);
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

        if (_moneyManager.Money >= 100)
        {
            _moneyManager.RemoveMoney(100);
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
    
    public void BuyCherry()
    {
        if (cherryBought) return;

        if (_moneyManager.Money >= 120)
        {
            _moneyManager.RemoveMoney(120);
            cherryBought = true;
            
            if (cherryBought)
            {
                cherrySpawner.SetActive(true);
            }

            cherryText.text = "BOUGHT";
            cherryButton.interactable = false;


            Debug.Log("Bought Cherry!");
        }

        else
        {
            Debug.Log("Not enough coins!");
        }

    }
    
    public void BuyWhippedCream()
    {
        if (whippedCreamBought) return;

        if (_moneyManager.Money >= 140)
        {
            _moneyManager.RemoveMoney(140);
            whippedCreamBought = true;
            
            if (whippedCreamBought)
            {
                whippedCreamSpawner.SetActive(true);
            }

            whippedCreamText.text = "BOUGHT";
            whippedCreamButton.interactable = false;


            Debug.Log("Bought Whipped Cream!");
        }

        else
        {
            Debug.Log("Not enough coins!");
        }

    }
    
    public void BuySprinkles()
    {
        if (sprinklesBought) return;

        if (_moneyManager.Money >= 160)
        {
            _moneyManager.RemoveMoney(160);
            sprinklesBought = true;
            
            if (sprinklesBought)
            {
                sprinklesSpawner.SetActive(true);
            }

            sprinklesText.text = "BOUGHT";
            sprinklesButton.interactable = false;


            Debug.Log("Bought Sprinkles!");
        }

        else
        {
            Debug.Log("Not enough coins!");
        }

    }
    
    public void BuyCupOne()
    {
        if (cupOneBought) return;

        if (_moneyManager.Money >= 100)
        {
            _moneyManager.RemoveMoney(100);
            cupOneBought = true;
            
            if (cupOneBought)
            {
                cupTwoSpawner.SetActive(true);
            }

            cupOneText.text = "BOUGHT";
            cupOneButton.interactable = false;


            Debug.Log("Bought Additional Cup Slot 1!");
        }

        else
        {
            Debug.Log("Not enough coins!");
        }

    }
    
        
    public void BuyCupTwo()
    {
        if (cupTwoBought) return;

        if (_moneyManager.Money >= 200)
        {
            _moneyManager.RemoveMoney(200);
            cupTwoBought = true;
            
            if (cupTwoBought)
            {
                cupTwoSpawner.SetActive(true);
            }

            cupTwoText.text = "BOUGHT";
            cupTwoButton.interactable = false;


            Debug.Log("Bought Additional Cup Slot 2!");
        }

        else
        {
            Debug.Log("Not enough coins!");
        }

    }



}

