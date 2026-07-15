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

    public int totalPrice = 2;

    public void AddTopping(ToppingTypes type)
    {
        totalPrice += ToppingPrices.GetPrice(type);
        Debug.Log("Current Price: $" + totalPrice);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("IceCream"))
        {
            DraggedTopping topping = other.GetComponent<DraggedTopping>();
            if (topping == null) return;

            if (slot1 && slot2)
            {
                Debug.Log("Cup Full");
                return;
            }

            ToppingTypes type = topping.toppingType;

            Transform targetSlot = null;

            if (!slot1)
            {
                targetSlot = pos1;
                slot1 = true;
            }
            else if (!slot2)
            {
                targetSlot = pos2;
                slot2 = true;
            }

            Destroy(other.gameObject);

            SpawnCupVisual(type, targetSlot.position);

           
            AddTopping(type);
        }
        else if (other.CompareTag("RealTopping"))
        {
            DraggedTopping topping = other.GetComponent<DraggedTopping>();
            if (topping == null) return;

            if (!slot1 || !slot2)
            {
                Debug.Log("Can't place topping without ice cream!");
                return;
            }

            if (slot3)
            {
                Debug.Log("Cup Full");
                return;
            }

            ToppingTypes type = topping.toppingType;

            slot3 = true;

            Destroy(other.gameObject);

            SpawnCupVisual(type, pos3.position);
            
            AddTopping(type);
        }
    }

    private void SpawnCupVisual(ToppingTypes type, Vector3 position)
    {
        GameObject prefab = GetCupPrefab(type);

        Instantiate(prefab, position, Quaternion.identity, transform);
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