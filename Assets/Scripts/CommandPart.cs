using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPart : PartBase
{
    Player player;

    public List<Card> cards = new List<Card>();

    public Text text;

    public Card selectCard;

    public Transform possessionCardTransform;
    public Card cardPrefab;

    // Start is called before the first frame update
    public override void  Init()
    {
        player = Player.Instance;
        for (int i = 0; i < player.possessionCommands.Count; i++)
        {
            Card card = Instantiate(cardPrefab, possessionCardTransform);
            card.data = player.possessionCommands[i];
            cards.Add(card);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Reload();

        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] == null)
            {
                continue;
            }
            if (cards[i].image.color == Color.gray)
            {
                selectCard = cards[i];
            }
        }
        if (selectCard != null)
            text.text = selectCard.data.Description;
    }

    public void Reload()
    {
        for (int i = 0; i < player.possessionCommands.Count; i++)
        {
            if (cards[i] != null)
            {
                cards[i].data = player.possessionCommands[i];
            }
        }
    }

    public void GoEvent()
    {
        player.status.life += selectCard.data.Life;
        player.status.life= Mathf.Clamp(player.status.life, 0, 100);
        FinishPart();
    }
}