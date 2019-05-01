using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Shop : SingletonMonoBehaviour<Shop>
{
    public List<CardsData> commandCatalog;

    public CardsData[] RandomShowCommandCatalog(int num)
    {
        CardsData[] temporary = commandCatalog.ToArray();
        for (int i = 0; i < temporary.Length; i++)
        {
            CardsData temp = temporary[i];
            int randomIndex = Random.Range(0, temporary.Length);
            temporary[i] = temporary[randomIndex];
            temporary[randomIndex] = temp;
        }
        return temporary.Take(num).ToArray();
    }

    private void Example()
    {
        commandCatalog = RandomShowCommandCatalog(4).ToList();

        foreach(CardsData card in commandCatalog)
        {
             print("catalog:"+ card.Name);
        }
        //foreach(int num in RandomShowCommandCatalog(4))
        //{
        //    print("catalog:"+ MasterData.instance.GetCardDataUsingID(num).Name);
        //}
    }
}
