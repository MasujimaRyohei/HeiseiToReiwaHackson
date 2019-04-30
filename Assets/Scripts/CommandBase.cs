using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CommandBase : MonoBehaviour
{
    [SerializeField]
    public string description;
    [SerializeField]
    public System.Action effect;

}
