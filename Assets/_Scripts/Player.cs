using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : PersistentSingleton<Player>
{
    [SerializeField] private BigNumber _souls = new BigNumber(0);
    [SerializeField] public BigNumber baseSoulsPerClick;
    [SerializeField] public BigNumber baseSoulsPerSecond;
    [SerializeField] public BigNumber currentSoulsPerClick = new BigNumber(1);
    [SerializeField] public BigNumber currentSoulsPerSecond = new BigNumber(0);
    [SerializeField] private Transform lordContainer;
    private MinionManager _minionManager;
    private LordManager _lordManager;
    private MinionPurchaseManager _minionPurchaseManager;
    private LordPurchaseManager _lordPurchaseManager;
    private SoulHandler _soulHandler;



    // Read-only access for other systems
    public BigNumber Souls => _souls;
    public MinionManager MinionManager => _minionManager;
    public MinionPurchaseManager MinionPurchaseManager => _minionPurchaseManager;
    public LordManager LordManager => _lordManager;
    public LordPurchaseManager LordPurchaseManager => _lordPurchaseManager;
    public SoulHandler SoulHandler => _soulHandler;
    public Transform LordContainer => lordContainer;


    protected override void Awake()
    {
        base.Awake();

        _minionManager = GetComponent<MinionManager>();
        _minionPurchaseManager = GetComponent<MinionPurchaseManager>();
        _soulHandler = GetComponent<SoulHandler>();
        _lordManager = GetComponent<LordManager>();
        _lordPurchaseManager = GetComponent<LordPurchaseManager>();
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
