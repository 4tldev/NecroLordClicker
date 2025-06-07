using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class SO_VoidEventChannel : ScriptableObject
{
    public UnityEvent OnEventRaised;

    public void Raise()
    {
        OnEventRaised?.Invoke();
    }
}
