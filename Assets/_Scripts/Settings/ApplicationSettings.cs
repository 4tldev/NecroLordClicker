using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
    [SerializeField] private int targetFrameRate = -1; // TODO -1 makes this unlimited but we may want this to be 60
    void Awake()
    {
        Application.runInBackground = true;
        Application.targetFrameRate = targetFrameRate;
    }

    void Start()
    {
        Screen.SetResolution(1280, 720, false); // false = windowed
    }
}
