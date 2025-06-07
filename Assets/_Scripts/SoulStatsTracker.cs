using TMPro;
using UnityEngine;

public class SoulStatsTracker : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI currentSoulsText;
    [SerializeField] private TextMeshProUGUI currentSPSText;


    private void Start()
    {
        //RefreshDisplay();
    }

    private void Update()
    {
        RefreshDisplay();

    }

    public void RefreshDisplay()
    {
        if (player == null || currentSoulsText == null || currentSPSText == null) return;

        currentSoulsText.text = "Current Souls: " + BigNumberFormatter.Format(player.Souls.ToDouble());
        currentSPSText.text = "Current SPS: " + BigNumberFormatter.Format(player.currentSoulsPerSecond.ToDouble());
    }
}
