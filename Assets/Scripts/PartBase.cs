using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBase : MonoBehaviour
{
    protected Player player;

    public virtual void Init()
    {
        player = Player.Instance;
    }
    public void FinishPart()
    {
        PartManager.Instance.NextPart();
    }
}
