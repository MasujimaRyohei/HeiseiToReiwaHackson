using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessageDialog : SingletonMonoBehaviour<MessageDialog>
{
    private IEnumerator Example()
    {
        imageFinishIndicator.gameObject.SetActive(false);
        CardsData[] cards = MasterData.instance.cards.dataArray;
        for (int i = 0; i < cards.Length; i++)
        {
            yield return ShowMessageLikeTypeWriter(cards[i].Name);
            while (!Input.GetKeyDown(KeyCode.Return))
            {
                yield return null;
            }
            yield return ShowMessageLikeTypeWriter(cards[i].Description);
            while (!Input.GetKeyDown(KeyCode.Return))
            {
                yield return null;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (charaLength != textMessage.text.Length)
            {
                skip = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            textMessage.gameObject.SetActive(!textMessage.gameObject.activeSelf);
        }
    }
    public Text textMessage;
    public float delayTime;
    private bool skip = false;
    private int charaLength;
    public Image imageFinishIndicator;
    public void Open()
    {
        textMessage.gameObject.SetActive(true);
    }
    public void Close()
    {
        textMessage.gameObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        if (!textMessage.gameObject.activeSelf)
        {
            Open();
        }

        textMessage.text = message;
    }

    public IEnumerator ShowMessageLikeTypeWriter(string message)
    {
        StartSentence();
        yield return StartCoroutine(ShowMessageLikeTypeWriterCoroutine(message));
        EndSentence();
    }

    private IEnumerator ShowMessageLikeTypeWriterCoroutine(string message)
    {
        charaLength = message.Length;
        WaitForSeconds waitForSeconds = new WaitForSeconds(delayTime);
        for (int i = 0; i <= charaLength; i++)
        {
            yield return waitForSeconds;
            while(!textMessage.gameObject.activeSelf)
            {
                yield return null;
            }
            textMessage.text = message.Substring(0, i);
            if (skip)
            {
                i = charaLength - 1;
                skip = false;
            }
        }
        yield return null;
    }

    private void StartSentence()
    {
        imageFinishIndicator.gameObject.SetActive(false);

    }
    private void EndSentence()
    {
        imageFinishIndicator.gameObject.SetActive(true);

    }
}
