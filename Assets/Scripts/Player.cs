using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Status status;

    private List<int> possessionCommands;

    public void BuyCommand(CardsData card)
    {
        possessionCommands.Add(card.Id);
    }

    public void UseCommand(CardsData card)
    {

        status.life += card.Value;
        status.money -= card.Price;

        //! 消費コマンドかどうか
        //if (!card)
        //{
        //    possessionCommands.Remove(cardId);
        //}
    }

    private void Start()
    {
        possessionCommands = new List<int>();

        foreach(int command in possessionCommands)
        {
            print(command);
        }
    }
}
