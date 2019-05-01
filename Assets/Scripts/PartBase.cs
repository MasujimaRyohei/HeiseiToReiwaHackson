using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBase : MonoBehaviour
{
    public void FinishPart()
    {
        PartManager.Instance.NextPart();
    }
}
