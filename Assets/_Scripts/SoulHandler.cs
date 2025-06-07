using UnityEngine;

public class SoulHandler : MonoBehaviour
{
    // Class handles all player soul rewarding and spending

    [SerializeField] private Player player;
    [SerializeField] private SO_VoidEventChannel phylacteryClickChannel;

    private float timer;

    private void Start()
    {
        player = GetComponent<Player>();
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            GiveSoulsPerSecond();
            timer = 0f;
        }
    }
    public void GiveSoulsPerClick()
    {
        player.AddSouls(player.currentSoulsPerClick);
        Debug.Log($"Gained {player.currentSoulsPerClick} souls! Total: {player.Souls}");
    }

    public void GiveSoulsPerSecond()
    {
        player.AddSouls(player.currentSoulsPerSecond);
    }

    public void AddSouls(Player player, BigNumber amount) 
    {
        player.AddSouls(amount);
    }

    public void RemoveSouls(Player player, BigNumber amount) 
    {
        player.RemoveSouls(amount);
    }

    
}
