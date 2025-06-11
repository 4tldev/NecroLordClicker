using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_LordTypeDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown lordTypeDropdown;
    [SerializeField] private Player _player;
    public SO_VoidEventChannel onLordDropdownValueChanged;

    public static UI_LordTypeDropdown Instance { get; private set; }

    public MINIONTYPE SelectedMinionType { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        if (lordTypeDropdown == null)
        {
            Debug.LogError("Lord Type Dropdown is not assigned!");
            return;
        }

        PopulateDropdown();
    }

    void Update()
    {
        //TODO create an event to check if the player added new minion type and then refresh
        // currently the list is serialized but it should change in the future
    }

    //listeners
    void OnEnable()
    {
        lordTypeDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    void OnDisable()
    {
        lordTypeDropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
    }

    private void PopulateDropdown()
    {
        List<string> optionsList = new List<string>();

        foreach (var minion in _player.MinionManager.UndeadMinions)
        {
            optionsList.Add(minion.data.minionName);
            Debug.Log($"Added {minion.data.minionName} to the Lord Drop Down Menu!");
        }

        lordTypeDropdown.ClearOptions();
        lordTypeDropdown.AddOptions(optionsList);

        // Set default selected type (optional)
        if (_player.MinionManager.UndeadMinions.Count > 0)
        {
            SelectedMinionType = _player.MinionManager.UndeadMinions[0].data.minionType;
        }
    }

    private void OnDropdownValueChanged(int index)
    {
        string selectedName = lordTypeDropdown.options[index].text;

        var selectedMinion = _player.MinionManager.UndeadMinions
            .Find(entry => entry.data.minionName == selectedName);

        if (selectedMinion != null)
        {
            SelectedMinionType = selectedMinion.data.minionType;
            Debug.Log($"Selected: {selectedMinion.data.minionName} ({SelectedMinionType})");
        }
        else
        {
            Debug.LogWarning($"Could not find matching minion for: {selectedName}");
        }

        onLordDropdownValueChanged?.Raise();
    }


}
