using System.Collections.Generic;
using UnityEngine;

public class LordManager : MonoBehaviour
{
    [SerializeField] private SO_LordDatabase lordDatabase;


    private List<LordListEntry> _lords = new();

    public List<LordListEntry> Lords => _lords;


    public void AddLord(Lord lord)
    {
        // Find the matching LordListEntry by LordData (blueprint)
        var entry = _lords.Find(e => e.data == lord.LordData);

        if (entry != null)
        {
            entry.lordTypeList.Add(lord);
        }
        else
        {
            // Create a new entry for this Lord type
            LordListEntry newEntry = new LordListEntry
            {
                data = lord.LordData
            };
            newEntry.lordTypeList.Add(lord);
            _lords.Add(newEntry);
        }
    }

    public SO_LordData GetLordDataByType(MINIONTYPE type)
    {
        return lordDatabase.GetLordByType(type);
    }

    public List<SO_LordData> GetAllLordData() => lordDatabase.allLords;

}
