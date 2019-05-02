using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : SingletonMonoBehaviour<PartManager>
{
    public PartBase[] parts;
    public int currentPart = 0;

    private void Start()
    {
        Player.instance.Init();
        parts[currentPart].Init();
    }
    public void NextPart()
    {
        parts[currentPart].gameObject.SetActive(false);
        if (parts.Length -1<= currentPart)
        {
            currentPart = 0;
        }
        else
        {
            currentPart++;
        }
        parts[currentPart].gameObject.SetActive(true);
        parts[currentPart].Init();
    }
}
