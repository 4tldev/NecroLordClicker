using UnityEngine;

[System.Serializable]
public class Trait
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    // private bool _isActive = false;
    [SerializeField] private UPGRADETYPE _upgradeType;
    [SerializeField] private float _minMagnitude;
    [SerializeField] private float _maxMagnitude;
    [SerializeField] private float _finalMagnitude;

    public string Name => _name;
    public string Description => _description;
    public UPGRADETYPE UpgradeType => _upgradeType;
    public float MinMagnitude => _minMagnitude;
    public float MaxMagnitude => _maxMagnitude;

    public float FinalMagnitude => _finalMagnitude;

    public Trait(string name, string description, UPGRADETYPE type, float minMagnitude, float maxMagnitude)
    {
        this._name = name;
        this._description = description;
        this._upgradeType = type;
        this._minMagnitude = minMagnitude;
        this._maxMagnitude = maxMagnitude;
        this._finalMagnitude = Random.Range((float)minMagnitude, (float)maxMagnitude);
    }
}
