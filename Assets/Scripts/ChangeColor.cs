﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Image[] images;

    public Image image;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void ChangeColorEvent()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = Color.white;
        }

        if (image.color == Color.white)
        {
            image.color = Color.gray;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
