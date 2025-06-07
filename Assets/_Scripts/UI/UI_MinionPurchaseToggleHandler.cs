using UnityEngine;
using UnityEngine.UI;

public class UI_MinionPurchaseToggleHandler : MonoBehaviour
{
    public static UI_MinionPurchaseToggleHandler Instance { get; private set; }

    public BigNumber amountToBuy = new BigNumber(1);
    public bool isBuyMax = false;

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

    private void OnToggle1xChanged(bool isOn) { if (isOn) ApplyToggle(1, false); }
    private void OnToggle10xChanged(bool isOn) { if (isOn) ApplyToggle(10, false); }
    private void OnToggle100xChanged(bool isOn) { if (isOn) ApplyToggle(100, false); }
    private void OnToggleMaxChanged(bool isOn) { if (isOn) ApplyToggle(0, true); }

    private void ApplyToggle(int amount, bool max)
    {
        amountToBuy = new BigNumber(amount);
        isBuyMax = max;

        onToggleChanged?.Raise();
        UI_MinionPurchaseList.Instance.RefreshAllRows();
    }


    public void SetToggle(Toggle selectedToggle)
    {
        // Reset all toggles
        toggle_1x.isOn = false;
        toggle_10x.isOn = false;
        toggle_100x.isOn = false;
        toggle_max.isOn = false;

        // Enable selected
        selectedToggle.isOn = true;

        // Update logic
        if (selectedToggle == toggle_1x)
        {
            amountToBuy = new BigNumber(1);
            isBuyMax = false;
        }
        else if (selectedToggle == toggle_10x)
        {
            amountToBuy = new BigNumber(10);
            isBuyMax = false;
        }
        else if (selectedToggle == toggle_100x)
        {
            amountToBuy = new BigNumber(100);
            isBuyMax = false;
        }
        else if (selectedToggle == toggle_max)
        {
            amountToBuy = new BigNumber(0); // TODO: real max logic
            isBuyMax = true;
        }

        // 🧠 Fire event and refresh display
        onToggleChanged?.Raise();
        UI_MinionPurchaseList.Instance.RefreshAllRows(); // ✅ Keep this
    }
}
