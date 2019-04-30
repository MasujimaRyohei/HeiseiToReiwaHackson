using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public CommandList list;
    public List<CommandBase> commandCatalog;

    private void Start()
    {
        commandCatalog = new List<CommandBase>();

        foreach(CommandBase command in list.commands)
        {
            print(command.commandName);
            print(command.description);
        }
    }
}
