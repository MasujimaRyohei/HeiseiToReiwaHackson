using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterData : SingletonMonoBehaviour<MasterData>
{
    public Cards cards;
    public Events events;

    private void Start()    
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
