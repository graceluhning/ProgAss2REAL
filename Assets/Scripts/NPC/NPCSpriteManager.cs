using UnityEngine;

public class OrderDisplay : MonoBehaviour
{
    [SerializeField] private Transform scoopSlot1;
    [SerializeField] private Transform scoopSlot2;
    [SerializeField] private Transform toppingSlot;

    [SerializeField] private GameObject vanillaSprite;
    [SerializeField] private GameObject chocolateSprite;
    [SerializeField] private GameObject strawberrySprite;
    [SerializeField] private GameObject mintSprite;
    [SerializeField] private GameObject mangoSprite;
    [SerializeField] private GameObject cookiesCreamSprite;

    [SerializeField] private GameObject cherrySprite;
    [SerializeField] private GameObject whippedCreamSprite;
    [SerializeField] private GameObject sprinklesSprite;


    public void DisplayOrder(
        ToppingTypes iceCream1,
        ToppingTypes iceCream2,
        ToppingTypes topping)
    {
        SpawnImage(GetPrefab(iceCream1), scoopSlot1);
        SpawnImage(GetPrefab(iceCream2), scoopSlot2);

        if (topping != ToppingTypes.Cup)
        {
            SpawnImage(GetPrefab(topping), toppingSlot);
        }
    }


    private void SpawnImage(GameObject prefab, Transform slot)
    {
        if (prefab == null)
            return;

        Instantiate(prefab, slot.position, Quaternion.identity, slot);
    }


    private GameObject GetPrefab(ToppingTypes type)
    {
        return type switch
        {
            ToppingTypes.Vanilla => vanillaSprite,
            ToppingTypes.Chocolate => chocolateSprite,
            ToppingTypes.Strawberry => strawberrySprite,
            ToppingTypes.Mint => mintSprite,
            ToppingTypes.Mango => mangoSprite,
            ToppingTypes.CookiesCream => cookiesCreamSprite,

            ToppingTypes.Cherry => cherrySprite,
            ToppingTypes.WhippedCream => whippedCreamSprite,
            ToppingTypes.Sprinkles => sprinklesSprite,

            _ => null
        };
    }
}