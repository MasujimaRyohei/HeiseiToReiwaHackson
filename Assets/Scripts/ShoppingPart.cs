using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingPart : PartBase
{
    public ConfirmPanel confirmPanel;
    public ResultPanel resultPanel;
    public override void Init()
    {
        confirmPanel.gameObject.SetActive(false);
        resultPanel.gameObject.SetActive(false);

        Shop.Instance.commandCatalog = new List<Card>();
    }
}