using UnityEngine;
using UnityEngine.UI;

public class SelectableItem : MonoBehaviour
{
    public Button button;
    public SelectionListController listController;

    void Start()
    {
        button.onClick.AddListener(() => listController.OnItemSelected(button));
    }
}
