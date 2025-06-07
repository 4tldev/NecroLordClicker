using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UI_ToggleUIButton : MonoBehaviour
{
    [SerializeField] GameObject go;
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
    }

    public void ToggleDisplay()
    {
        go.SetActive(!go.activeSelf);
    }
}
