using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
    [SerializeField] private SO_VoidEventChannel eventChannel;
    [SerializeField] private UnityEvent response;

    private void OnEnable()
    {
        if (eventChannel != null)
            eventChannel.OnEventRaised.AddListener(response.Invoke);
    }

    private void OnDisable()
    {
        if (eventChannel != null)
            eventChannel.OnEventRaised.RemoveListener(response.Invoke);
    }
}
