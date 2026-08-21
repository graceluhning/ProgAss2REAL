using System.Collections.Generic;
using UnityEngine;

public class IceCreamOrderGenerator : MonoBehaviour
{
    [SerializeField] private ShopUILogic shopUI;

    public ToppingTypes orderedIceCream1;
    public ToppingTypes orderedIceCream2;
    public ToppingTypes orderedTopping;

    [System.Serializable]
    public class OrderPrefab
    {
        public ToppingTypes type;
        public GameObject prefab;
    } 
    [SerializeField] private List<OrderPrefab> orderPrefabs;
    
    [SerializeField] private Transform iceCream1Position;
    [SerializeField] private Transform iceCream2Position;
    [SerializeField] private Transform toppingPosition;

    private GameObject currentIceCream1;
    private GameObject currentIceCream2;
    private GameObject currentTopping;


    private void Awake()
    {
        shopUI = FindFirstObjectByType<ShopUILogic>(FindObjectsInactive.Include);

        GenerateOrder();
    }


    public void GenerateOrder()
    {
        List<ToppingTypes> iceCreamChoices = new List<ToppingTypes>();
        List<ToppingTypes> toppingChoices = new List<ToppingTypes>();

        iceCreamChoices.Add(ToppingTypes.Vanilla);
        toppingChoices.Add(ToppingTypes.Cherry);

        // These item names must match the "itemName" keys you set on each
        // ShopItem entry in ShopUILogic's inspector list.
        if (shopUI.IsBought("Chocolate"))
            iceCreamChoices.Add(ToppingTypes.Chocolate);

        if (shopUI.IsBought("Strawberry"))
            iceCreamChoices.Add(ToppingTypes.Strawberry);

        if (shopUI.IsBought("Mint"))
            iceCreamChoices.Add(ToppingTypes.Mint);

        if (shopUI.IsBought("Mango"))
            iceCreamChoices.Add(ToppingTypes.Mango);

        if (shopUI.IsBought("CookiesCream"))
            iceCreamChoices.Add(ToppingTypes.CookiesCream);

        if (shopUI.IsBought("WhippedCream"))
            toppingChoices.Add(ToppingTypes.WhippedCream);

        if (shopUI.IsBought("Sprinkles"))
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

        DisplayOrderPrefabs();
    }


    private void DisplayOrderPrefabs()
    {
        if (currentIceCream1 != null)
            Destroy(currentIceCream1);

        if (currentIceCream2 != null)
            Destroy(currentIceCream2);

        if (currentTopping != null)
            Destroy(currentTopping);
        
        currentIceCream1 = SpawnPrefab(
            orderedIceCream1,
            iceCream1Position
        );

        currentIceCream2 = SpawnPrefab(
            orderedIceCream2,
            iceCream2Position
        );

        currentTopping = SpawnPrefab(
            orderedTopping,
            toppingPosition
        );
    }


    private GameObject SpawnPrefab(ToppingTypes type, Transform position)
    {
        foreach (OrderPrefab orderPrefab in orderPrefabs)
        {
            if (orderPrefab.type == type)
            {
                return Instantiate(
                    orderPrefab.prefab,
                    position.position,
                    Quaternion.identity,
                    position
                );
            }
        }
        
        return null;
    }


    public bool CheckOrder(
        ToppingTypes scoop1,
        ToppingTypes scoop2,
        ToppingTypes topping)
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