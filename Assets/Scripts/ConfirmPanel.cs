using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanel : MonoBehaviour
{

    public bool isOpened = false;
    public Text text;
    public Button buttonYes;
    public Button buttonNo;
     public  bool isSelected = false;
    public System.Action<bool> confirmedAction;
    
    public IEnumerator Open(System.Action<bool> callback)
    {
        gameObject.SetActive(true);
        confirmedAction = callback;
        isOpened = true;
        isSelected = false;

        while(!isSelected)
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }

    public void OnClickButtonYes()
    {
        confirmedAction.Invoke(true);
        isSelected = true;

    }
    public void OnClickButtonNo()
    {
        confirmedAction.Invoke(false);
        isSelected = true;

    }
}
