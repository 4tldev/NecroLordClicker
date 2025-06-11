using System;
using UnityEngine;

public class LordPurchaseManager : MonoBehaviour
{
    [SerializeField] private Lord lordPrefab;
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void TryBuyLord(Player player, SO_UndeadMinionData minionData, SO_LordData lordData)
    {
        foreach (var item in player.MinionManager.UndeadMinions)
        {
            if (item.data == minionData)
            {
                BigNumber currentMinionCost = GetCurrentMinionCost(player, lordData);
                if (item.amountOwned >= currentMinionCost)
                {
                    player.MinionManager.RemoveMinions(minionData, currentMinionCost);
                    // ✅ Instantiate the Lord under the player's lord container
                    Lord lordToAdd = Instantiate(lordPrefab, player.LordContainer);

                    // ✅ Initialize with the LordData
                    lordToAdd.Init(lordData);

                    // ✅ Add to LordManager
                    player.LordManager.AddLord(lordToAdd);
                }
                else
                {
                    Debug.Log($"You don't have the required amount of {item.data.name}s! You need {lordData.currentCost} but you only have {item.amountOwned}");
                }

                return; // stop here — we found the match
            }
        }

        // If no match was found at all
        throw new Exception($"Minion type '{minionData.name}' not found in player's minion list.");
    }

    public BigNumber GetCurrentMinionCost(Player player, SO_LordData lordData)
    {
        foreach (var entry in player.LordManager.Lords)
        {
            if (entry.data == lordData)
            {
                int ownedCount = entry.lordTypeList.Count;
                BigNumber currentCost = lordData.baseCost * BigNumber.Pow(new BigNumber(lordData.purchaseMultiplier), ownedCount);
                return currentCost;
            }
        }

        // If the player doesn't own any lords of that type, return base cost
        return lordData.baseCost;
    }

}
