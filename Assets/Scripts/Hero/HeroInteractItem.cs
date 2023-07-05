using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroInteractItem : MonoBehaviour
{

    public Interactable _focus;
    //public GameObject _interactButton;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interactable interactable = collision.GetComponent<Interactable>();
        if (interactable != null)
        {
            SetFocus(interactable);
        }
        //ShowInfor(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFocus();
        //_interactButton.SetActive(false);
    }

    private void SetFocus(Interactable newFocus)
    {
        if (_focus != null)
        {
            _focus.OnDeFocused();
        }
        _focus = newFocus;
        newFocus.OnFocused();
    }

    private void RemoveFocus()
    {
        if (_focus != null)
        {
            _focus.OnDeFocused();
        }
        _focus = null;

    }
    //private void ShowInfor(GameObject obj)
    //{
    //    _interactButton.GetComponentInChildren<TMP_Text>().text = "Touch " + obj.name;
    //    _interactButton.SetActive(true);
    //}
}
