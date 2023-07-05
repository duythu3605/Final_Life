using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    private bool isFocus = false;
    private bool hasInteracted = false;

    public virtual void Interact()
    {
       
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            hasInteracted = true;
            Interact();
        }
    }
    public void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    public void OnFocused()
    {
        isFocus = true;
        hasInteracted = false;
    }
    public void OnDeFocused()
    {
        isFocus = false;
        hasInteracted = false;
    }
}
