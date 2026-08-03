using UnityEngine;

public static class ToppingPrices
{
    public static int GetPrice(ToppingTypes topping)
    {
        switch (topping)
        {
            case ToppingTypes.Cup:
                return 0;
            
            case ToppingTypes.Vanilla:
                return 1;

            case ToppingTypes.Chocolate:
                return 2;

            case ToppingTypes.Strawberry:
                return 3;
            
            case ToppingTypes.Mint:
                return 4;
            
            case ToppingTypes.Mango:
                return 5;
            
            case ToppingTypes.CookiesCream:
                return 6;

            case ToppingTypes.Cherry:
                return 1;

            case ToppingTypes.Sprinkles:
                return 3;
            
            case ToppingTypes.WhippedCream:
                return 5;

            default:
                return 0;
        }
    }
}