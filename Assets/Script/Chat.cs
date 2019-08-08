using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    [SerializeField]
    Text chatText;

    public void SetChat(string text)
    {
        chatText.text = text;
    }
    public void SetEnable(bool status)
    {
        gameObject.SetActive(status);
    }
}
