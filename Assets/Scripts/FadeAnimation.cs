using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour
{
    Animator animator;

    public GameObject targetObj;
    public GameObject nowObj;

    public bool fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {
            nowObj.SetActive(false);
            targetObj.SetActive(true);
        }
    }

    public void FadeIn()
    {
        animator.Play("FadeIn", 0);
    }

    public void ChangeObj()
    {
        //nowObj.SetActive(false);
        //targetObj.SetActive(true);
    }
}
