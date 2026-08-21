using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class ShopItem
{
    public string itemName;

    public string receiptLabel;

    public int price;

    public Button button;
    public TMP_Text buttonText;

    public GameObject spawner;

    [HideInInspector] public bool bought;
}

public class ShopUILogic : MonoBehaviour
{
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private DayTimer timer;

    [SerializeField] private GameObject nextDayUI;

    [SerializeField] public DayCounter dayCounter;
    [SerializeField] private TMP_Text receiptText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text totalText;
    [SerializeField] private TMP_Text rentText;

    [SerializeField] private List<ShopItem> shopItems = new List<ShopItem>();

    private int totalCost = 0;


    private void Awake()
    {
        foreach (var item in shopItems)
        {
            var capturedItem = item;

            if (capturedItem.button != null)
                capturedItem.button.onClick.AddListener(() => BuyItem(capturedItem));
        }
    }


    private void Start()
    {
        UpdateShopTotal();
    }


    private void UpdateShopTotal()
    {
     
        int rent = dayCounter.dayCount * 5;

   
        rentText.text = "$" + rent;

        
        int grandTotal = totalCost + rent;

  
        totalText.text = "$" + grandTotal;
    }


    public void NextDay()
    {
        nextDayUI.SetActive(false);

        Time.timeScale = 1f;

        receiptText.text = "";
        priceText.text = "";
        totalText.text = "";

        dayCounter.NextDay();


        totalCost = 0;

    
        UpdateShopTotal();

        timer.ResetTimer();

        Debug.Log("Day: " + dayCounter.dayCount);
        Debug.Log("Rent: $" + (dayCounter.dayCount * 5));

        GameManager.Instance.ChangeState(GameState.Playing);
    }


    public void BuyItem(ShopItem item)
    {
        if (item == null || item.bought) return;

        if (_moneyManager.Money >= item.price)
        {
            _moneyManager.RemoveMoney(item.price);
            item.bought = true;

            if (item.spawner != null)
                item.spawner.SetActive(true);

            if (item.buttonText != null)
                item.buttonText.text = "";

            if (item.button != null)
                item.button.interactable = false;

           
            receiptText.text += item.receiptLabel + "\n";
            priceText.text += "$" + item.price + "\n";

          
            totalCost += item.price;

           
            UpdateShopTotal();

        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }


    public void BuyItemByName(string itemName)
    {
        BuyItem(shopItems.FirstOrDefault(i => i.itemName == itemName));
    }


    public bool IsBought(string itemName)
    {
        return shopItems.FirstOrDefault(i => i.itemName == itemName)?.bought ?? false;
    }
}