using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBase : MonoBehaviour
{
    public virtual void Init()
    {

    }
    public void FinishPart()
    {
        PartManager.Instance.NextPart();
    }
}
