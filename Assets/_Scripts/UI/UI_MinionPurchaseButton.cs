using UnityEngine;
using UnityEngine.UI;

public class UI_MinionPurchaseButton : MonoBehaviour
{
    // TODO this is bad code we should just fire off an event and have a manager listen for the onPurchaseButtonClicked
    [SerializeField] private Player _player;

    private Button btn;
    private UI_MinionPurchaseRow minionPurchaseRow;


    void Start()
    {
        btn = GetComponent<Button>();
        _player = FindAnyObjectByType<Player>();
        minionPurchaseRow = GetComponentInParent<UI_MinionPurchaseRow>();
    }

    public void BuyMinions()
    {
        if (UI_MinionPurchaseToggleHandler.Instance.amountToBuy == AMOUNT_TO_BUY.BUYMAX)
        {
            BigNumber maxAffordable = MinionPurchaseCalculator.GetMaxAffordable(minionPurchaseRow.minionListEntry.data.baseCost,
                 minionPurchaseRow.minionListEntry.data.purchaseMultiplier, minionPurchaseRow.minionListEntry.amountOwned, _player.Souls);

            _player.MinionPurchaseManager.TryBuyMax(minionPurchaseRow.minionListEntry, maxAffordable);
        }

        else 
        {
            _player.MinionPurchaseManager.TryBuyMinions(minionPurchaseRow.minionListEntry, UI_MinionPurchaseToggleHandler.Instance.GetPurchaseAmount());
        }
    }

}
