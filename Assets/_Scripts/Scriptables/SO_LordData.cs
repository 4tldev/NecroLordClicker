using UnityEngine.Events;
using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Undead/Lord")]
public class SO_LordData : ScriptableObject
{
    public string minionName;
    public BigNumber baseCost = new BigNumber(50);
    public BigNumber currentCost;
    public double purchaseMultiplier = 2; //Doubles the amount needed to purchase subsequent lords
    public MINIONTYPE minionType;
    public List<Trait> availableTraits; // TODO decide if we want to implement to limit certain traits to certain Lord Types
}
