[System.Serializable]
public class MinionListEntry
{
    public SO_UndeadMinionData data;
    public BigNumber amountOwned;

    public MinionListEntry(SO_UndeadMinionData data, BigNumber amount)
    {
        this.data = data;
        this.amountOwned = amount;
    }
}
