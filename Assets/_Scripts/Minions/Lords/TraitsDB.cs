using System.Collections.Generic;
using UnityEngine;

public static class TraitsDB
{
    private static readonly List<Trait> _traitDB;

    static TraitsDB()
    {
        _traitDB = new List<Trait>
        {
            new Trait("Will of the Grave", "Grants a % increase modifier to souls per second", UPGRADETYPE.SOULS_PER_SECOND, 0.10f, 0.20f),
            new Trait("Soulbind Sigil", "Grants a # increase to souls per click", UPGRADETYPE.SOULS_PER_CLICK, 2f, 5f),
            new Trait("Unresting Flame", "Purchase cost reduction", UPGRADETYPE.PURCHASE_COST_REDUCTION, 0.10f, 0.20f)
        };
    }

    public static Trait GetTrait()
    {
        if (_traitDB.Count == 0)
        {
            Debug.LogError("TraitDB is empty!");
            return null;
        }


        // Logic below has to happen because magnitude is already decided inside of our static list so we need to make a new trait in order to get a new magnitude
        // otherwise all magnitudes will always be the same.

        int r = Random.Range(0, _traitDB.Count);
        Trait template = _traitDB[r];

        // Return a new object with the same core info, but a fresh magnitude
        return new Trait(template.Name, template.Description, template.UpgradeType, template.MinMagnitude, template.MaxMagnitude);
    }

}
