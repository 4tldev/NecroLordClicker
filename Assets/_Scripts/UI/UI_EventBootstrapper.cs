using UnityEngine;

public class UIEventBootstrapper : MonoBehaviour
{
    [SerializeField] private SO_VoidEventChannel refreshUI;

    private void Awake()
    {
        UI_Events.RefreshUIEvent = refreshUI;
    }
}
