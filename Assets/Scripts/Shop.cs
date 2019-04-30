using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<CommandBase> commandCatalog;

    private void Start()
    {
        commandCatalog = new List<CommandBase>();

        foreach(CommandBase command in commandCatalog)
        {
            print(command);
        }
    }
}
