using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int life;
    private int money;

    private List<CommandBase> possessionCommands;

    public void BuyCommand(CommandBase command)
    {
        possessionCommands.Add(command);
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
