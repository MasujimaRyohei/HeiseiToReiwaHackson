using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Cards data;
    public List<CommandBase> commandCatalog;

    private void Start()
    {
        commandCatalog = new List<CommandBase>();

        foreach(CardsData card in data.dataArray)
        {
            print(card.Name);
        }
    }
}
