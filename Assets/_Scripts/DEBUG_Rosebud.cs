using UnityEngine;

public class DEBUG_Rosebud : MonoBehaviour
{
    [SerializeField] public KeyCode rosebudKey = KeyCode.G;
    [SerializeField] private Player player;
    [SerializeField] private BigNumber rosebudAmount = new BigNumber(100000000);
    [SerializeField] public SO_VoidEventChannel onSoulsChanged;


    private void Update()
{
    if (Input.GetKeyDown(rosebudKey))
    {
        if (player == null)
        {
            Debug.LogError("DEBUG_Rosebud: Player is not assigned!");
            return;
        }

        player.SoulHandler.AddSouls(player, rosebudAmount);
        onSoulsChanged?.Raise();
    }
}

}
