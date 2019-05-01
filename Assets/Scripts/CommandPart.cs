using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPart : PartBase
{
    Player player;

    public Card[] cards;
    public Image[] images;

    public Text text;

    public Card selectCard;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Reload();

        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].color == Color.gray)
            {
                selectCard = cards[i];
            }
        }
        if(selectCard!=null)
        text.text = selectCard.data.Description;
    }

    public void Reload()
    {
        for(int i = 0; i < player.possessionCommands.Count; i++)
        {
            cards[i].data = player.possessionCommands[i];
        }
    }

    public void GoEvent()
    {
        Debug.Log(selectCard.data.Value);
        player.status.life += selectCard.data.Value;
    }
}
