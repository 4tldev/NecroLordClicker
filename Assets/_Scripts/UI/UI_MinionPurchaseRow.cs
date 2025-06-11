using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class UI_MinionPurchaseRow : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI minionNameText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private UI_MinionPurchaseToggleHandler minionPurchaseToggleHandler;


    private SO_UndeadMinionData minionData;
    private BigNumber currentCost;

    //cache data for refresh
    private MinionListEntry _entry;
    private Player _player;


    public MinionListEntry minionListEntry;



    public void Setup(MinionListEntry entry, Player player)
    {
        _entry = entry;
        _player = player;

        minionListEntry = entry;

        minionNameText.text = $"{entry.data.minionName} owned: {BigNumberFormatter.Format(entry.amountOwned.ToDouble())}";
    }




    public void Refresh()
    {
        if (UI_MinionPurchaseToggleHandler.Instance == null)
        {
            Debug.LogWarning("Toggle handler is not initialized.");
            return;
        }

        if (UI_MinionPurchaseToggleHandler.Instance.isBuyMax)
        {
            costText.text = "MAX";
            minionNameText.text = $"{_entry.data.minionName} owned: {BigNumberFormatter.Format(_entry.amountOwned.ToDouble())}";

            currentCost = MinionPurchaseCalculator.GetMaxAffordable(
                _entry.data.baseCost,
                _entry.data.purchaseMultiplier,
                _entry.amountOwned,
                _player.Souls
                );
        }
        else
        {
            BigNumber amount = new BigNumber(0);
            switch (UI_MinionPurchaseToggleHandler.Instance.amountToBuy) 
            {
                case AMOUNT_TO_BUY.ONE:
                    amount = new BigNumber(1);
                    break;
                case AMOUNT_TO_BUY.TEN:
                    amount = new BigNumber(10);
                    break;
                case AMOUNT_TO_BUY.ONEHUNDRED:
                    amount = new BigNumber(100);
                    break;
                default:
                    throw new Exception("Unexpected behavior in AMOUNT_TO_BUY enum switch");
            }

            currentCost = MinionPurchaseCalculator.GetTotalCost(
                _entry.data.baseCost,
                _entry.data.purchaseMultiplier,
                _entry.amountOwned,
                amount
            );

            costText.text = BigNumberFormatter.Format(currentCost.ToDouble());
            minionNameText.text = $"{_entry.data.minionName} | owned: {BigNumberFormatter.Format(_entry.amountOwned.ToDouble())}";
        }
    }



}
