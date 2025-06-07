using System.Collections.Generic;
using UnityEngine;

public class MinionManager : MonoBehaviour
{

    //[SerializeField] private SO_VoidEventChannel onMinionPurchased;

    [SerializeField] private List<MinionListEntry> _undeadMinions;

    [SerializeField] public SO_VoidEventChannel onMinionAdded;
    public List<MinionListEntry> UndeadMinions => _undeadMinions;

    

    public void AddMinions(SO_UndeadMinionData minionToAdd, BigNumber amountToAdd)
    {
        var existing = _undeadMinions.Find(entry => entry.data == minionToAdd);

        if (existing != null)
        {
            existing.amountOwned += amountToAdd;
            Debug.Log($"Adding {amountToAdd} minions to {minionToAdd.name}");
        }
        else
        {
            _undeadMinions.Add(new MinionListEntry(minionToAdd, amountToAdd));
        }

        onMinionAdded?.Raise();
    }
}
