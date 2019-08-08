using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ChatData
{
    public List<string> oldChat = new List<string>();
}

public class ChatWindow : MonoBehaviour
{
    int DataPersonIndex = 0;

    [SerializeField]
    InputField inputF;

    [SerializeField]
    List<ChatData> chatDatas;

    [SerializeField]
    Chat [] chatObjects;

    void Start()
    {
        
    }
    void DisableAllData()
    {
        for (int i = 0; i < chatObjects.Length; i++)
        {
            chatObjects[i].SetEnable(false);
        }
    }

    public void setDataFor(int personIndex)
    {
        DataPersonIndex = personIndex;
        ApplyData();
    }

    public void ApplyData()
    {
        DisableAllData();
        for (int i=0;i< chatDatas[DataPersonIndex].oldChat.Count;i++)
        {
            chatObjects[i].SetEnable(true);
            chatObjects[i].SetChat(chatDatas[DataPersonIndex].oldChat[i]);
        }
    }

    // Update is called once per frame
    public void SendButton()
    {
        string currentChat = inputF.text;
        inputF.text = "";
        chatDatas[DataPersonIndex].oldChat.Add(currentChat);
        ApplyData();
    }
}
