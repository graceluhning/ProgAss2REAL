using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUILogic : MonoBehaviour
{
    [SerializeField] private MoneyManager _moneyManager;
    
    [SerializeField] GameObject marketUI;

    [SerializeField] private Button strawberryButton;
    [SerializeField] TMP_Text strawText;
    public bool strawBought;
    
    [SerializeField] private Button chocolateButton;
    [SerializeField] TMP_Text chocolateText;
    public bool chocolateBought;
    
    [SerializeField] private Button mintButton;
    [SerializeField] TMP_Text mintText;
    public bool mintBought;
    
    public void ExitShop()
    {
        marketUI.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void BuyChocolate()
    {
        if (chocolateBought) return;

        if (_moneyManager.Money >= 10)
        {
            _moneyManager.RemoveMoney(10);
            chocolateBought = true;
            
            
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

            mintText.text = "BOUGHT";
            mintButton.interactable = false;
            

            Debug.Log("Bought Mint!");
        }
        
        else
        {
            Debug.Log("Not enough coins!");
        }

    }
    
    
}

