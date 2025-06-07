using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Undead/Minion")]
public class SO_UndeadMinionData : ScriptableObject
{
    public string minionName;
    public BigNumber baseCost;
    public BigNumber currentCost;
    public BigNumber baseSoulsPerSecond;
    public BigNumber currentSoulsPerSecond;
    public double purchaseMultiplier = .15;
    public MINIONTYPE miniontype;
}
