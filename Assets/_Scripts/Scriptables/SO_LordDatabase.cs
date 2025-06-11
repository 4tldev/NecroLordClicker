using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/Lord Database")]
public class SO_LordDatabase : ScriptableObject
{
    public List<SO_LordData> allLords;

    public SO_LordData GetLordByType(MINIONTYPE type)
    {
        return allLords.Find(l => l.minionType == type);
    }

    public SO_LordData GetLordByName(string name)
    {
        return allLords.Find(l => l.name == name);
    }

    public List<SO_LordData> GetAllForType(MINIONTYPE type)
    {
        return allLords.FindAll(l => l.minionType == type);
    }
}
