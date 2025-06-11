using System.Collections.Generic;
using UnityEngine;

public class Lord : MonoBehaviour
{
    [SerializeField] private string _lordName;
    [SerializeField] private SO_LordData _lordData;
    [SerializeField] private List<Trait> _traits = new List<Trait>();
    [SerializeField] private int maxTraits = 3;

    public string LordName => _lordName;
    public SO_LordData LordData => _lordData;
    public List<Trait> Traits => _traits;


    public void Init(SO_LordData data)
    {
        _lordData = data;
        _lordName = RandomNameGenerator.GenerateName();

        int r = Random.Range(1, maxTraits + 1); // makes sure we include maxtraits since Random.Range() is inclusive, exclusive
        for (int i = 0; i < r; i++)
        {
            var trait = TraitsDB.GetTrait();
            _traits.Add(trait);
            Debug.Log($" - Assigned Trait: {trait.Name}");
        }
    }
}
