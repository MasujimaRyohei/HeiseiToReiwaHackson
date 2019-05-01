using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterData : SingletonMonoBehaviour<MasterData>
{
    public Cards cards;
    public Events events;

    public CardsData GetCardDataUsingID(int id)
    {
        for(int i = 0;i<cards.dataArray.Length;i++)
        {
            CardsData card = cards.dataArray[i];
            if (card.Id ==id)
            {
                return card;
            }
        }
        return null;
    }

    private void Example()    
    {
        foreach (CardsData card in cards.dataArray)
        {
            print(card.Id + " : " + card.Name);
        }

        foreach (EventsData card in events.dataArray)
        {
            print(card.Id + " : " + card.Name);
        }
    }
}
