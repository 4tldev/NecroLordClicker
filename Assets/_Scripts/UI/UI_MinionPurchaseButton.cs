using UnityEngine;
using UnityEngine.UI;

public class UI_MinionPurchaseButton : MonoBehaviour
{

    // TODO this is bad code we should just fire off an event and have a manager listen for the onPurchaseButtonClicked
    [SerializeField] private Player player;

    private Button btn;
    private UI_MinionPurchaseRow minionPurchaseRow;

    void Start()
    {
        btn = GetComponent<Button>();
        player = FindAnyObjectByType<Player>();
        minionPurchaseRow = GetComponentInParent<UI_MinionPurchaseRow>();
    }

    public void TryBuyMinions() 
    {
        player.MinionPurchaseManager.TryBuyMinions(minionPurchaseRow.minionListEntry, UI_MinionPurchaseToggleHandler.Instance.amountToBuy);
    }
}
