using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RunTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // Optional: drag a Text UI element here

    private float _timer;
    private int _secondsElapsed;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 1f)
        {
            _secondsElapsed += Mathf.FloorToInt(_timer);
            _timer %= 1f; // Preserve any leftover fraction of a second

            TimeSpan timeSpan = TimeSpan.FromSeconds(_secondsElapsed);
            string formatted = timeSpan.ToString(@"hh\:mm\:ss");

            if (timerText != null)
                timerText.text = formatted;
        }
    }
}
