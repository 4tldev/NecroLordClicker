using UnityEngine;

public class UI_BuyLordButton : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void BuyLord()
    {
        MINIONTYPE selectedType = UI_LordTypeDropdown.Instance.SelectedMinionType;

        var lordData = _player.LordManager.GetLordDataByType(selectedType);
        var minionData = _player.MinionManager.UndeadMinions.Find(m => m.data.minionType == selectedType)?.data;

        if (lordData != null && minionData != null)
        {
            _player.LordPurchaseManager.TryBuyLord(_player, minionData, lordData);
        }
        else
        {
            Debug.LogWarning($"[BuyLord] Missing data for type: {selectedType}");
        }
    }
}
