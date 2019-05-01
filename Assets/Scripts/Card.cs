using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardsData data;
    public Image image;
    public TextMeshProUGUI text;
    public bool isSelected = false;
    // Start is called before the first frame update
    private void Start()
    {
        string path = "Images/Cards/card_" + data.Id;
        Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        image.sprite = sprite;
        text.text = data.Description;
    }

    private void Update()
    {
        string path = "Images/Cards/card_" + data.Id;
        Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        //print(sprite);
        if (data.Id == 0)
        {
            GetComponent<Button>().enabled = false;
        }
        else
        {
            GetComponent<Button>().enabled = true;

        }
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