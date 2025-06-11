using System.Collections.Generic;
using UnityEngine;

public class MinionManager : MonoBehaviour
{

    //[SerializeField] private SO_VoidEventChannel onMinionPurchased;

    [SerializeField] private List<MinionListEntry> _undeadMinions; //TODO dynamically populate the list instead of serializing

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

    public void RemoveMinions(SO_UndeadMinionData minionToRemove, BigNumber amountToRemove)
    {
        var entry = _undeadMinions.Find(e => e.data == minionToRemove);

        if (entry != null)
        {
            if (amountToRemove <= entry.amountOwned)
            {
                entry.amountOwned -= amountToRemove;
                Debug.Log($"Removed {amountToRemove} {entry.data.name}(s). New total: {entry.amountOwned}");
            }
            else
            {
                Debug.LogWarning($"Not enough {entry.data.name}s to remove. Owned: {entry.amountOwned}, Tried to remove: {amountToRemove}");
            }
        }
        else
        {
            Debug.LogError($"Minion type {minionToRemove.name} not found in the list!");
        }
    }

}
