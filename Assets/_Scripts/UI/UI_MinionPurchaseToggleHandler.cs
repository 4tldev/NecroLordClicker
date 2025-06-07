using System;
using UnityEngine;
using UnityEngine.UI;

public enum AMOUNT_TO_BUY 
{
    ONE, TEN, ONEHUNDRED, BUYMAX
}

public class UI_MinionPurchaseToggleHandler : MonoBehaviour
{
    public static UI_MinionPurchaseToggleHandler Instance { get; private set; }

    public AMOUNT_TO_BUY amountToBuy;
    public BigNumber purchaseAmount;
    public bool isBuyMax = false;

    [SerializeField] private Player player; // This feels bad

    [SerializeField] private Toggle toggle_1x;
    [SerializeField] private Toggle toggle_10x;
    [SerializeField] private Toggle toggle_100x;
    [SerializeField] private Toggle toggle_max;

    [SerializeField] private SO_VoidEventChannel onToggleChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // prevent duplicates
    }

    private void Start()
    {
        // Register listeners
        toggle_1x.onValueChanged.AddListener(OnToggle1xChanged);
        toggle_10x.onValueChanged.AddListener(OnToggle10xChanged);
        toggle_100x.onValueChanged.AddListener(OnToggle100xChanged);
        toggle_max.onValueChanged.AddListener(OnToggleMaxChanged);

        // Manually fire once for default
        OnToggle1xChanged(true);
    }

    private void OnDestroy()
    {
        toggle_1x.onValueChanged.RemoveListener(OnToggle1xChanged);
        toggle_10x.onValueChanged.RemoveListener(OnToggle10xChanged);
        toggle_100x.onValueChanged.RemoveListener(OnToggle100xChanged);
        toggle_max.onValueChanged.RemoveListener(OnToggleMaxChanged);
    }

    private void OnToggle1xChanged(bool isOn) { if (isOn) ApplyToggle(AMOUNT_TO_BUY.ONE, false); }
    private void OnToggle10xChanged(bool isOn) { if (isOn) ApplyToggle(AMOUNT_TO_BUY.TEN, false); }
    private void OnToggle100xChanged(bool isOn) { if (isOn) ApplyToggle(AMOUNT_TO_BUY.ONEHUNDRED, false); }
    private void OnToggleMaxChanged(bool isOn) { if (isOn) ApplyToggle(AMOUNT_TO_BUY.BUYMAX, true); }

    private void ApplyToggle(AMOUNT_TO_BUY amount, bool max)
    {
        amountToBuy = amount;
        isBuyMax = max;

        Debug.Log($"Toggle enum changed to {amountToBuy} and isBuyMax: {isBuyMax}");

        onToggleChanged?.Raise();
        UI_MinionPurchaseList.Instance.RefreshAllRows();
    }

    public BigNumber GetPurchaseAmount() 
    {
        switch (amountToBuy)
        {
            case AMOUNT_TO_BUY.ONE:
                purchaseAmount = new BigNumber(1);
                break;
            case AMOUNT_TO_BUY.TEN:
                purchaseAmount = new BigNumber(10);
                break;
            case AMOUNT_TO_BUY.ONEHUNDRED:
                purchaseAmount = new BigNumber(100);
                break;
            default:
                throw new Exception("Unexpected behavior in AMOUNT_TO_BUY enum switch");
        }

        return purchaseAmount;
    }

}
