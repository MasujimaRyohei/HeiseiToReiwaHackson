using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
 public   Text textMessage;
    public void Open(string message)
    {
        gameObject.SetActive(true);
        textMessage.text = message;
        StartCoroutine(AutoEnactiveCoroutine());

    }
    private IEnumerator AutoEnactiveCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        gameObject.SetActive(false);
    }
}
