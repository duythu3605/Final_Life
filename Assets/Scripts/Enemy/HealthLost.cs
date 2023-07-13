using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthLost : MonoBehaviour
{
    public Transform _parentHealthLost;


    public GameObject healtLostText;

    public delegate void OnShowHealthLost(float value);
    public OnShowHealthLost healthLost;

    public void Init()
    {
        healthLost += SetHealthLost;
    }

    public void SetHealthLost(float value)
    {
        GameObject obj = Instantiate(healtLostText, _parentHealthLost);        
        obj.transform.GetChild(0).GetComponent<TMP_Text>().text = value.ToString();
        StartCoroutine(TimeLost(obj));        
    }

    private IEnumerator TimeLost(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        Destroy(obj);
    }
}
