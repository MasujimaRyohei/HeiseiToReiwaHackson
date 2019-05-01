using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonoBehaviour<Player>
{
    public Status status;

    public List<CardsData> possessionCommands;

    public void BuyCommand(CardsData card)
    {
        possessionCommands.Add(card);
    }

    public void UseCommand(CardsData card)
    {

        status.life += card.Value;
        status.money -= card.Price;

        //! 消費コマンドかどうか
        if (card.Price!=0)
        {
            possessionCommands.Remove(card);
        }
    }

    private void Start()
    {
        status = new Status { money = 300000, life = 100 };
        print("Money:"+status.money);
        print("Life:"+status.life);
        possessionCommands = new List<CardsData>();

        foreach(CardsData command in possessionCommands)
        {
            print(command);
        }
    }
}
