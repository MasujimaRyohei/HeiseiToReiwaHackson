using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : SingletonMonoBehaviour<Player>
{
    public Status status;

    public Text moneyText;
    public RectTransform lifeImage;

    public List<CardsData> possessionCommands;

    private void Start()
    {
        possessionCommands.Add(MasterData.instance.GetCardDataUsingID(1));
        possessionCommands.Add(MasterData.instance.GetCardDataUsingID(2));
        status = new Status { money = 300000, life = 50 };

    }

    private void Update()
    {
        moneyText.text = status.money.ToString();
        lifeImage.sizeDelta = new Vector2(((float)status.life /100f ) * 400f, 36);
    }

    public void BuyCommand(CardsData card)
    {
        possessionCommands.Add(card);
    }

    public void UseCommand(CardsData card)
    {

        status.life += card.Life;
        status.money -= card.Price;

        //! 消費コマンドかどうか
        if (card.Price!=0)
        {
            possessionCommands.Remove(card);
        }
    }

    private void Example()
    {
        status = new Status { money = 300000, life = 100 };
        //print("Money:"+status.money);
        //print("Life:"+status.life);
        possessionCommands = new List<CardsData>();

        foreach(CardsData command in possessionCommands)
        {
            print(command);
        }
    }
}
