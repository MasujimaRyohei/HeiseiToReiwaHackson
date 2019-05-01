using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Card: MonoBehaviour
{
    public CardsData data;
    public Image image;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Start()
    {
        string path = "Images/Cards/Card" + data.Id;
        Sprite sprite = Resources.Load(path,typeof(Sprite)) as Sprite;
        print(sprite);
        image.sprite = sprite;
        text.text = data.Description;
    }
}
