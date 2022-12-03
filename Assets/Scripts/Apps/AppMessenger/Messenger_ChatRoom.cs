using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Messenger_ChatRoom : MonoBehaviour
{
    public GameObject phoneHome;
    public GameObject pageThis;
    public GameObject pageClose;
    public GameObject pageGoBack;

    private ChatContainer ChatRoom;
    private int msgCountToShow;

    public void page_open(ChatContainer chatRoom)
    {
        this.init(chatRoom);
        this.refresh();
    }

    public void init(ChatContainer chatRoom)
    {
        this.phoneHome = GameObject.Find("PhoneOnHand").transform.Find("ScreenHome").gameObject;
        this.pageThis = GameObject.Find("AppMessenger").transform.Find("ChatRoom").gameObject;
        this.pageClose = this.pageThis;
        this.pageGoBack = GameObject.Find("AppMessenger").transform.Find("ChatRoomList").gameObject;

        this.ChatRoom = chatRoom;
        this.msgCountToShow = 30;
    }

    public void goBack()
    {
        this.pageGoBack.SetActive(true);
        this.pageGoBack.GetComponentInChildren<Messenger_ChatRoomList>().page_open();
        this.pageClose.SetActive(false);
    }

    public void goHome()
    {
        this.phoneHome.SetActive(true);
        this.pageThis.SetActive(false);
    }

    public void refresh()
    {
        this.delete();
        //int countMaxMsg = 30;
        //int countMsgAll = this.ChatRoom.getCountChat()
        //int countMaxMsg = countMsgAll;
        //if (countMsgAll < countMaxMsg)
        //    countMaxMsg = countMsgAll;

        //msgCountToShow = countMaxMsg;

        this.msgCountToShow = this.ChatRoom.getCountChat();


        for (int i = 0; i < this.msgCountToShow; i++)
        {
            GameObject dialogLeft = Resources.Load<GameObject>("Prefabs/DialogLineLeft");
            GameObject Instance = (GameObject)Instantiate(dialogLeft, GameObject.Find("AppMessenger").transform.Find("ChatRoom").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

            Instance.transform.Find("ImageDialogBubbleLeft").transform.Find("TextDialog").GetComponentInChildren<TextMeshProUGUI>().text = this.ChatRoom.getChat(i).getString();
        }
    }

    private void delete()
    {

        int countchild = GameObject.Find("Viewport").transform.Find("Content").childCount;

        for (int i = 0; i < countchild; i++)
        {
            Destroy(GameObject.Find("Viewport").transform.Find("Content").GetChild(i).gameObject);
        }
    }

}
