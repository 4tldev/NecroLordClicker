using System.Collections.Generic;
using UnityEngine;

public class UI_MinionPurchaseList : MonoBehaviour
{
    [SerializeField] private UI_MinionPurchaseRow rowPrefab;
    [SerializeField] private Transform rowContainer;
    [SerializeField] private Player player;
    private readonly List<UI_MinionPurchaseRow> _rows = new();


    public static UI_MinionPurchaseList Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not found in the scene.");
            return;
        }

        GenerateRows(player.MinionManager.UndeadMinions);
    }

    private void GenerateRows(List<MinionListEntry> minions)
    {
        // Clear existing rows from scene
        foreach (Transform child in rowContainer)
        {
            Destroy(child.gameObject);
        }

        _rows.Clear(); // ❗ Clear the cached list

        // Create new rows using updated data
        foreach (var minionEntry in minions)
        {
            var row = Instantiate(rowPrefab, rowContainer);
            row.Setup(minionEntry, player);
            _rows.Add(row); // ✅ Cache the row so we can refresh it later
        }

        RefreshAllRows();
    }


    public void RefreshAllRows()
    {
        foreach (var row in _rows)
        {
            row.Refresh(); // calls Setup(_entry, _player)
            Debug.Log("Refreshing all rows. Rows count: " + _rows.Count);

        }
    }

}
