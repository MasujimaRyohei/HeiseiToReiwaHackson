using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Card : MonoBehaviour
{
    public CardsData data;
    public Image image;
    public TextMeshProUGUI text;
    public bool isSelected = false;
    // Start is called before the first frame update
    private void Start()
    {
        string path = "Images/Cards/Card" + data.Id;
        Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        image.sprite = sprite;
        text.text = data.Description;
    }

    public void OnClick()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            image.color = Color.gray;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
