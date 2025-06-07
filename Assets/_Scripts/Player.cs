using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BigNumber _souls = new BigNumber(0);
    [SerializeField] public BigNumber baseSoulsPerClick;
    [SerializeField] public BigNumber baseSoulsPerSecond;
    [SerializeField] public BigNumber currentSoulsPerClick = new BigNumber(1);
    [SerializeField] public BigNumber currentSoulsPerSecond = new BigNumber(0);
    private MinionManager _minionManager;
    private MinionPurchaseManager _minionPurchaseManager;
    private SoulHandler _soulHandler;



    // Read-only access for other systems
    public BigNumber Souls => _souls;

    public MinionManager MinionManager => _minionManager;
    public MinionPurchaseManager MinionPurchaseManager => _minionPurchaseManager;
    public SoulHandler SoulHandler => _soulHandler;


    private void Awake()
    {
        _minionManager = gameObject.GetComponent<MinionManager>();
        _minionPurchaseManager = gameObject.GetComponent<MinionPurchaseManager>();
        _soulHandler = gameObject.GetComponent<SoulHandler>();
    }

    // Only allow trusted systems to modify
    public void AddSouls(BigNumber amount)
    {
        _souls += amount;
    }

    public void RemoveSouls(BigNumber amount)
    {
        if (_souls < amount)
            _souls = new BigNumber(0);
        else
            _souls -= amount;
    }


    
}
