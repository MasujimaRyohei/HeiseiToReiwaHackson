using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPart : PartBase
{

    public List<Card> possessionCommands;

    public Text text;

    public Card selectCard;

    public Transform possessionCardTransform;
    public Card cardPrefab;

    // Start is called before the first frame update
    public override void  Init()
    {
        base.Init();

        possessionCommands = new List<Card>();

        // TODO : プールしたい
        foreach (Transform child in possessionCardTransform)
        {
            Destroy(child.gameObject);
        }


        for (int i = 0; i < player.possessionCommands.Count; i++)
        {
            Card card = Instantiate(cardPrefab, possessionCardTransform);
            card.data = player.possessionCommands[i];
            possessionCommands.Add(card);

        }
    }

    // Update is called once per frame
    void Update()
    {
        Reload();

        for (int i = 0; i < possessionCommands.Count; i++)
        {
            if (possessionCommands[i] == null)
            {
                continue;
            }
            if (possessionCommands[i].image.color == Color.gray)
            {
                selectCard = possessionCommands[i];
            }
        }
        if (selectCard != null)
            text.text = selectCard.data.Description;
    }

    public void Reload()
    {
        for (int i = 0; i < player.possessionCommands.Count; i++)
        {
            if (possessionCommands.Count > i)
            {
                if (possessionCommands[i] != null)
                {
                    possessionCommands[i].data = player.possessionCommands[i];
                }
            }
        }
    }

    public void GoEvent()
    {
        if (selectCard)
        {
            player.status.life += selectCard.data.Life;
            player.status.life = Mathf.Clamp(player.status.life, 0, 100);
        }
        StartCoroutine(GoEventCoroutine());
    }

    public IEnumerator GoEventCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        FinishPart();
    }
}