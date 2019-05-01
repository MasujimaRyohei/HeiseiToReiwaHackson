using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Shop : SingletonMonoBehaviour<Shop>
{
    public List<Card> commandCatalog;
    public Card cardPrefab;
    public int maxCatalogNum = 12;
    public ConfirmPanel panelPurchase;
    public ResultPanel panelResult;
    public Transform confirmViewTransform;
    public List<Card> purchaseCards = new List<Card>();
    public int price=0;


    public CardsData[] RandomShowCommandCatalog(int num)
    {
        CardsData[] temporary = MasterData.instance.cards.dataArray;
        for (int i = 0; i < temporary.Length; i++)
        {
            CardsData temp = temporary[i];
            int randomIndex = Random.Range(0, temporary.Length);
            temporary[i] = temporary[randomIndex];
            temporary[randomIndex] = temp;
        }
        return temporary.Take(num).ToArray();
    }

    private void Start()
    {
        panelPurchase.gameObject.SetActive(false);
        panelResult.gameObject.SetActive(false);

        CardsData[] data = RandomShowCommandCatalog(maxCatalogNum);
        for (int i = 0; i < maxCatalogNum; i++)
        {
            Card card = Instantiate(cardPrefab, transform);
            card.data =  data[i];
            commandCatalog.Add(card);
        }
        Player.instance.status.money = 3000;
    }

    public void OnClickPurchase()
    {
        StartCoroutine(ConfirmPurchase());

    }

    public IEnumerator ConfirmPurchase()
    {
        OpenedMethod();
       yield return panelPurchase.Open(PurchaseMethod);
        while(panelPurchase.isOpened)
        {
            yield return null;
        }

        
    }

    private void OpenedMethod()
    {
        price = 0;
        for (int i = 0; i < maxCatalogNum; i++)
        {
            if (commandCatalog[i].isSelected)
            {
                purchaseCards.Add(commandCatalog[i]);
                price += commandCatalog[i].data.Price;
                Instantiate(cardPrefab, confirmViewTransform).data = commandCatalog[i].data;
            }
        }
    }

    private void PurchaseMethod(bool confirm)
    {
        if(!confirm)
        {
            return;
        }
      
        string message  ="";
        if (Player.instance.status.money > price)
        {

            Player.instance.status.money -= price;
            message=purchaseCards.Count + "つで" + price + "円です。残高は" + Player.instance.status.money + "円です。";

            for (int i = 0; i < purchaseCards.Count; i++)
            {
                Player.instance.possessionCommands.Add(purchaseCards[i].data);
            }
            purchaseCards.Clear();
            foreach(Transform child in confirmViewTransform)
            {
                Destroy(child.gameObject);
            }
        }
        else
        {
            message="残高が足りません。";
        }
        panelResult.Open(message);



    }

    private void Example()
    {
        //commandCatalog = RandomShowCommandCatalog(4).ToList();

        foreach (Card card in commandCatalog)
        {
            print("catalog:" + card.data.Name);
        }
        //foreach(int num in RandomShowCommandCatalog(4))
        //{
        //    print("catalog:"+ MasterData.instance.GetCardDataUsingID(num).Name);
        //}
    }
}