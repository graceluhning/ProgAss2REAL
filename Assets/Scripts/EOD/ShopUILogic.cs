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
    [SerializeField] private TMP_Text receiptText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text totalText;

    private int totalCost = 0;

    public void NextDay()
    {
        nextDayUI.SetActive(false);

        Time.timeScale = 1f;
        
        receiptText.text = "";
        priceText.text = "";
        totalText.text = "";
        
        totalCost = 0;

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

        chocolateSpawner.SetActive(true);

        chocolateText.text = "BOUGHT";
        chocolateButton.interactable = false;

        receiptText.text += "CHOCOLATE\n";
        priceText.text += "$20\n";

        totalCost += 20;
        totalText.text = "$" + totalCost;

        Debug.Log("Bought Chocolate!");
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

        strawSpawner.SetActive(true);

        strawText.text = "BOUGHT";
        strawberryButton.interactable = false;

        receiptText.text += "STRAWBERRY\n";
        priceText.text += "$40\n";

        totalCost += 40;
        totalText.text = "$" + totalCost;

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

        mintSpawner.SetActive(true);

        mintText.text = "BOUGHT";
        mintButton.interactable = false;

        receiptText.text += "MINT\n";
        priceText.text += "$60\n";

        totalCost += 60;
        totalText.text = "$" + totalCost;

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

        mangoSpawner.SetActive(true);

        mangoText.text = "BOUGHT";
        mangoButton.interactable = false;

        receiptText.text += "MANGO\n";
        priceText.text += "$80\n";

        totalCost += 80;
        totalText.text = "$" + totalCost;

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

        cookiesCreamSpawner.SetActive(true);

        cookiesCreamText.text = "BOUGHT";
        cookiesCreamButton.interactable = false;

        receiptText.text += "COOKIES\n";
        priceText.text += "$100\n";

        totalCost += 100;
        totalText.text = "$" + totalCost;

        Debug.Log("Bought Cookies and Cream!");
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

        whippedCreamSpawner.SetActive(true);

        whippedCreamText.text = "BOUGHT";
        whippedCreamButton.interactable = false;

        receiptText.text += "CREAM\n";
        priceText.text += "$140\n";

        totalCost += 140;
        totalText.text = "$" + totalCost;

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

        sprinklesSpawner.SetActive(true);

        sprinklesText.text = "BOUGHT";
        sprinklesButton.interactable = false;

        receiptText.text += "SPRINKLES\n";
        priceText.text += "$160\n";

        totalCost += 160;
        totalText.text = "$" + totalCost;

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

        cupTwoSpawner.SetActive(true);

        cupOneText.text = "BOUGHT";
        cupOneButton.interactable = false;

        receiptText.text += "CUP SLOT\n";
        priceText.text += "$100\n";

        totalCost += 100;
        totalText.text = "$" + totalCost;

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

        cupTwoSpawner.SetActive(true);

        cupTwoText.text = "BOUGHT";
        cupTwoButton.interactable = false;

        receiptText.text += "CUP SLOT\n";
        priceText.text += "$200\n";

        totalCost += 200;
        totalText.text = "$" + totalCost;

        Debug.Log("Bought Additional Cup Slot 2!");
    }
    else
    {
        Debug.Log("Not enough coins!");
    }
}
}