using System;
using UnityEngine;

public static class MinionPurchaseCalculator
{
    public static BigNumber GetTotalCost(BigNumber baseCost, double multiplier, BigNumber owned, BigNumber amountToBuy)
    {
        if (amountToBuy.ToDouble() <= 0)
            return new BigNumber(0);

        double r = 1.0 + multiplier;
        double startPower = owned.ToDouble();
        double n = amountToBuy.ToDouble();

        double costAtStart = baseCost.ToDouble() * Math.Pow(r, startPower);
        double totalCost = costAtStart * (Math.Pow(r, n) - 1) / (r - 1);

        return new BigNumber(totalCost);
    }


    public static BigNumber GetMaxAffordable(BigNumber baseCost, double multiplier, BigNumber owned, BigNumber availableSouls)
    {
        double r = 1.0 + multiplier;
        double C = baseCost.ToDouble() * Math.Pow(r, owned.ToDouble());
        double S = availableSouls.ToDouble();

        double n = Math.Floor(Math.Log(1 + ((S * (r - 1)) / C)) / Math.Log(r));

        return new BigNumber(Mathf.Max(0, (int)n));
    }
}
