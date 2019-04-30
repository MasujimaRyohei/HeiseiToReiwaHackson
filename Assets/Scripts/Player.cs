using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Status status;

    private List<CommandBase> possessionCommands;

    public void BuyCommand(CommandBase command)
    {
        possessionCommands.Add(command);
    }

    public void UseCommand(CommandBase command)
    {
        status = command.Effect(status);
        if (!command.isPermanence)
        {
            possessionCommands.Remove(command);
        }
    }

    private void Start()
    {
        possessionCommands = new List<CommandBase>();

        foreach(CommandBase command in possessionCommands)
        {
            print(command);
        }
    }
}
