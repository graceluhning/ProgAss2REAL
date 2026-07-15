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

            case ToppingTypes.Cherry:
                return 1;

            case ToppingTypes.Sprinkles:
                return 1;

            default:
                return 0;
        }
    }
}