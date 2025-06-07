using UnityEngine;

public static class UI_Events
{
    public static SO_VoidEventChannel RefreshUIEvent;

    public static void RaiseRefreshUI()
    {
        if (RefreshUIEvent != null)
            RefreshUIEvent.Raise();
    }
}
