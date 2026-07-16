using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IceCreamOrderGenerator : MonoBehaviour
{
    [SerializeField] private ShopUILogic shopUI;

    public ToppingTypes orderedIceCream1;
    public ToppingTypes orderedIceCream2;
    public ToppingTypes orderedTopping;
    [SerializeField] private TMP_Text orderText;
    

    private void Awake()
    {
        shopUI = FindFirstObjectByType<ShopUILogic>(FindObjectsInactive.Include);

        if (shopUI == null)
        {
            Debug.LogError("ShopUILogic not found on NextDayCanvas!");
        }
        
        GenerateOrder();
    }


    public void GenerateOrder()
    {
        List<ToppingTypes> iceCreamChoices = new List<ToppingTypes>();
        List<ToppingTypes> toppingChoices = new List<ToppingTypes>();
        
        iceCreamChoices.Add(ToppingTypes.Vanilla);

        if (shopUI.chocolateBought)
            iceCreamChoices.Add(ToppingTypes.Chocolate);

        if (shopUI.strawBought)
            iceCreamChoices.Add(ToppingTypes.Strawberry);

        if (shopUI.mintBought)
            iceCreamChoices.Add(ToppingTypes.Mint);

        if (shopUI.mangoBought)
            iceCreamChoices.Add(ToppingTypes.Mango);

        if (shopUI.cookiesCreamBought)
            iceCreamChoices.Add(ToppingTypes.CookiesCream);

        if (shopUI.cherryBought)
            toppingChoices.Add(ToppingTypes.Cherry);

        if (shopUI.whippedCreamBought)
            toppingChoices.Add(ToppingTypes.WhippedCream);

        if (shopUI.sprinklesBought)
            toppingChoices.Add(ToppingTypes.Sprinkles);
        
        orderedIceCream1 = iceCreamChoices[
            Random.Range(0, iceCreamChoices.Count)
        ];

        orderedIceCream2 = iceCreamChoices[
            Random.Range(0, iceCreamChoices.Count)
        ];
        
        if (toppingChoices.Count > 0)
        {
            orderedTopping = toppingChoices[
                Random.Range(0, toppingChoices.Count)
            ];
        }
        else
        {
            orderedTopping = ToppingTypes.Cup;
        }
        
        DisplayOrderText();
        
    }
    
    private void DisplayOrderText()
    {
        if (orderText != null)
        {
            orderText.text =
                $"{orderedIceCream1} + {orderedIceCream2} with {orderedTopping}";
        }
    }
    
    public bool CheckOrder(ToppingTypes scoop1, ToppingTypes scoop2, ToppingTypes topping)
    {
        bool correctScoops =
            (scoop1 == orderedIceCream1 && scoop2 == orderedIceCream2) ||
            (scoop1 == orderedIceCream2 && scoop2 == orderedIceCream1);

        bool correctTopping = topping == orderedTopping;

        if (correctScoops && correctTopping)
        {
            Debug.Log("Correct Order!");
            return true;
        }

        Debug.Log("Wrong Order!");
        return false;
    }
}