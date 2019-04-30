using System;

[Serializable]
public class CommandBase
{
    public string commandName;
    public string description;
    public virtual Status Effect(Status status)
    {
        return status;
    }

    public bool isPermanence;

}
