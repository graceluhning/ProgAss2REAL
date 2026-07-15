using UnityEngine;

public static class ToppingPrices
{
    public static int GetPrice(ToppingTypes topping)
    {
        switch (topping)
        {
            case ToppingTypes.Vanilla:
                return 2;

            case ToppingTypes.Chocolate:
                return 3;

            case ToppingTypes.Strawberry:
                return 3;
            
            case ToppingTypes.Mint:
                return 4;
            
            case ToppingTypes.Mango:
                return 5;
            
            case ToppingTypes.CookiesCream:
                return 5;

            case ToppingTypes.Cherry:
                return 3;

            case ToppingTypes.Sprinkles:
                return 4;
            
            case ToppingTypes.WhippedCream:
                return 5;

            default:
                return 0;
        }
    }
}