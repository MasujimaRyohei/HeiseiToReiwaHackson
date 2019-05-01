using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Shop : SingletonMonoBehaviour<Shop>
{
    public List<int> commandCatalog;

    public int[] RandomShowCommandCatalog(int num)
    {
        int[] temporary = commandCatalog.ToArray();
        for (int i = 0; i < temporary.Length; i++)
        {
            int temp = temporary[i];
            int randomIndex = Random.Range(0, temporary.Length);
            temporary[i] = temporary[randomIndex];
            temporary[randomIndex] = temp;
        }
        return temporary.Take(num).ToArray();
    }

    private void Start()
    {
        //foreach(int num in RandomShowCommandCatalog(4))
        //{
        //    print("catalog:"+ MasterData.instance.GetCardDataUsingID(num).Name);
        //}
    }
}
