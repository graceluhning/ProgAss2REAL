using UnityEngine;

public class ParfaitCup : MonoBehaviour
{
    [SerializeField] private GameObject cupPrefab;
    [SerializeField] private GameObject vanillaCupPrefab;
    [SerializeField] private GameObject strawberryCupPrefab;
    [SerializeField] private GameObject chocolateCupPrefab;
    [SerializeField] private GameObject mintCupPrefab;
    [SerializeField] private GameObject mangoCupPrefab;
    [SerializeField] private GameObject cookiesCreamCupPrefab;

    [SerializeField] private GameObject cherryPlacedPrefab;
    [SerializeField] private GameObject whippedCreamPlacedPrefab;
    [SerializeField] private GameObject sprinklesPlacedPrefab;

    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private Transform pos3;

    private bool slot1;
    private bool slot2;
    private bool slot3;

    public ToppingTypes slot1Type;
    public ToppingTypes slot2Type;
    public ToppingTypes slot3Type;

    public int totalPrice = 0;

    private DraggedTopping hoveringTopping;


    private void Update()
    {
        if (hoveringTopping == null)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            PlaceTopping(hoveringTopping);
            hoveringTopping = null;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("IceCream") || other.CompareTag("RealTopping"))
        {
            DraggedTopping topping = other.GetComponent<DraggedTopping>();

            if (topping != null)
            {
                hoveringTopping = topping;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        DraggedTopping topping = other.GetComponent<DraggedTopping>();

        if (topping != null && topping == hoveringTopping)
        {
            hoveringTopping = null;
        }
    }


    private void PlaceTopping(DraggedTopping topping)
    {
        ToppingTypes type = topping.toppingType;


        // ICE CREAM SCOOPS
        if (topping.CompareTag("IceCream"))
        {
            if (slot1 && slot2)
            {
                Debug.Log("Cup Full");
                return;
            }

            Transform targetSlot = null;

            if (!slot1)
            {
                targetSlot = pos1;
                slot1 = true;
                slot1Type = type;
            }
            else if (!slot2)
            {
                targetSlot = pos2;
                slot2 = true;
                slot2Type = type;
            }


            topping.SetPlaced();

            Destroy(topping.gameObject);

            SpawnCupVisual(type, targetSlot.position);

            AddTopping(type);
        }


        // TOPPINGS
        else if (topping.CompareTag("RealTopping"))
        {
            if (!slot1 || !slot2)
            {
                Debug.Log("Need ice cream first!");
                return;
            }

            if (slot3)
            {
                Debug.Log("Cup Full");
                return;
            }


            slot3 = true;
            slot3Type = type;


            topping.SetPlaced();

            Destroy(topping.gameObject);

            SpawnCupVisual(type, pos3.position);

            AddTopping(type);
        }
    }


    public void AddTopping(ToppingTypes type)
    {
        totalPrice += ToppingPrices.GetPrice(type);
        Debug.Log("Current Price: $" + totalPrice);
    }


    private void SpawnCupVisual(ToppingTypes type, Vector3 position)
    {
        GameObject prefab = GetCupPrefab(type);

        if (prefab != null)
        {
            Instantiate(prefab, position, Quaternion.identity, transform);
        }
    }


    private GameObject GetCupPrefab(ToppingTypes type)
    {
        return type switch
        {
            ToppingTypes.Vanilla => vanillaCupPrefab,
            ToppingTypes.Strawberry => strawberryCupPrefab,
            ToppingTypes.Chocolate => chocolateCupPrefab,
            ToppingTypes.Mint => mintCupPrefab,
            ToppingTypes.Mango => mangoCupPrefab,
            ToppingTypes.CookiesCream => cookiesCreamCupPrefab,

            ToppingTypes.Cup => cupPrefab,

            ToppingTypes.Cherry => cherryPlacedPrefab,
            ToppingTypes.WhippedCream => whippedCreamPlacedPrefab,
            ToppingTypes.Sprinkles => sprinklesPlacedPrefab,

            _ => null
        };
    }
}