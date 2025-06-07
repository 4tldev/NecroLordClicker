using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionPurchaseManager : MonoBehaviour
{

    // class manages all minion purchasing logic

    private Player _player;
    private BigNumber _amountToBuy;
    private UI_MinionPurchaseList _minionPurchaseList;
    [SerializeField] public SO_VoidEventChannel onMinionPurchased;

    void Awake()
    {
        _player = GetComponent<Player>();
    }

    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BigNumber GetCurrentMinionCost(BigNumber baseCost, double multiplier, BigNumber amountOwned)
    {
        double exponent = amountOwned.ToDouble();
        double multiplierBase = 1.0 + multiplier;
        return baseCost * System.Math.Pow(multiplierBase, exponent);
    }


    public void SetMinionPrices(List<MinionListEntry> md)
    {
        foreach (var minion in md)
        {
            minion.data.currentCost = GetCurrentMinionCost(minion.data.baseCost,
                minion.data.purchaseMultiplier,
                minion.amountOwned);
        }
    }


    public void TryBuyMinions(MinionListEntry min, BigNumber amountToBuy)
    {
        
        var cost = MinionPurchaseCalculator.GetTotalCost(
            min.data.baseCost,
            min.data.purchaseMultiplier,
            min.amountOwned,
            amountToBuy
        );

        if (_player.Souls >= cost)
        {
            _player.RemoveSouls(cost); // You already have this method
            _player.MinionManager.AddMinions(min.data, amountToBuy);
            onMinionPurchased?.Raise(); //TODO remove as I dont believe we are using this anymore... verify first
            _player.currentSoulsPerSecond += (min.data.baseSoulsPerSecond * amountToBuy); //TODO put this in a function
        }
        else
        {
            Debug.Log("Not enough souls!");
        }
    }

    public void TryBuyMax(MinionListEntry min, BigNumber amountToBuy)
    {
            BigNumber maxBuyable = MinionPurchaseCalculator.GetMaxAffordable(
            min.data.baseCost,
            min.data.purchaseMultiplier,
            min.amountOwned,
            _player.Souls
        );

        TryBuyMinions(min, amountToBuy);
    }

}
