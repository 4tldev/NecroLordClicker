using UnityEngine.UI;
using UnityEngine;

public class SelectionListController : MonoBehaviour
{
    private Button currentSelected;

    public void OnItemSelected(Button selectedButton)
    {
        if (currentSelected != null)
        {
            // Optionally reset color manually or via Animator
            SetButtonState(currentSelected, false);
        }

        currentSelected = selectedButton;
        SetButtonState(currentSelected, true);
    }

    private void SetButtonState(Button button, bool isSelected)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = isSelected ? Color.green : Color.white; // example
        button.colors = colors;
    }
}
