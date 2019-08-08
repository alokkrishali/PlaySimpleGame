using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    [SerializeField]
    Vector2 topPos, bottomPos;

    [SerializeField]
    Dropdown myDropdown;

    bool IsShow = false;

    [SerializeField]
    Animator anim;

    [SerializeField]
    ChatWindow chatWin;

    int toggle = 0;


    void Start()
    {
        myDropdown.onValueChanged.AddListener(delegate {
            myDropdownValueChangedHandler(myDropdown);
        });
        chatWin.ApplyData();
        toggle = 0;
        anim.SetInteger("ChatBoxState", toggle);
    }

    private void myDropdownValueChangedHandler(Dropdown target)
    {
        toggle = 1;
        anim.SetInteger("ChatBoxState", toggle);
        switch (target.value)
        {
            case 0:
                chatWin.setDataFor(0);
                break;
            case 1:
                chatWin.setDataFor(1);
                break;
            case 2:
                chatWin.setDataFor(2);
                break;
        }
    }

    public void CloseChatBox()
    {
        if (toggle == 0)
            toggle = 1;
        else
            toggle = 0;
        anim.SetInteger("ChatBoxState", toggle);
    }
    public void GetSetData()
    {
        chatWin.ApplyData();
    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
