using UnityEngine;

public class PhylacteryClickObject : MonoBehaviour
{
    [SerializeField] private SO_VoidEventChannel onPhylacteryClicked;
    [SerializeField] private Animator animator;


    
    private void OnMouseEnter()
    {
        animator.SetBool("isHovering", true);
    }

    private void OnMouseExit()
    {
        animator.SetBool("isHovering", false);
        animator.SetBool("isClicking", false); // ensure we exit click if hovering stops
    }

    private void OnMouseDown()
    {
        animator.SetBool("isClicking", true);
        animator.Play("Anim_Phylactery_Click", -1, 0f); // hack to make it always play on click
    }

    private void OnMouseUp()
    {
        animator.SetBool("isClicking", false);
        onPhylacteryClicked.Raise(); // trigger the souls logic on release
    }


}
