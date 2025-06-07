using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        minionNameText.text = entry.data.minionName;
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
            costText.text = "MAX"; //TODO calculate current max to buy
        }
        else
        {
            currentCost = MinionPurchaseCalculator.GetTotalCost(
                _entry.data.baseCost,
                _entry.data.purchaseMultiplier,
                _entry.amountOwned,
                UI_MinionPurchaseToggleHandler.Instance.amountToBuy
            );

            costText.text = BigNumberFormatter.Format(currentCost.ToDouble());
        }
    }



}
